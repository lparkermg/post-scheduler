using System.Threading.Tasks;
using ps_entities;

namespace ps_adaptors.Interfaces
{
    public interface IAdaptor
    {
        PostLocations PostLocation { get; }
        Task<bool> Post(PostData data);
    }
}