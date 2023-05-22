using Microsoft.Extensions.Logging;
using Sat.Recruitment.Api.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sat.Recruitment.Api.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly string _filePath;

        public UserRepository(ILogger<UserRepository> logger)
        {
            _filePath = Directory.GetCurrentDirectory() + "/Files/Users.txt";
            _logger = logger;
        }
        public void Add(User user)
        {
            user.Id = GenerateValidId();
            WriteFile(user, true);
        }

        public IEnumerable<User> GetAll()
        {
            var users = new List<User>();
            if (File.Exists(_filePath))
            {
                string[] lines = File.ReadAllLines(_filePath);
                foreach (string line in lines)
                {
                    string[] ln = line.Split(',');
                    User user = new User
                    {
                        Id = int.Parse(ln[0]),
                        Name = ln[1],
                        Email = ln[2],
                        Phone = ln[3],
                        Address = ln[4],
                        UserType = ln[5],
                        Money = Convert.ToDecimal(ln[6])
                    };
                    users.Add(user);
                }
            }
            return users;
        }

        public User GetById(int id)
        {
            return GetAll().FirstOrDefault(u => u.Id == id);
        }

        public void Remove(User user)
        {
            try
            {
                var users = GetAll().ToList();
                if (user != null)
                {
                    var index = users.FindIndex(u => u.Id == user.Id);
                    users.RemoveAt(index);
                    SaveUsers(users);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error trying to delete user with id: {user.Id}");
            }
        }

        public void Update(User user)
        {
            try
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

                var users = GetAll().ToList();
                var index = users.FindIndex(u => u.Id == user.Id);
                if (index != -1)
                    users[index] = user;

                SaveUsers(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error trying to user with id: {user.Id}");
            }
        }

        private int GenerateValidId()
        {
            List<User> lstUsers = GetAll().ToList();
            var lastUser = lstUsers.Last();
            return lastUser.Id + 1;

        }

        private void WriteFile(User user, bool isNewUser = false)
        {
            string userData = $"{user.Id},{user.Name},{user.Email},{user.Address},{user.Phone},{user.UserType},{user.Money}";
            File.AppendAllText(_filePath, userData + Environment.NewLine);
        }

        private void SaveUsers(List<User> users)
        {
            File.WriteAllText(_filePath, string.Empty);
            foreach (User user in users)
            {
                WriteFile(user);
            }
        }
    }
}
