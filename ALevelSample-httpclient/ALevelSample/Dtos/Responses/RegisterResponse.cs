using Newtonsoft.Json;

namespace ALevelSample.Dtos.Responses
{
    public class RegisterResponse : AuthenticationErrorDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
