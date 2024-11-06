using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task Add(User user)
        {
            await UserDAO.Instance.Add(user);
        }

        public async Task Delete(int id)
        {
            await UserDAO.Instance.Delete(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await UserDAO.Instance.GetUserAll();
        }

        public async Task<User> GetUserById(int id)
        {
            return await UserDAO.Instance.GetUserById(id);
        }

        public async Task Update(User user)
        {
            await UserDAO.Instance.Update(user);
        }
    }
}
