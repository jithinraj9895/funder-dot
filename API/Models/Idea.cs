using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jwt_funder.Models;

[Table("ideas")]
public class Idea
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    public required string Title { get; set; }

    [ForeignKey("User")]
    [Column("user_id")]
    public int? UserId { get; set; } // Nullable if foreign key is optional
    public required User User { get; set; }

    [Column("description", TypeName = "TEXT")]
    public required string Description { get; set; }

    [Column("createdDate")]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    [Column("approvals")]
    public int Approvals { get; set; } = 0;

    [Column("disapprovals")]
    public int Disapprovals { get; set; } = 0;
}