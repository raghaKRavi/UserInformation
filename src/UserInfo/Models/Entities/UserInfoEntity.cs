using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserInfo.Models.Entities;

[Table("UserInfo")]
public class UserInfoEntity : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
}

public class BaseEntity
{
    public DateTime? CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}