using UserInfo.Models;

namespace UserInfo.Repositories;

public interface IUserInfoRepository
{
    Task CreateUserAsync(UserInfoDto userInfoDto);
    
    Task UpdateUserInfo(UpdateUserInfoDto userInfoDto, int id);
    
    Task<UserInfoDto?> GetById(int id);
    
    Task<UserInfoDto?> GetByEmail(string email);

    Task<IList<UserInfoDto>> GetAll();

    Task<bool> IsExistWithId(int id);
}