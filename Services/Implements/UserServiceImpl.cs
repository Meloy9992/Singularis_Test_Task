using Microsoft.AspNetCore.Mvc;
using Singularis_Test_Task.Controllers;
using Singularis_Test_Task.DAO;
using Singularis_Test_Task.Models;
using System.Net;

namespace Singularis_Test_Task.Services.Implements
{
    public class UserServiceImpl : IUserService
    {

        private readonly ILogger<UsersController> _logger;

        private readonly IUserDao _userDao;

        public UserServiceImpl(IUserDao userDao, ILogger<UsersController> logger)
        {
            this._userDao = userDao;
            _logger = logger;
        }

        public void createUser(User user)
        {
            try
            {
                _userDao.createUser(user);

                _logger.LogInformation("User with id {id} created successfully", user.id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed from create User, because: {ex}", ex);
            }
        }

        public HttpStatusCode deleteUserById(long id)
        {
            try
            {
                _userDao.deleteUserById(id);

            }
            catch(Exception ex)
            {
                _logger.LogError("User not deleted because: {ex}", ex);
                return HttpStatusCode.BadRequest;
            }

            return HttpStatusCode.OK;
        }

        public List<UserBrief> getBriefInformation()
        {
            try
            {
                List<UserBrief> users = _userDao.getBriefInformation();

                _logger.LogInformation("Users with Brief information successfully received with count: {count}", users.Count);
                return users;
            }
            catch(Exception ex)
            {
                _logger.LogError("Getting users failed because: {error}", ex);
            }

            return null; // TODO: Подумать какой ответ вернуть вместо null
        }

        public List<User> GetAllInformationUsers()
        {
            return _userDao.GetAllInformationUsers();
        }

        public User getUserById(long id)
        {
            User user = _userDao.getUserById(id);

            if (user == null)
            {
                _logger.LogError("User by id = {id} not exist", id);
                return null;
            }
            _logger.LogInformation("User get by {id}, {user}", id, user.firstName);

            return user;
        }

        public void updateUserById(long id, User user)
        {
            try
            {
                _userDao.updateUserById(id, user);
                _logger.LogInformation("User with id {id} was update", id);
            }
            catch(Exception ex)
            {
                _logger.LogError("User not was upadate, because: {ex}", ex);
            }
            
        }

        public long GetLastUsersIndex()
        {
           return _userDao.GetLastUsersIndex();
        }

        public HttpContent GetUsersExportJson()
        {
            try
            {
                HttpContent content = _userDao.GetUsersExportJson();
                _logger.LogInformation("Export in Json File was successfully");
                return content;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void GetUsersImportJson(IFormFile file)
        {
            try
            {
                _userDao.GetUsersImportJson(file);
                _logger.LogInformation("Import from file {file} was successful", file.FileName);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
