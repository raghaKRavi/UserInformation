using System.ComponentModel.DataAnnotations.Schema;

namespace UserInfo.Data;

[Table("User")]
public class User
{
    public int Id { get; init; }
    public required string Email { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required DateTime ModifiedAt { get; init; }
}