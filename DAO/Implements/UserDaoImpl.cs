using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Singularis_Test_Task.Models;
using Singularis_Test_Task.Services;
using System.Net;
using System.Web.Http;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Singularis_Test_Task.DAO.Implements
{
    public class UserDaoImpl : IUserDao
    {
        private NpgsqlConnection connection;

        private const string CONNECTION_STRING =
            "Host=localhost:5432;" +
            "Username=postgres;" +
            "Password=6647;" +
            "Database=Singularis_Test_Task";

        public UserDaoImpl()
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
        }

        public async void createUser(User user)
        {
            string commandText = $"INSERT INTO {User.TABLE_NAME} " +
            $"(id, email, firstName, lastName, dateBirthday, phoneNumber, address) " +
            $"VALUES (@id_user, @email, @first_name, @last_name, @date_birthday, @phone_number, @address)";

            await using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.AddWithValue("id_user", user.id);
                cmd.Parameters.AddWithValue("email", user.email);
                cmd.Parameters.AddWithValue("first_name", user.firstName);
                cmd.Parameters.AddWithValue("last_name", user.lastName);
                cmd.Parameters.AddWithValue("ddate_birthday", user.dateBirthday);
                cmd.Parameters.AddWithValue("phone_number", user.phoneNumber);
                cmd.Parameters.AddWithValue("address", user.address);

                await cmd.ExecuteNonQueryAsync();
            }
        }

        public HttpStatusCode deleteUserById(long id)
        {
/*            var user = users.SingleOrDefault(u => u.id == id);
            if (user == null)
            {
                return HttpStatusCode.NotFound;
            }

            users.Remove(user);
*/
            return HttpStatusCode.OK;
        }

        public List<User> getBriefInformation()
        {
            Console.WriteLine("Начало программы Nachalo programmy");
            string commandText = $"SELECT * FROM {User.TABLE_NAME}";

            List<User> users = new List<User>();

            NpgsqlCommand com = new NpgsqlCommand(commandText, connection);
           // connection.Open();
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    Console.WriteLine("Nachalo");
                    User user = ReadUsers(reader);
                    users.Add(user);
                    Console.WriteLine(user.firstName);
                }
                catch { }

            }
            connection.Close();
            

            return users;
        }

        public User getUserById(long id)
        {
            throw new NotImplementedException();
        }

        public void updateUserById(long id)
        {
            throw new NotImplementedException();
        }

        public static User ReadUsers(NpgsqlDataReader reader)
        {
            long? id = reader["id_user"] as long?;
            string? email = reader["email"] as string;
            string? firstName = reader["first_name"] as string;
            string? lastName = reader["last_name"] as string;
            string? dateBirthday = reader["date_birthday"] as string;
            string? phoneNumber = reader["phone_number"] as string;
            string? address = reader["address"] as string;

            User user = new()
            {
                id = id.Value,
                email = email,
                firstName = firstName,
                lastName = lastName,
                dateBirthday = dateBirthday,
                phoneNumber = phoneNumber,
                address = address
            };
            return user;
        }
    }
}
