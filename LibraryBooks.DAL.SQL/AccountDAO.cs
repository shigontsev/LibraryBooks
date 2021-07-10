using LibraryBooks.DAL.Interfaces;
using LibraryBooks.Entities;
using LibraryBooks.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.DAL.SQL
{
    public class AccountDAO : IAccountDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public void Create(string login, string password, User userInfo)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AuthData GetAuthDataByLogin(string login)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "AuthData_GetByLogin";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                //string hashPass = Hasher.HashPassword(password);
                command.Parameters.AddWithValue("@Login", login);
                //command.Parameters.AddWithValue("@HashPass", hashPass);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new AuthData(
                        id: (int)reader["Id"],
                        login: (string) reader["Login"],
                        hashPassword: (string) reader["HashPass"]
                        );
                }
                return null;
            }
        }

        public IEnumerable<AuthData> GetLogins()
        {
            throw new NotImplementedException();
        }

        public bool IsAuthentication(string login, string password)
        {
            var accountData = GetAuthDataByLogin(login);
            if (accountData !=null)
            {
                return Hasher.VerifyHashedPassword(accountData.HashPassword, password);
            }
            return false;
        }
    }
}
