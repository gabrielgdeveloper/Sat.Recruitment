using Sat.Recruitment.Api.Model;
using Sat.Recruitment.Api.Repositories;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void Remove(User user)
        {
            _userRepository.Remove(user);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }
    }
}
