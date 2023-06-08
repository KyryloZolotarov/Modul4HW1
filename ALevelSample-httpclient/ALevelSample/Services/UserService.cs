using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ALevelSample.Config;
using ALevelSample.Dtos;
using ALevelSample.Dtos.Requests;
using ALevelSample.Dtos.Responses;
using ALevelSample.Models;
using ALevelSample.Services.Abstractions;

namespace ALevelSample.Services;

public class UserService : IUserService
{
    private readonly IInternalHttpClientService _httpClientService;
    private readonly ILogger<UserService> _logger;
    private readonly ApiOption _options;
    private readonly string _userApi = "api/users";

    public UserService(
        IInternalHttpClientService httpClientService,
        IOptions<ApiOption> options,
        ILogger<UserService> logger)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _options = options.Value;
    }

    public async Task<User> GetUserById(int id)
    {
        var response =
                await _httpClientService.SendAsync<GetUserResponse, object>($"{_options.Host}{_userApi}/{id}", HttpMethod.Get);

        if (response != null)
        {
            _logger.LogInformation($"User with id = {response.Id} was found");
            return new User()
            {
                Id = response.Id,
                Email = response.Email,
                FirstName = response.FirstName,
                LastName = response.LastName,
                Avatar = response.Avatar
            };
        }

        _logger.LogInformation($"User with id = {response.Id} was not found");
        return null;
    }

    public async Task<CollectionData<User>> GetUsersByPage(int page)
    {
        var response =
        await _httpClientService.SendAsync<GetUserListResponse, object>($"{_options.Host}{_userApi}/?page={page}", HttpMethod.Get);

        if (response != null)
        {
            _logger.LogInformation($"List of users on page {response?.Page} was found");
            return new CollectionData<User>()
            {
                Data = response.Data.Select(s => new User
                {
                    Id = s.Id,
                    Email = s.Email,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Avatar = s.Avatar
                }).ToList()
            };
        }

        _logger.LogInformation($"User with id = {response?.Page} was not found");
        return null;
    }

    public async Task<EmployedUser> CreateEmpoyedUser(string name, string job)
    {
        var response =
            await _httpClientService.SendAsync<CreateUserResponse, CreateUserRequest>($"{_options.Host}{_userApi}", HttpMethod.Post);

        if (response != null)
        {
            _logger.LogInformation($"User with id = {response.Id} was created");
            return new EmployedUser()
            {
                Job = response.Job,
                Name = response.Name,
                CreatedAt = response.CreatedAt.ToString()
            };
        }

        _logger.LogInformation($"User with id = {response.Id} creation faild");
        return null;
    }

    public async Task<EmployedUser> UpdateEmployedUser(int id, string name, string job)
    {
        var response =
            await _httpClientService.SendAsync<UpdateUserResponse, UpdateUserRequest>($"{_options.Host}{_userApi}/{id}", HttpMethod.Put);

        if (response != null)
        {
            _logger.LogInformation($"Update information of user id = {id} success");
            return new EmployedUser()
            {
                Job = response.Job,
                Name = response.Name,
                UpdatedAt = response.UpdatedAt.ToString()
            };
        }

        _logger.LogInformation($"Update information of user id = {id} faild");
        return null;
    }

    public async Task<EmployedUser> ModifyEmployedUser(int id, string name, string job)
    {
        var response =
            await _httpClientService.SendAsync<UpdateUserResponse, UpdateUserRequest>($"{_options.Host}{_userApi}/{id}", HttpMethod.Patch);

        if (response != null)
        {
            _logger.LogInformation($"Modify information of user id = {id} success");
            return new EmployedUser()
            {
                Job = response.Job,
                Name = response.Name,
                UpdatedAt = response.UpdatedAt.ToString()
            };
        }

        _logger.LogInformation($"Modify information of user id = {id} faild");
        return null;
    }

    public async Task RemoveUser(int id)
    {
        var response =
            await _httpClientService.SendAsync<object, object>($"{_options.Host}{_userApi}/{id}", HttpMethod.Delete);
        _logger.LogInformation($"User with id = {id} removed successful");
    }
}