using AutoMapper;

using UserInfo.Data;
using UserInfo.Helpers;
using UserInfo.Models;
using UserInfo.Models.Entities;
using UserInfo.Models.Requests;
using UserInfo.Models.Responses;

namespace UserInfo.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserInfoDto, UserInfoEntity>().ReverseMap();
        CreateMap<UserInfoRequest, UserInfoDto>()
            .ConstructUsing(x => new UserInfoDto(
                null, x.Email, x.FirstName, x.LastName, x.Dob, x.PhoneNumber, x.Address, null, null));
        CreateMap<UserInfoDto, UserInfoResponse>()
            .ConstructUsing(x => new UserInfoResponse(
                    x.Id, 
                    x.FirstName + " " + x.LastName,
                    x.Email,
                    x.Dob.ToAgeString(),
                    x.Dob,
                    x.Address,
                    x.PhoneNumber,
                    x.CreatedAt
                ))
            .ForMember(
                dest => dest.Name,
                src => 
                    src.MapFrom(x => x.FirstName + " " + x.LastName)
            )
            .ForMember(
                dest => dest.Age,
                src => 
                    src.MapFrom(x => x.Dob.ToAgeString())
                );
    }
}