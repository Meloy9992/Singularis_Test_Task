using Microsoft.AspNetCore.Mvc;
using Singularis_Test_Task.Models;
using Singularis_Test_Task.Services;
using System.Net;
using System.Web.Http;

namespace Singularis_Test_Task.DAO.Implements
{
    public class UserDaoImpl : IUserDao
    {

        private static List<User> users = new List<User>(new[]
        {
            new User(0L ,"qwerty1@yandex.ru", "Игорь",  "Иванов",  "20 августа 1900",
              "123456789", "Москва, Ленинский проспект"),

            new User(1L ,"qwerty2@yandex.ru", "Игорь",  "Иванов",  "20 августа 1900"
             , "123456789", "Москва, Ленинский проспект"),

            new User(2L ,"qwerty1@yandex.ru", "Игорь",  "Иванов",  "20 августа 1900"
             , "123456789", "Москва, Ленинский проспект")
        });

        public void createUser(User user)
        {

            users.Add(user);
        }

        public HttpStatusCode deleteUserById(long id)
        {
            var user = users.SingleOrDefault(u => u.id == id);
            if (user == null)
            {
               return HttpStatusCode.NotFound;
            }

            users.Remove(user);

            return HttpStatusCode.OK;
        }

        public List<User> getBriefInformation()
        {
           // users.SingleOrDefault(u => new User)
            throw new NotImplementedException();
        }

        public User getUserById(long id)
        {
            throw new NotImplementedException();
        }

        public void updateUserById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
