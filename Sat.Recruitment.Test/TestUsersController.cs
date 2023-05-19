using System;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;

using Sat.Recruitment.Api.Controllers;
using Xunit;
using Moq;
using Sat.Recruitment.Api.Services;
using Sat.Recruitment.Api.Repositories;
using Sat.Recruitment.Api.Model;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class TestUsersController
    {
        private Mock<IRepository<User>> _userRepositoryMock;
        public TestUsersController()
        {
            _userRepositoryMock = new Mock<IRepository<User>>();
        }

        [Fact]
        public void TestGetAllMethod()
        {
            // Arrange
            var _userServiceMock = new UserService(_userRepositoryMock.Object);
            _userRepositoryMock.Setup(repo => repo.GetAll()).Returns(GenerateUsers());

            // Act
            var result = _userServiceMock.GetAll();

            // Assert
            Assert.True(result.ToList().Count == 3);
        }

        [Fact]
        public void TestAddUserMethod()
        {
            // Arrange
            var _userServiceMock = new UserService(_userRepositoryMock.Object);
            var newUser = GenerateUsers().First();

            // Act
            _userServiceMock.Add(newUser);

            // Assert
            _userRepositoryMock.Verify(repo => repo.Add(newUser), Times.Once);
        }

        [Fact]
        public void TestGetByIdMethod()
        {
            // Arrange
            var _userServiceMock = new UserService(_userRepositoryMock.Object);
            var currentUser = GenerateUsers().First();
            _userRepositoryMock.Setup(repo => repo.GetById(currentUser.Id)).Returns(currentUser);

            // Act
            var expected = _userServiceMock.GetById(currentUser.Id);

            // Assert
            Assert.Equal(currentUser, expected);
        }

        [Fact]
        public void TestRemoveUserMethod()
        {
            // Arrange
            var _userServiceMock = new UserService(_userRepositoryMock.Object);
            var currentUser = GenerateUsers().First();

            // Act
            _userServiceMock.Remove(currentUser);

            // Assert
            _userRepositoryMock.Verify(repo => repo.Remove(currentUser), Times.Once);
        }

        [Fact]
        public void TestUpdateUserMethod()
        {
            // Arrange
            var _userServiceMock = new UserService(_userRepositoryMock.Object);
            var currentUser = GenerateUsers().First();

            // Act
            _userServiceMock.Update(currentUser);

            // Assert
            _userRepositoryMock.Verify(repo => repo.Update(currentUser), Times.Once);
        }


        private List<User> GenerateUsers()
        {
            var users = new List<User>();

            User user = new User
            {
                Id = 1,
                Name = "Joe",
                Email = "joe@gmail.com",
                Phone = "1234567890",
                Address = "Fake Av 2323",
                UserType = "SuperUser",
                Money = 500
            };
            User user2 = new User
            {
                Id = 2,
                Name = "Joe2",
                Email = "joe2@gmail.com",
                Phone = "1234567890",
                Address = "Fake Av 2323",
                UserType = "SuperUser",
                Money = 5000
            };
            User user3 = new User
            {
                Id = 3,
                Name = "Joe3",
                Email = "joe3@gmail.com",
                Phone = "1234567890",
                Address = "Fake Av 2323",
                UserType = "SuperUser",
                Money = 50000
            };

            users.Add(user);
            users.Add(user2);
            users.Add(user3);

            return users;
        }
    }
}
