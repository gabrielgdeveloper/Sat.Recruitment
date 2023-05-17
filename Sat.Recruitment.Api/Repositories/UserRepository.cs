using Sat.Recruitment.Api.Model;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserRepository(List<User> users)
        {
            _users = users;
        }
        public void Add(User user)
        {
            _users.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public void Remove(User user)
        {
            _users.Remove(user);
        }

        public void Update(User user)
        {
            var currentUser = GetById(user.Id);
            if (currentUser != null)
            {
                currentUser.Name = user.Name;
                currentUser.Email = user.Email;
                currentUser.Address = user.Address;
                currentUser.Phone = user.Phone;
                currentUser.UserType = user.UserType;
                currentUser.Money = user.Money;
            }
        }
    }
}
