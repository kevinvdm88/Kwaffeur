using System.Threading.Tasks;

namespace Kwaffeur.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<string> CreateUserAsync(string userName, string password);
    }
}
