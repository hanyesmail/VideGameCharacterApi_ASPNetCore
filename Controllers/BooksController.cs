using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Data.Dtos.Books;
using VideoGameCharacterApi.Data.Models;

namespace VideoGameCharacterApi.Controllers;

[Route("api/books")]
[ApiController]
public class BooksController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GenericResponse>> GetAllBooks()
    {
        //================================
        // We can change tracking option for each entity like this or make it over all the DbContext in Program.cs
        // var book = context.Books.AsNoTracking().Single(book => book.Id == 1);
        // var book = context.Books.Single(book => book.Id == 1);
        // book.Price = 2500;
        // await context.SaveChangesAsync();
        // var trackers = context.ChangeTracker.Entries();
        //================================
        
        
        var result = await context.Books
            .Join(
                context.Authors,
                book => book.AuthorId,
                author => author.Id,
                (book, author) => new
                {
                    BookId = book.Id,
                    BookName = book.Name,
                    AuthorName = author.Name,
                    author.NationalityId,
                })
            .GroupJoin(
                context.Nationalities,
                book => book.NationalityId,
                nationality => nationality.Id,
                (book, nationality) => new
                {
                    Book = book,
                    Nationality = nationality
                })
            .SelectMany(book => book.Nationality.DefaultIfEmpty(),
            (book, nationality) => new BookDto
            {
                BookId = book.Book.BookId,
                BookName = book.Book.BookName,
                AuthorName = book.Book.AuthorName,
                Nationality = nationality.NationalName ?? ""
                // Nationality = trackers.Count().ToString()
            })
            .ToListAsync();

        
        // Eager loading (Bad Performance)
        //================================
        // var book = await context.Books.Include(b => b.author).SingleOrDefaultAsync(b => b.Id == 1);
        // var result = new BookDto
        // {
        //     BookId = book.Id,
        //     BookName = book.Name,
        //     AuthorName = book.author.Name,
        //     Nationality =  ""
        // };

        
        // Explicit loading => we can load navigation proparty data after selecting the data if i had to load it
        //================================
        // var book = await context.Books.SingleOrDefaultAsync(b => b.Id == 1);
        // context.Entry(book).Reference(b => b.author).Load();
        // var result = new BookDto
        // {
        //     BookId = book.Id,
        //     BookName = book.Name,
        //     AuthorName = book.author.Name,
        //     Nationality =  ""
        // };
        
        
        // Lazy loading --> EntityFramework.Proxies --> Virtual navigation prop.
        //================================
        // var book = await context.Books.SingleOrDefaultAsync(b => b.Id == 1);
        // var result = new BookDto
        // {
        //     BookId = book.Id,
        //     BookName = book.Name,
        //     AuthorName = book.author.Name,
        //     Nationality =  ""
        // };

        return Ok(new GenericResponse
        {
            Message = "Data fetched successfully.",
            Data = result
        });
    }
}