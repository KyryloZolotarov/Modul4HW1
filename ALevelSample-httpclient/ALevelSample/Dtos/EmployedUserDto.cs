using Newtonsoft.Json;

namespace ALevelSample.Dtos
{
    public class EmployedUserDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = (string)null;

        [JsonProperty("job")]
        public string Job { get; set; } = (string)null;

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; } = (string)null;

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
    }
}
