using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Data.Dtos.Books;

namespace VideoGameCharacterApi.Controllers;

[Route("api/books")]
[ApiController]
public class BooksController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GenericResponse>> GetAllBooks()
    {
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
            })
            .ToListAsync();

        return Ok(new GenericResponse
        {
            Message = "Data fetched successfully.",
            Data = result
        });
    }
}