using Microsoft.AspNetCore.Mvc;
using Singularis_Test_Task.Models;
using System.Net;

namespace Singularis_Test_Task.Services
{
    public interface IUserService
    {
        public List<UserBrief> getBriefInformation();

        public List<User> GetAllInformationUsers();

        public User getUserById(long id);

        public void updateUserById(long id, User user);

        public HttpStatusCode deleteUserById(long id);

        public void createUser(User user);

        public long GetLastUsersIndex();

        public HttpContent GetUsersExportJson();

        public void GetUsersImportJson();
    }
}
