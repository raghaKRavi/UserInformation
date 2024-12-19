namespace UserInfo.Models;

public record UserInfoDto(
    int Id,
    string Email,
    string FirstName,
    string LastName,
    DateOnly Dob,
    string? Phone,
    string? Address,
    DateTime CreatedAt,
    DateTime ModifiedAt
);