using Sat.Recruitment.Api.Model;
using Sat.Recruitment.Api.Repositories;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.UnitOfWork
{
    public class UnitOfWork
    {
        private readonly List<User> _users;
        private IUserRepository _userRepository;

        public UnitOfWork(List<User> users)
        {
            _users = users;
        }

        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_users);
                }
                return _userRepository;
            }
        }
    }
}
