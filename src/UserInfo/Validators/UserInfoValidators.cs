using System.Text.RegularExpressions;

using FluentValidation;

using UserInfo.Models.Requests;

namespace UserInfo.Validators;

public class UserInfoValidators : AbstractValidator<UserInfoRequest>
{
    private const string EmailValidator = @"@.+\.";

    public UserInfoValidators()
    {
        RuleFor((x => x.Email)).NotEmpty().NotNull().Must(x => Regex.IsMatch(x, EmailValidator)).WithMessage("Email is not valid");
        RuleFor((x => x.FirstName)).NotEmpty().NotNull();
        RuleFor((x => x.LastName)).NotEmpty().NotNull();
        RuleFor((x => x.Dob)).NotEmpty().NotNull();
    }
}

public class GetUserInfoByIdValidators : AbstractValidator<GetUserByIdRequest>
{
    public GetUserInfoByIdValidators()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}