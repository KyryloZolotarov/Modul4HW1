using System.Threading.Tasks;
using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions
{
    public interface IResourceService
    {
        public Task<Resource> GetResourceById(int id);

        public Task<CollectionData<Resource>> GetResources();
    }
}
