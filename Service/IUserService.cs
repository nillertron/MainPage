using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        Task<bool> IsLoggedIn();
        Task Login(string userName, string password);
        Task LoginFromCookie(string userName);
    }
}