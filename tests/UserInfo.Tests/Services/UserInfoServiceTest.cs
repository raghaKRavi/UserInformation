using AutoMapper;

using Moq;

using UserInfo.Errors;
using UserInfo.Models;
using UserInfo.Models.Requests;
using UserInfo.Models.Responses;
using UserInfo.Repositories;
using UserInfo.Services.Implementations;

namespace UserInfo.Tests.Services;

public class UserInfoServiceTest
{
    private readonly Mock<IUserInfoRepository> _mockRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly UserInfoService _service;
    private readonly UserInfoDto _userInfoDto;
    private readonly UserInfoRequest _request;
    private readonly UserInfoResponse _userInfoResponse;

   public UserInfoServiceTest()
    {
        _mockRepository = new Mock<IUserInfoRepository>();
        _mockMapper = new Mock<IMapper>();
        _service = new UserInfoService(_mockRepository.Object, _mockMapper.Object);

        _userInfoDto = new UserInfoDto(
            1,
            "r@g.com",
            "John",
            "Doe",
            DateOnly.FromDateTime(DateTime.Now),
            "000-000-000",
            "2 ireland",
            DateTime.Now, 
            DateTime.Now
            );

        _request = new UserInfoRequest(
            "r@g.com",
            "John",
            "Doe",
            DateOnly.FromDateTime(DateTime.Now),
            "000-000-000",
            "2 ireland"
            );

        _userInfoResponse = new UserInfoResponse(
            1,
            "John Doe",
            "r@g.com",
            0,
            DateOnly.FromDateTime(DateTime.Now),
            "2 ireland",
            "000-000-000",
            DateTime.Now
            );
    }
   
   [Fact]
   public async Task CreateUser_ShouldSuccess()
   {
       _mockRepository
           .Setup(repo => repo.GetByEmail(_userInfoDto.Email))
           .ReturnsAsync((UserInfoDto?)null);
       
       _mockMapper
           .Setup(mapper => mapper.Map<UserInfoDto>((_request)))
           .Returns(_userInfoDto);
       
       _mockRepository
           .Setup(repo => repo.CreateUserAsync(_userInfoDto));

       await _service.CreateUser(_request);
       
       _mockMapper.Verify(mapper => mapper.Map<UserInfoDto>(_request), Times.AtLeastOnce());
       _mockRepository.Verify(repo => repo.CreateUserAsync(_userInfoDto), Times.Once());
   }
   
   [Fact]
   public async Task CreateUser_ShouldThrowException_WhenUserInfoExist()
   {
       _mockRepository
           .Setup(repo => repo.GetByEmail(_userInfoDto.Email))
           .ReturnsAsync(_userInfoDto);

       var exception = await Assert.ThrowsAsync<ResourceAlreadyExistException>(() => _service.CreateUser(_request));
       
       Assert.Equal(409, exception.StatusCode);
       _mockMapper.Verify(mapper => mapper.Map<UserInfoDto>(_request), Times.Never());
       _mockRepository.Verify(repo => repo.CreateUserAsync(_userInfoDto), Times.Never());
   }

   [Fact]
    public async Task GetByUserIdAsync_ShouldReturnUserInfoResponse_WhenUserInfoNotExist()
    {
        const int userId = 1;

        _mockRepository
            .Setup(repo => repo.GetById(userId))
            .ReturnsAsync(_userInfoDto);

        _mockMapper
            .Setup(mapper => mapper.Map<UserInfoResponse>(_userInfoDto))
            .Returns(_userInfoResponse);

        var actual = await _service.GetUserById(userId);

        Assert.NotNull(actual);
        Assert.Equal(_userInfoResponse.Email, actual.Email);
    }

    [Fact]
    public async Task GetByUserIdAsync_ShouldThrowNotFoundException_WhenUSerIdNotFound()
    {
        const int userId = 35;
        
        _mockRepository
            .Setup(repo => repo.GetById(userId))
            .ReturnsAsync((UserInfoDto?)null);

        var exception = await Assert.ThrowsAsync<NotFoundException>(() => _service.GetUserById(userId));
        
        Assert.Equal($"The resource for the id: {userId} not found", exception.ErrorMessage);
        Assert.Equal(404, exception.StatusCode);
        _mockMapper.Verify(mapper => mapper.Map<UserInfoResponse>(_userInfoDto), Times.Never());
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnListOfUserInfoResponse_WhenResourceAvailable()
    {
        var dtos = new List<UserInfoDto> { _userInfoDto };
        _mockRepository
            .Setup(repo => repo.GetAll())
            .ReturnsAsync(dtos);

        _mockMapper
            .Setup(mapper => mapper.Map<List<UserInfoResponse>>(new List<UserInfoDto> {_userInfoDto}))
            .Returns(new List<UserInfoResponse>{
            _userInfoResponse
        });

        var actual = await _service.GetAll();

        Assert.NotNull(actual);
        Assert.Equal(dtos.Count, actual.Count);
    }
}