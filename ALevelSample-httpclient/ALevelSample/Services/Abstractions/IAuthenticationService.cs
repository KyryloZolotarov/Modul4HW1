using System.Threading.Tasks;
using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions
{
    public interface IAuthenticationService
    {
        public Task<LoginResult> Login(string login, string password);

        public Task<RegisterResult> Register(string login, string password);
    }
}
