using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jwt_funder.Models;

[Table("votes")]
public class Vote
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public enum VoteType
    {
        AGREE,
        DISAGREE
    }

    [Required]
    [Column("voteType")]
    public VoteType Type { get; set; }

    [Required]
    [ForeignKey("User")]
    [Column("user_id")]
    public int UserId { get; set; }
    public required User User { get; set; }

    [Required]
    [ForeignKey("Idea")]
    [Column("idea_id")]
    public int IdeaId { get; set; }
    public required Idea Idea { get; set; }
}
