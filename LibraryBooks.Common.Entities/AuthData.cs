using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Entities
{
    public class AuthData
    {
        public AuthData(int id, string login, string hashPassword)
        {
            Id = id;
            Login = login ?? throw new ArgumentNullException(nameof(login));
            HashPassword = hashPassword ?? throw new ArgumentNullException(nameof(hashPassword));
        }

        public int Id { get; private set; }

        public string Login { get; private set; }

        public string HashPassword { get; private set; }
    }
}
