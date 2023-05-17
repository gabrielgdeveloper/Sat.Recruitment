using Sat.Recruitment.Api.Model;
using Sat.Recruitment.Api.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(User user)
        {
            _unitOfWork.Users.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.Users.GetAll();
        }

        public User GetById(int id)
        {
            return _unitOfWork.Users.GetById(id);
        }

        public void Remove(User user)
        {
            _unitOfWork.Users.Remove(user);
        }

        public void Update(User user)
        {
            _unitOfWork.Users.Update(user);
        }
    }
}
