using LibraryBooks.DAL.Interfaces;
using LibraryBooks.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace LibraryBooks.DAL.SQL
{
    public class BookDAO : IBookDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public void Add(Book newBook)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Book_Add";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Title", newBook.Title);
                command.Parameters.AddWithValue("@AuthorId", newBook.AuthorId);
                command.Parameters.AddWithValue("@Page", newBook.Page);
                command.Parameters.AddWithValue("@Description", newBook.Description);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format($"Cannot add Book by Title = \'{newBook.Title}\'"));
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Book_DeleteById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format($"Cannot delete Book by Id = \'{id}\'"));
            }
        }

        public void Edit(Book book)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Book_Edit";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", book.Id);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@AuthorId", book.AuthorId);
                command.Parameters.AddWithValue("@Page", book.Page);
                command.Parameters.AddWithValue("@Description", book.Description);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format($"Cannot edit Book by Id = \'{book.Id}\' and by Title = \'{book.Title}\'"));
            }
        }

        public IEnumerable<Book> GetAll()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Book_GetAll";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Book(
                        id: (int)reader["Id"],
                        title: (string)reader["Title"],
                        authorId: (int)reader["AuthorId"],
                        authorFullName: (string)reader["AuthorFullName"],
                        page: (int)reader["Page"],
                        description: (string)reader["Description"]
                        );
                }
            }
        }

        public Book GetById(int id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Book_GetById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Book(
                        id: (int)reader["Id"],
                        title: (string)reader["Title"],
                        authorId: (int)reader["AuthorId"],
                        authorFullName: (string)reader["AuthorFullName"],
                        page: (int)reader["Page"],
                        description: (string)reader["Description"]
                        );
                }
                return null;
            }
        }
    }
}
