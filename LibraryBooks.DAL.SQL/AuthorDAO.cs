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
    public class AuthorDAO : IAuthorDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public void Add(string fullName)
        {
            if (Exist(fullName))
            {
                throw new ArgumentException(nameof(fullName), string.Format($"Author with {nameof(fullName)} = \"{fullName}\" is exist"));
            }
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Author_Add";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@FullName", fullName);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format("Cannot add Author"));
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Author_DeleteById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format("Cannot delete Author"));
            }
        }

        public void Edit(Author author)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Author_Edit";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", author.Id);
                command.Parameters.AddWithValue("@FullName", author.FullName);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format("Cannot edit Author"));
            }
        }

        public bool Exist(string fullName)
        {
            return GetByFullName(fullName) != null; 
        }

        public IEnumerable<Author> GetAll()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Author_GetAll";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Author(
                        id: (int)reader["Id"],
                        fullName: (string)reader["FullName"]
                        );
                }
            }
        }

        public Author GetByFullName(string fullName)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Author_GetByFullName";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@FullName", fullName);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Author(
                        id: (int)reader["Id"],
                        fullName: (string)reader["FullName"]
                        );
                }
                return null;
            }
        }

        public Author GetById(int id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Author_GetById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Author(
                        id: (int)reader["Id"],
                        fullName: (string)reader["FullName"]
                        );
                }
                return null;
            }
        }
    }
}
