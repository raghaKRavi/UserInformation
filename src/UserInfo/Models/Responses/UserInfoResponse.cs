namespace UserInfo.Models.Responses;

public record UserInfoResponse(
    int? Id,
    string Name,
    string Email,
    int Age,
    DateOnly Dob,
    string Address,
    string PhoneNumber,
    DateTime? UpdatedAt
    );