using AutoMapper;

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
        var dto = _mapper.Map<UserInfoDto>(request);
        await _repository.CreateUserAsync(dto);
    }

    public Task<UserInfoResponse> UpdateUserInfo(UserInfoRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<UserInfoResponse> GetUserById(int id)
    {
        var dto = await _repository.GetById(id);
        return _mapper.Map<UserInfoResponse>(dto);
    }

    public async Task<List<UserInfoResponse>> GetAll()
    {
        var dtos = await _repository.GetAll();
        return _mapper.Map<List<UserInfoResponse>>(dtos);
    }
}