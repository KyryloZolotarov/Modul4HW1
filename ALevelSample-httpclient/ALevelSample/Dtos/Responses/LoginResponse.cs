using Newtonsoft.Json;

namespace ALevelSample.Dtos.Responses
{
    public class LoginResponse : AuthenticationErrorDto
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
