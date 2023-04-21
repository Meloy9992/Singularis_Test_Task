﻿using Singularis_Test_Task.DAO;
using Singularis_Test_Task.Models;
using System.Net;

namespace Singularis_Test_Task.Services.Implements
{
    public class UserServiceImpl : IUserService
    {

        private readonly IUserDao _userDao;

        public UserServiceImpl(IUserDao userDao)
        {
            this._userDao = userDao;
        }

        public void createUser(User user)
        {
            _userDao.createUser(user);
        }

        public HttpStatusCode deleteUserById(long id)
        {
            return _userDao.deleteUserById(id);
        }

        public List<User> getBriefInformation()
        {
            return _userDao.getBriefInformation();
        }

        public User getUserById(long id)
        {
            return _userDao.getUserById(id);
        }

        public void updateUserById(long id)
        {
            _userDao.updateUserById(id);
        }
    }
}