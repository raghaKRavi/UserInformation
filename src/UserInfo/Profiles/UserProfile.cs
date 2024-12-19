using AutoMapper;

using UserInfo.Data;
using UserInfo.Models;

namespace UserInfo.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserInfoDto, UserInfoEntity>().ReverseMap();
    }
}