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
    public class UserInfoDAO : IUserInfoDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public void Edit(User user)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "UserInfo_Edit";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@SurName", user.SurName);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@SecondName", user.SecondName);
                command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                command.Parameters.AddWithValue("@Phone", user.Phone);
                command.Parameters.AddWithValue("@UserId", user.UserId);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format("Cannot edit UserInfo"));
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "UserInfo_GetAll";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

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

        public User GetById(int id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "UserInfo_GetById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new User(
                        userId: (int)reader["UserId"],
                        surName: (string)reader["SurName"],
                        firstName: (string)reader["FirstName"],
                        secondName: (string)reader["SecondName"],
                        dateOfBirth: (DateTime)reader["DateOfBirth"],
                        phone: (string)reader["Phone"]
                        );
                }
                return null;
            }
        }
    }
}
