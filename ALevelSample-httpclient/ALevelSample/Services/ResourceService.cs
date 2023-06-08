using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ALevelSample.Config;
using ALevelSample.Dtos.Responses;
using ALevelSample.Dtos;
using ALevelSample.Models;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ALevelSample.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<UserService> _logger;
        private readonly ApiOption _options;
        private readonly string _resourceApi = "api/unknown";

        public ResourceService(
        IInternalHttpClientService httpClientService,
        IOptions<ApiOption> options,
        ILogger<UserService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<Resource> GetResourceById(int id)
        {
            var response =
        await _httpClientService.SendAsync<GetResourceResponse, object>($"{_options.Host}{_resourceApi}/{id}", HttpMethod.Get);
            if (response.Data != null)
            {
                _logger.LogInformation($"Resource with id = {id} was found");
                return new Resource()
                {
                    Id = response.Data.Id,
                    Name = response.Data.Name,
                    Year = response.Data.Year,
                    Color = response.Data.Color,
                    PantoneValue = response.Data.PantoneValue
                };
            }

            _logger.LogInformation($"Resource with id = {id} was not found");
            return null;
        }

        public async Task<CollectionData<Resource>> GetResources()
        {
            var response =
                await _httpClientService.SendAsync<GetListResourceResponse, object>($"{_options.Host}{_resourceApi}", HttpMethod.Get);
            if (response != null)
            {
                _logger.LogInformation("Resources were found");
                return new CollectionData<Resource>()
                {
                    Data = response.Data.Select(s => new Resource()
                    {
                        Color = s.Color,
                        Name = s.Name,
                        Id = s.Id,
                        PantoneValue = s.PantoneValue,
                        Year = s.Year
                    }).ToList()
                };
            }

            _logger.LogInformation("Resources were not found");
            return null;
        }
    }
}
