using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserInfo.Data;

[Table("UserInfo")]
public class UserInfo
{
    public int Id { get; init; }
    
    public required int UserId { get; init; }
    
    [Column(TypeName = "varchar")]
    [MinLength(2)]
    public required string FirstName { get; init; }
    
    [Column(TypeName = "varchar")]
    [MinLength(2)]
    public required string LastName { get; init; }
    
    [Column(TypeName = "date")]
    public required DateTime Dob { get; init; }
    
    public string? PhoneNumber { get; init; }
    
    [Column(TypeName = "text")]
    public string? Address { get; init; }
    
    public DateTime ModifiedAt { get; init; }
}