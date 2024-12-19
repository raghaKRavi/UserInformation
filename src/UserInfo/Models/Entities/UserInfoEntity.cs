using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserInfo.Data;

[Table("UserInfo")]
public class UserInfoEntity
{
    public int Id { get; init; }
    
    [Column(TypeName = "varchar")]
    public required string Email { get; init; }
    
    [Column(TypeName = "varchar")]
    [MinLength(2)]
    public required string FirstName { get; init; }
    
    [Column(TypeName = "varchar")]
    [MinLength(2)]
    public required string LastName { get; init; }
    
    [Column(TypeName = "date")]
    public required DateOnly Dob { get; init; }
    
    public string? PhoneNumber { get; init; }
    
    [Column(TypeName = "text")]
    public string? Address { get; init; }
    
    public required DateTime CreatedAt { get; init; }
    
    public required DateTime ModifiedAt { get; init; }
}