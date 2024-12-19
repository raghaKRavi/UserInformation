using System.Collections;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using UserInfo.Data;
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

    public Task<UserInfoDto> UpdateById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserInfoDto> GetById(int id)
    {
        var entity = await _dbContext.Set<UserInfoEntity>()
            .FirstOrDefaultAsync(x => x.Id == id);
        return _mapper.Map<UserInfoDto>(entity);
    }

    public async Task<IList<UserInfoDto>> GetAll()
    {
        var entities = await _dbContext.Set<UserInfoEntity>().ToListAsync();
        return _mapper.Map<IList<UserInfoDto>>(entities);

    }
}