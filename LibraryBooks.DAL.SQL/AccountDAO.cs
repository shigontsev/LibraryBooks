using LibraryBooks.DAL.Interfaces;
using LibraryBooks.Entities;
using LibraryBooks.Helpers;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace LibraryBooks.DAL.SQL
{
    public class AccountDAO : IAccountDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public void Create(string login, string password, User userInfo)
        {
            if (Exist(login))
            {
                throw new ArgumentException(nameof(login), string.Format($"Account with {nameof(login)} = \"{login}\" is exist"));
            }
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "AuthData_Create";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@HashPass", Hasher.HashPassword(password));
                command.Parameters.AddWithValue("@SurName", userInfo.SurName);
                command.Parameters.AddWithValue("@FirstName", userInfo.FirstName);
                command.Parameters.AddWithValue("@SecondName", userInfo.SecondName);
                command.Parameters.AddWithValue("@DateOfBirth", userInfo.DateOfBirth);
                command.Parameters.AddWithValue("@Phone", userInfo.Phone);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format($"Cannot create Account with Login \'{login}\'"));
                if (result == 1)
                    throw new InvalidOperationException(
                        string.Format($"Cannot create UserInfo about Account with Login \'{login}\'"));
                if (result == 2)
                    throw new InvalidOperationException(
                        string.Format($"Cannot assign Role for Account with Login \'{login}\'"));
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "AuthData_DeleteById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format($"Cannot delete Account by Id \'{id}\'"));
            }
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
                command.Parameters.AddWithValue("@Login", login);

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

        public bool Exist(string login)
        {
            return GetAuthDataByLogin(login) != null;
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
