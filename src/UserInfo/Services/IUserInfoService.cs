using UserInfo.Models.Requests;
using UserInfo.Models.Responses;

namespace UserInfo.Services;

public interface IUserInfoService
{
    Task CreateUser(UserInfoRequest request);
    
    Task<UserInfoResponse> UpdateUserInfo(UserInfoRequest request);
    
    Task<UserInfoResponse> GetUserById(int id);
    
    Task<List<UserInfoResponse>> GetAll();
}