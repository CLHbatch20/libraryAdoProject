using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Application.Interfaces.Repositories;
using Ado.Net.Core.Domain.Entities;
using Ado.Net.Core.Domain.Enums;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace Ado.Net.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        StartUp startUp = new StartUp();
        public User Add(User user)
        {
            using (var connection = new MySqlConnection())
            {
                startUp.CreateConnection().Open();
                var sql = $"Insert into Usertable values ('{user.FullName}','{user.Email}', '{user.PassWord}', '{user.Role}', '{user.Gender}')";
                using (var command = new MySqlCommand(sql, connection))
                {
                    var userAdded = command.ExecuteNonQuery();
                    if (userAdded > 0)
                    {
                        return user;
                    }
                    return null;
                }
            }
        }

        public User Delete(string email)
        {
            User user = null;
            using (var connection = new MySqlConnection())
            {
                startUp.CreateConnection().Open();
                var sql = $"Delete * from usertable where UserEmail = @email";
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@userEmail", email);
                    int rowAffected = command.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        Console.WriteLine("user Deleted");
                    }
                    else
                    {
                        Console.WriteLine("user not Found");
                    }
                }
            }
            return user;
        }

        public User Get(string email)
        {
            User user = new User();
            using (var connection = new MySqlConnection())
            {
                startUp.CreateConnection().Open();
                var sql = $"Select FullName, Email, Password, Gender from usertable where Email = @email";
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("user detail: ");
                        if (reader.Read())
                        {
                            user = new User
                            {
                                FullName = reader.GetString("FullName"),
                                Email = reader.GetString("email"),
                                PassWord = reader.GetString("password"),
                                Gender = (Gender)Enum.Parse(typeof(Gender), reader.GetString(reader.GetOrdinal("Gender")))

                            };
                        }
                    }
                }
            }
            return user;
        }

        public ICollection<User> GetAll()
        {
            ICollection<User> user = new List<User>();
            using (var connection = new MySqlConnection())
            {
                startUp.CreateConnection().Open();
                var sql = $"Select * from Usertable";
                using (var command = new MySqlCommand(sql, connection))
                {
                    User users = null;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users = new User()
                            {
                                FullName = reader.GetString("FullName"),
                                Email = reader.GetString("email"),
                                PassWord = reader.GetString("password"),
                                Gender = (Gender)Enum.Parse(typeof(Gender), reader.GetString(reader.GetOrdinal("Gender")))

                            };
                            user.Add(users);
                        }
                    }
                }
            }
            return user;
        }
    }
}
