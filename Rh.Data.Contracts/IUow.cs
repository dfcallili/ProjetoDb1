using System.Threading.Tasks;

namespace Rh.Data.Contracts
{
    public interface IUow
    {
        void Commit();

        Task<int> CommitAsync();
    }
}
