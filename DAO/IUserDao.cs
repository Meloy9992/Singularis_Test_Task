using Microsoft.AspNetCore.Mvc;
using Singularis_Test_Task.Models;
using System.Net;

namespace Singularis_Test_Task.DAO
{
    public interface IUserDao
    {
        public List<User> getBriefInformation();

        public User getUserById(long id);

        public void updateUserById(long id, User user);

        public HttpStatusCode deleteUserById(long id);

        public void createUser(User user);

        public long GetLastUsersIndex();
    }
}
