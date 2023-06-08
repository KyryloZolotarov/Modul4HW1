﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace ALevelSample.Dtos.Responses
{
    public class GetUserListResponse
    {
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        public List<UserDto> Data { get; set; }

        public SupportDto Support { get; set; }
    }
}
