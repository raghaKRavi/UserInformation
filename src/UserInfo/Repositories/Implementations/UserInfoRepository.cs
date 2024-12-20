using System.Collections;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using UserInfo.Data;
using UserInfo.Errors;
using UserInfo.Models;
using UserInfo.Models.Entities;

namespace UserInfo.Repositories.Implementations;

public class UserInfoRepository(AppDbContext dbContext, IMapper mapper) : IUserInfoRepository
{
    private readonly AppDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task CreateUserAsync(UserInfoDto userInfoDto)
    {
        var entity = _mapper.Map<UserInfoEntity>(userInfoDto);
        _dbContext.Set<UserInfoEntity>().Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateUserInfo(UpdateUserInfoDto updateUserInfo, int id)
    {
        var toUpdate = await _dbContext.UserInfo.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (toUpdate is null)
        {
            throw new NotFoundException("User info not found");
        }

        var entity = _mapper.Map<UserInfoEntity>(updateUserInfo);
        
        _dbContext.Entry(toUpdate).CurrentValues.SetValues(updateUserInfo);
        
        // var entity = _mapper.Map<UserInfoEntity>(updateUserInfo);
        //
        // _dbContext.UserInfo.Update(entity);
        await  _dbContext.SaveChangesAsync();
    }

    public async Task<UserInfoDto?> GetById(int id)
    {
        var entity = await _dbContext.Set<UserInfoEntity>()
            .FirstOrDefaultAsync(x => x.Id == id);
        return entity is null ? null : _mapper.Map<UserInfoDto>(entity);
    }

    public async Task<UserInfoDto?> GetByEmail(string email)
    {
        var entity = await _dbContext.Set<UserInfoEntity>()
            .FirstOrDefaultAsync(x => x.Email == email);
        return entity == null ? null : mapper.Map<UserInfoDto>(entity);
    }

    public async Task<IList<UserInfoDto>> GetAll()
    {
        var entities = await _dbContext.Set<UserInfoEntity>().ToListAsync();
        return _mapper.Map<IList<UserInfoDto>>(entities);

    }

    public async Task<bool> IsExistWithId(int id)
    {
        return await _dbContext.UserInfo.Where(x => x.Id == id).AnyAsync();
    }
}