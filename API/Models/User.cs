using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jwt_funder.Models;

public enum Role
{
    ADMIN,
    USER
    // Add other roles as needed
}

[Table("users")]
public class User // Or you could inherit from IdentityUser<int> if using Identity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("first_name")]
    public string FirstName { get; set; }

    [Column("last_name")]
    public string LastName { get; set; }

    [Column("username")]
    public string Username { get; set; }

    [Column("password")]
    public string Password { get; set; }

    [Column("role")]
    public Role Role { get; set; }

    public IEnumerable<string> GetAuthorities()
    {
        return new List<string> { Role.ToString() };
    }

    public bool IsAccountNonExpired => true;
    public bool IsAccountNonLocked => true;
    public bool IsCredentialsNonExpired => true;
    public bool IsEnabled => true;
}