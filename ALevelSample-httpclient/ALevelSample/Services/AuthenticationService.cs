using System.Net.Http;
using System.Threading.Tasks;
using ALevelSample.Config;
using ALevelSample.Dtos.Requests;
using ALevelSample.Dtos.Responses;
using ALevelSample.Models;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ALevelSample.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<UserService> _logger;
        private readonly ApiOption _options;

        public AuthenticationService(
          IInternalHttpClientService httpClientService,
          IOptions<ApiOption> options,
          ILogger<UserService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<LoginResult> Login(string login, string password)
        {
            AuthenticationRequest request = new AuthenticationRequest()
            {
                Email = login,
                Password = password
            };
            var response = await _httpClientService.SendAsync<LoginResponse, AuthenticationRequest>($"{_options.Host}api/login", HttpMethod.Post);
            if (string.IsNullOrEmpty(response.Error))
            {
                _logger.LogInformation("Login sucsesfull = " + response?.Token);
                return new LoginResult() { Token = response.Token };
            }

            _logger.LogInformation("Login failed: " + response.Error);
            return null;
        }

        public async Task<RegisterResult> Register(string login, string password)
        {
            AuthenticationRequest request = new AuthenticationRequest()
            {
                Email = login,
                Password = password
            };
            var response = await _httpClientService.SendAsync<RegisterResponse, AuthenticationRequest>($"{_options.Host}api/register", HttpMethod.Post);
            if (string.IsNullOrEmpty(response.Error))
            {
                _logger.LogInformation("Register sucsesfull = " + response?.Token);
                return new RegisterResult()
                {
                    Id = response.Id,
                    Token = response.Token
                };
            }

            _logger.LogInformation("Registration was failed: " + response.Error);
            return null;
        }
    }
}
