using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public void createUser(User user)
        {
            string commandText = $"INSERT INTO {User.TABLE_NAME} " +
            $"(email, first_name, last_name, date_birthday, phone_number, address) " +
            $"VALUES (@email, @first_name, @last_name, @date_birthday, @phone_number, @address)";

             using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.AddWithValue("email", user.email);
                cmd.Parameters.AddWithValue("first_name", user.firstName);
                cmd.Parameters.AddWithValue("last_name", user.lastName);
                cmd.Parameters.AddWithValue("date_birthday", user.dateBirthday);
                cmd.Parameters.AddWithValue("phone_number", user.phoneNumber);
                cmd.Parameters.AddWithValue("address", user.address);

                 cmd.ExecuteNonQuery();
            }
        }

        public HttpStatusCode deleteUserById(long id)
        {
            string commandText = $"DELETE FROM {User.TABLE_NAME} WHERE id_user = {id}";

            using(var cmd =  new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.AddWithValue("id_user", id);
                cmd.ExecuteNonQuery();
                return HttpStatusCode.OK;
            }
        }

        public List<User> getBriefInformation()
        {

            // TODO: Переделать получение пользователя на сокращенную информацию
            string commandText = $"SELECT * FROM {User.TABLE_NAME}"; // Получение имени ьаблицы и создание строки запроса

            List<User> users = new List<User>(); // Создание пустого списка

            NpgsqlCommand com = new NpgsqlCommand(commandText, connection); // Создание экземпляра объекта NpgsqlCommand
            NpgsqlDataReader reader; // Создание reader'а
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    User user = ReadUsers(reader); // Прочитать Пользователя из бд
                    users.Add(user); // Добавить пользователя в список
                }
                catch(Exception e) 
                {
                    Console.WriteLine(e.Message); // TODO: Добавить логгирование
                }

            }
            connection.Close(); // Закрыть подключение к БД

            return users;
        }

        public User getUserById(long id)
        {
            string commandText = $"SELECT * FROM {User.TABLE_NAME} WHERE id_user = {id}"; // Получение имени таблицы и создание строки запроса

            NpgsqlCommand com = new NpgsqlCommand(commandText, connection); // Создание экземпляра объекта NpgsqlCommand
            NpgsqlDataReader reader; // Создание reader'а
            reader = com.ExecuteReader();
            User user = null;
            while (reader.Read())
            {
                try
                {
                   user = ReadUsers(reader); // Прочитать Пользователя из бд
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); // TODO: Добавить логгирование
                }

            }
            connection.Close(); // Закрыть подключение к БД

            return user;
        }

        public void updateUserById(long id, User user)
        {
            string commandText = $"UPDATE {User.TABLE_NAME} SET email = " +
                $"@email, first_name = @first_name," +
                $"last_name = @last_name, date_birthday = @date_birthday, " +
                $"phone_number = @phone_number, address = @address WHERE id_user = {id}"; // Получение имени таблицы и создание строки запроса

            using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.AddWithValue("id_user", user.id);
                cmd.Parameters.AddWithValue("email", user.email);
                cmd.Parameters.AddWithValue("first_name",user.firstName);
                cmd.Parameters.AddWithValue("last_name", user.lastName);
                cmd.Parameters.AddWithValue("date_birthday", user.dateBirthday);
                cmd.Parameters.AddWithValue("phone_number", user.phoneNumber);
                cmd.Parameters.AddWithValue("address", user.address);

                cmd.ExecuteNonQuery();
            }
        }

        private static User ReadUsers(NpgsqlDataReader reader)
        {
            long? id = reader["id_user"] as long?; // прочесть параметр id
            string? email = reader["email"] as string; // прочесть параметр email
            string? firstName = reader["first_name"] as string; // прочесть параметр first_name
            string? lastName = reader["last_name"] as string; // прочесть параметр last_name
            string? dateBirthday = reader["date_birthday"] as string; // прочесть параметр date_birthday
            string? phoneNumber = reader["phone_number"] as string; // прочесть параметр phone_number
            string? address = reader["address"] as string; // прочесть параметр address

            User user = new()
            {
                id = id.Value,
                email = email,
                firstName = firstName,
                lastName = lastName,
                dateBirthday = dateBirthday,
                phoneNumber = phoneNumber,
                address = address
            }; // Присвоение объекту User полей
            return user;
        }

        public long GetLastUsersIndex()
        {
            // TODO: Подумать как можно переделать получение последнего индекса объекта
            
            string commandText = $"SELECT last_value FROM {User.SEQUENCE_NAME}";

            NpgsqlCommand com = new NpgsqlCommand(commandText, connection); // Создание экземпляра объекта NpgsqlCommand
            NpgsqlDataReader reader; // Создание reader'а
            reader = com.ExecuteReader();
            long last_index = 0l;
            while (reader.Read())
            {
                try
                {
                    last_index  = (long) reader["last_value"];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); // TODO: Добавить логгирование
                    connection.Close(); // Закрыть подключение к БД
                }

            }
            connection.Close(); // Закрыть подключение к БД

            return last_index;
        }
    }

}
