using Singularis_Test_Task.Models;
using System.Net;

namespace Singularis_Test_Task.Services
{
    public interface IUserService
    {
        public List<User> getBriefInformation();

        public User getUserById(long id);

        public void updateUserById(long id, User user);

        public HttpStatusCode deleteUserById(long id);

        public void createUser(User user);

        public long GetLastUsersIndex();
    }
}
