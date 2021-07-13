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
    public class AuthorsAndBooksDAO : IAuthorsAndBooksDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public bool ExistBooks(int authorId)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "AuthorsAndBooks_ExistBooks";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AuthorId", authorId);
                _connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                    return true;
                return false;
            }
        }

        public IEnumerable<Book> GetBooksByAuthorId(int authorId)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "AuthorsAndBooks_GetBooksByAuthorId";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AuthorId", authorId);
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
    }
}
