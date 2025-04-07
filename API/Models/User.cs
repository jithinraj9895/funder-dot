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
    public int Id { get; set; }

    [Column]
    public string FirstName { get; set; }

    [Column]
    public string LastName { get; set; }

    [Column]
    public string Username { get; set; }

    [Column]
    public string Password { get; set; }

    [Column]
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