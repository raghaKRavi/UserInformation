namespace UserInfo.Models.Requests;

public record UserInfoRequest(
    string Email,
    string FirstName,
    string LastName,
    DateOnly Dob,
    string? PhoneNumber,
    string? Address
    )
{ }