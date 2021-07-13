using LibraryBooks.DAL.Interfaces;
using LibraryBooks.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.DAL.SQL
{
    public class UsersAndBooksDAO : IUsersAndBooksDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public bool Exist(int userId, int bookId)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "UsersAndBooks_Exist";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@BookId", bookId);
                _connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                    return true;
                return false;
            }
        }

        public bool ExistByBookId(int bookId)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "UsersAndBooks_ExistByBookId";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@BookId", bookId);
                _connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                    return true;
                return false;
            }
        }

        public bool ExistByUserId(int userId)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "UsersAndBooks_ExistByUserId";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserId", userId);
                _connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                    return true;
                return false;
            }
        }

        public IEnumerable<Book> GetBooksByUserId(int userId)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "UsersAndBooks_GetBooksByUserId";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserId", userId);
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

        public IEnumerable<Book> GetBooksUnAvailableByUserId(int userId)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "UsersAndBooks_GetBooksUnAvailableByUserId";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserId", userId);
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

        public IEnumerable<User> GetUsersByBookId(int bookId)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "UsersAndBooks_GetUsersByBookId";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@BookId", bookId);
                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User(
                        userId: (int)reader["UserId"],
                        surName: (string)reader["SurName"],
                        firstName: (string)reader["FirstName"],
                        secondName: (string)reader["SecondName"],
                        dateOfBirth: (DateTime)reader["DateOfBirth"],
                        phone: (string)reader["Phone"]
                        );
                }
            }
        }

        public IEnumerable<User> GetUsersUnAvailableByBookId(int bookId)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "UsersAndBooks_GetUsersUnAvailableByBookId";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@BookId", bookId);
                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User(
                        userId: (int)reader["UserId"],
                        surName: (string)reader["SurName"],
                        firstName: (string)reader["FirstName"],
                        secondName: (string)reader["SecondName"],
                        dateOfBirth: (DateTime)reader["DateOfBirth"],
                        phone: (string)reader["Phone"]
                        );
                }
            }
        }

        public void GiveBookToUser(int bookId, int userId)
        {
            if (Exist(userId, bookId))
            {
                throw new InvalidOperationException($"The User ID {userId} has already taken the Book ID = {bookId}");
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "UsersAndBooks_GiveBookToUser";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@BookId", bookId);
                _connection.Open();

                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    throw new InvalidOperationException($"Book ID = {bookId} not gave to User ID {userId}");
                }
            }
        }

        public void ReturnBookByUser(int bookId, int userId)
        {
            if (!Exist(userId, bookId))
            {
                throw new InvalidOperationException($"The User ID {userId} has not already taken the Book ID = {bookId}");
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "UsersAndBooks_ReturnBookByUser";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@BookId", bookId);
                _connection.Open();

                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    throw new InvalidOperationException($"User ID {userId} not returnd of Book ID = {bookId}");
                }
            }
        }
    }
}
