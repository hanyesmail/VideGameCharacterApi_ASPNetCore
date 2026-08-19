using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// If you want to add a table with different name from the Entity model
// add this annotaion to the top of the class creation
// [Table("DifferentName")]
// ==============================================

// Also you can add a table under different schema instead of the default one "dbo"
// [Table("TableName", Schema = "New Schema Name")]
// ==============================================

namespace VideoGameCharacterApi.Data.Models;

public class Character
{
    // To set any column as primary key
    // [Key]
    // ==============================================
    public int Id { get; set; }
    
    // To change datatype of a column
    [Column(TypeName = "varchar(100)")]
    // ==============================================
    public string Name { get; set; }  = string.Empty;
    
    
    // To set Max Length 
    [MaxLength(50)]
    // ==============================================
    public string Game { get; set; } = string.Empty;
    
    // To add comment on any column (For Documentation)
    // [Comment("add your comment")]
    // ==============================================
    
    // To set specific column as a ForeignKey 
    //[ForeignKey(nameof(Game))]
    // ==============================================
    [Column(TypeName = "varchar(50)")]
    public string Role { get; set; } = string.Empty;

    [Column(TypeName =  "varchar(50)")]
    public string CreationDate { get; set; } = string.Empty;
    
    public virtual CharacterType? Type { get; set; } = new CharacterType();

    public virtual CharacterColor? Color { get; set; } =  new CharacterColor();
}