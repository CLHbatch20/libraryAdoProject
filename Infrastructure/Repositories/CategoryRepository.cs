using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Application.Interfaces.Repositories;
using Ado.Net.Core.Domain.Entities;
using MySql.Data.MySqlClient;

namespace Ado.Net.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        StartUp startUp = new StartUp();
        public CategoryRepository()
        {

        }
        public Category Add(Category category)
        {
            using(var connection = new MySqlConnection())
            {
                startUp.CreateConnection().Open();
                var sql = $"Insert into Categories (Name, Description) values ('{category.Name}','{category.Description}')";
                    using (var command = new MySqlCommand(sql,connection))
                {
                    var categoryAdded = command.ExecuteNonQuery();
                    if (categoryAdded > 0)
                    {
                        return category;
                    }
                    return null;
                }
            }
        }

        public Category Delete(string name)
        {
            Category category = null;
            using(var connection = new MySqlConnection())
            {
                startUp.CreateConnection().Open();
                var sql = $"Delete * from Categories where Name = @name";
                using(var command = new MySqlCommand(sql,connection))
                {
                    command.Parameters.AddWithValue("@name",name);
                    int rowAffected = command.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                       Console.WriteLine("Category Deleted"); 
                    }
                    else
                    {
                        Console.WriteLine("category not Found");
                    }
                }
            }
            return category;
        }

        public Category Get(string name)
        {
            Category category = new Category();
            using(var connection = new MySqlConnection())
            {
                startUp.CreateConnection().Open();
                var sql = $"Select Name from Categories where Name = @name";
                using(var command = new MySqlCommand(sql,connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    using(var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Category Book detail: ");
                        if (reader.Read())
                        {
                            category = new Category
                            {
                                Name = reader.GetString("Name"),
                              
                            };
                        }
                    }
                }
            }
            return category;
        }

        public ICollection<Category> GetAll()
        {
            ICollection<Category> categories = new List<Category>();
            using(var connection = new MySqlConnection())
            {
                startUp.CreateConnection().Open();
                var sql = $"Select * from Categories";
                using(var command = new MySqlCommand(sql,connection))
                {
                    Category category = null;
                    using(var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                         category = new Category()
                            {
                                Name = reader.GetString("Name"),
                                Description = reader.GetString("Description"),

                            };
                        }
                    }
                }
            }
            return categories;
        }
    }
}