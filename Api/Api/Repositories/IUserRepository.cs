using Api.Models;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface IUserRepository
    {
        Task<int> Register(User user, string password);
        Task<string> Login(string userName, string password);
        Task<bool> UserExiste(string userName);
    }
}
