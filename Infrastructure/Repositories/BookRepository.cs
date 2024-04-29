using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Application.Interfaces.Repositories;
using Ado.Net.Core.Domain.Entities;
using MySql.Data.MySqlClient;

namespace Ado.Net.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        StartUp startUp = new StartUp();
        
        public BookRepository()
        {

        }
        public Book Add(Book book)
        {
            startUp.CreateConnection().Open();
            using(var connection =new MySqlConnection())
            {
                var sql = $"Insert into Book (Title, Author, ISBN, Quantity) values('{book.Title}','{book.Author}','{book.Quantity}','{book.ISBN}')";
                using (var command = new MySqlCommand(sql,connection))
                {
                    var bookAdded = command.ExecuteNonQuery();
                    if (bookAdded > 0)
                    {
                        return book;
                    }
                    return null;
                }
            }
        }

        public Book Delete(string ISBN)
        {
            Book book = null;
            using(var connection = new MySqlConnection())
            {
                startUp.CreateConnection().Open();
                var sql = $"Delete * from Book where isbn = @ISBN";
                using(var command = new MySqlCommand(sql,connection))
                {
                    command.Parameters.AddWithValue("@ISBN",ISBN);
                    int rowAffected = command.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                       Console.WriteLine("Book Deleted"); 
                    }
                    else
                    {
                        Console.WriteLine("Book not Found");
                    }
                }
            }
            return book;
        }

        public Book Get(string bookName)
        {
            Book book = null;
            using(var connection = new MySqlConnection())
            {
                startUp.CreateConnection().Open();
                var sql = $"Select Title, Author, Quantity from Book where isbn = @ISBN";
                using(var command = new MySqlCommand(sql,connection))
                {
                    command.Parameters.AddWithValue("@BookName", bookName);
                    using(var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Book detail: ");
                        if (reader.Read())
                        {
                            book = new Book
                            {
                                Title = reader.GetString("Title"),
                                Author = reader.GetString("Author"),
                                Quantity = reader.GetInt32(0)
                            };
                        }
                    }
                }
            }
            return book;
        }

        public ICollection<Book> GetAll()
        {
             ICollection<Book> books = new List<Book>();
            using(var connection = new MySqlConnection())
            {
                startUp.CreateConnection().Open();
                var sql = $"Select * from Book";
                using(var command = new MySqlCommand(sql,connection))
                {
                    
                    using(var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = new Book()
                            {
                                Title = reader.GetString("Title"),
                                Author = reader.GetString("Author"),
                                Quantity = reader.GetInt32(0),
                                ISBN = reader.GetString("ISBN")
                            };
                        }
                    }
                }
            }
            return books;
        }
    }
}