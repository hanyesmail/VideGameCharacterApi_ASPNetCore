namespace VideoGameCharacterApi.Data.Models;

public class Book
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double? Price { get; set; }
    public int AuthorId { get; set; }

    public virtual Author author { get; set; }
}