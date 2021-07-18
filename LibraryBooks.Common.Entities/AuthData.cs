using System;

namespace LibraryBooks.Entities
{
    public class AuthData
    {
        public AuthData(int id, string login, string hashPassword)
        {
            Id = id;
            Login = login ?? throw new ArgumentNullException(nameof(login), string.Format($"{nameof(login)} cannot be is null"));
            HashPassword = hashPassword ?? throw new ArgumentNullException(nameof(hashPassword), string.Format($"{nameof(hashPassword)} cannot be is null"));
        }

        public int Id { get; private set; }

        public string Login { get; private set; }

        public string HashPassword { get; private set; }
    }
}
