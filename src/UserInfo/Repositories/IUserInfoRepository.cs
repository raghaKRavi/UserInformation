using UserInfo.Models;

namespace UserInfo.Repositories;

public interface IUserInfoRepository
{
    Task CreateUserAsync(UserInfoDto userInfoDto);
    
    Task<UserInfoDto> UpdateById(int id);
    
    Task<UserInfoDto> GetById(int id);

    Task<IList<UserInfoDto>> GetAll();
}