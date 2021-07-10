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
    public class UsersAndRolesDAO : IUsersAndRolesDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        public IEnumerable<UserAndRole> GetAll()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "UsersAndRoles_GetAll";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                _connection.Open();

                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    yield return new UserAndRole(
                        userId: (int)reader["UserId"],
                        roleId: (int)reader["URoleId"],
                        userLogin: (string)reader["UserLogin"],
                        roleName: (string)reader["RoleName"]
                        );
                }
            }
        }

        public UserAndRole GetByLogin(string login)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "UsersAndRoles_GetByLogin";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Login", login);
                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new UserAndRole(
                        userId: (int)reader["UserId"],
                        roleId: (int)reader["URoleId"],
                        userLogin: (string)reader["UserLogin"],
                        roleName: (string)reader["RoleName"]
                        );
                }
                return null;
            }
        }
    }
}
