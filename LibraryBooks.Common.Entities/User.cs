using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Entities
{
    public class User
    {

        public int UserId { get; private set; }

        public string FullName { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public string Phone { get; private set; }

        public User(string fullName, DateTime dateOfBirth, string phone)
        {
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName), string.Format($"{nameof(fullName)} will be not is exist"));
            DateOfBirth = dateOfBirth;
            Phone = phone ?? throw new ArgumentNullException(nameof(phone), string.Format($"{nameof(phone)} will be not is exist"));
        }

        public User(int userId, string fullName, DateTime dateOfBirth, string phone) : this(fullName, dateOfBirth, phone)
        {
            UserId = userId;
        }
    }
}
