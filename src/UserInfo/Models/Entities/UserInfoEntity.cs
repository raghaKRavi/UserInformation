using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserInfo.Models.Entities;

[Table("user_info")]
public class UserInfoEntity : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; init; }
    
    [Column("email", TypeName = "varchar")]
    public required string Email { get; init; }
    
    [Column("first_name", TypeName = "varchar")]
    [MinLength(2)]
    public required string FirstName { get; init; }
    
    [Column("last_name", TypeName = "varchar")]
    [MinLength(2)]
    public required string LastName { get; init; }
    
    [Column("dob", TypeName = "date")]
    public required DateOnly Dob { get; init; }
    
    [Column("phone_number")]
    public string? PhoneNumber { get; init; }
    
    [Column("address", TypeName = "text")]
    public string? Address { get; init; }
}

public class BaseEntity
{
    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }
    
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}