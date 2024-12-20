using System.Security.AccessControl;

using AutoMapper;

using UserInfo.Errors;
using UserInfo.Models;
using UserInfo.Models.Requests;
using UserInfo.Models.Responses;
using UserInfo.Repositories;

namespace UserInfo.Services.Implementations;

public class UserInfoService(IUserInfoRepository repository, IMapper mapper) : IUserInfoService
{
    private readonly IUserInfoRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task CreateUser(UserInfoRequest request)
    {
        var exist = await _repository.GetByEmail(request.Email);
        if (exist != null)
        {
            throw new ResourceAlreadyExistException($"User information for the email: {exist.Email} id already exist");
        }
        
        var dto = _mapper.Map<UserInfoDto>(request);
        await _repository.CreateUserAsync(dto);
    }

    public async Task UpdateUserInfo(int id, UserInfoRequest request)
    {
        var updated = _mapper.Map<UpdateUserInfoDto>(request);
        
        await _repository.UpdateUserInfo(updated, id);
    }

    public async Task<UserInfoResponse> GetUserById(int id)
    {
        var dto = await _repository.GetById(id);
        if (dto is null)
        {
            throw new NotFoundException($"The resource for the id: {id} not found");
        }
        return _mapper.Map<UserInfoResponse>(dto);
    }

    public async Task<List<UserInfoResponse>> GetAll()
    {
        var dtos = await _repository.GetAll();
        return _mapper.Map<List<UserInfoResponse>>(dtos);
    }
}