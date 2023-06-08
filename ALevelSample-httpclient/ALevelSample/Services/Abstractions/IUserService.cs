using System.Threading.Tasks;
using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions;

public interface IUserService
{
    public Task<User> GetUserById(int id);

    public Task<CollectionData<User>> GetUsersByPage(int page);

    public Task<EmployedUser> CreateEmpoyedUser(string name, string job);

    public Task<EmployedUser> UpdateEmployedUser(int id, string name, string job);

    public Task<EmployedUser> ModifyEmployedUser(int id, string name, string job);

    public Task RemoveUser(int id);
}