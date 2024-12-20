namespace UserInfo.Models;

public record UpdateUserInfoDto( string Email,
    string FirstName,
    string LastName,
    DateOnly Dob,
    string? PhoneNumber,
    string? Address)
{
    
}