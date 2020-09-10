using DataAcces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Service
{
    public class UserService : IUserService
    {
        private int LoginAttempts;
        private IRepository<MS_User> uRepo;
        private MS_User currentUser;
        private List<MS_User> users;
        public UserService(IRepository<MS_User> userRepo)
        {
            uRepo = userRepo;
            if (users == null)
            {
                var list = uRepo.GetAll().Result;
                users = list.ToList();
            }

        }
        public async Task Login(string userName, string password)
        {
            if (LoginAttempts >= 3)
                throw new Exception("Too many login attempts");

            if (currentUser != null)
            {
                throw new Exception("Already logged in");
            }
            currentUser = users.Where(x => x.UserName.ToLower() == userName.ToLower() && x.Password == password).FirstOrDefault();
            if (currentUser == null)
            {
                LoginAttempts++;
                throw new Exception("Wrong credentials");
            }


        }
        public async Task LoginFromCookie(string userName)
        {
            currentUser = users.Where(x => x.UserName.ToLower() == userName.ToLower()).FirstOrDefault();
        }
        public async Task<bool> IsLoggedIn()
        {
            if (currentUser != null)
                return true;
            else return false;

        }

    }
}
