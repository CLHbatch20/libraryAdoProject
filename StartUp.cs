using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Ado.Net
{
    public class StartUp
    {
        private readonly string _connectionString = "Server=localhost;User=root;Database = LibraryDb; password=123456789";


        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
        public void CreateDb()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var qry = "CREATE DATABASE IF NOT EXISTS LibraryDb";
                    using (var command = new MySqlCommand(qry, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Creating LibraryDb " + ex.Message);
            }
        }
        public void CreateUserTable()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var qry = @"CREATE TABLE users(
                                FullName varchar(35) not null,
                                Email varchar(36) not null,
                                Password varchar(35) not null,
                                Role varchar(35) not null,
                                Gender varchar(36) not null,
                                Primary Key(Email)
                               )
                               ";
                    using (var command = new MySqlCommand(qry, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Creating User Table" + ex.Message);
            }

        }
        public void CreateBookTable()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var qry = @"Create Table Book (
                                Title varchar(35) not null,
                                Author varchar(35) not null,
                                ISBN varchar(35) not null,
                                Quantity int(25) not null,
                                Primary Key(ISBN)
                                
                    )";
                    using (var command = new MySqlCommand(qry, connection))
                    {
                            connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Creating Book Table" + ex.Message);
            }
        }
        public void CreateStudentTable()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var qry = @"Create Table Student(
                             StudentEmail varchar(36) not null,
                             AdmissionNo varchar(35) not null,
                             Foreign Key (StudentEmail) References users(Email),
                             Unique (AdmissionNo) 
                    )
                    ";
                    using (var command = new MySqlCommand(qry, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Creating Student Table " + ex.Message);
            }
        }


        public void CreateCategoryTable()
        {
            try
            {

                using (var connection = new MySqlConnection(_connectionString))
                {
                    var qry = @"Create Table Category(
                      Name varchar(36),
                      Description varchar(36),
                      Primary Key (Name)     
                )";
                    using (var command = new MySqlCommand(qry, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Creating Category Table " + ex.Message);
            }
        }

        public void CreateBorrowTable()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var query = @"CREATE TABLE Borrow (
                           StudentEmail varchar(36) not null,
                           BookName varchar(37) not null,
                           DateBorrowed Date not null,
                           DateReturned Date not null,
                           Foreign Key (StudentEmail) REFERENCES users(Email),
                           Unique (BookName)
                    )";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Creating Borrow Table " + ex.Message);
            }
        }
    }
}