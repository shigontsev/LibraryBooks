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

        public string SurName { get; private set; }

        public string FirstName { get; private set; }

        public string SecondName { get; private set; }

        public string FullName => String.Format($"{SurName} {FirstName} {SecondName}");

        public string ShortFullName => String.Format($"{SurName} {FirstName[0]}. {SecondName[0]}.");

        public DateTime DateOfBirth { get; private set; }

        public int Age => DateTime.Now.Year - DateOfBirth.Year;

        public string Phone { get; private set; }

        public User(string surName, string firstName, string secondName, DateTime dateOfBirth, string phone)
        {
            if (string.IsNullOrWhiteSpace(surName))
                throw new ArgumentNullException(nameof(surName), string.Format($"{nameof(surName)} will be not is empty"));
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException(nameof(firstName), string.Format($"{nameof(firstName)} will be not is empty"));
            if (string.IsNullOrWhiteSpace(secondName))
                throw new ArgumentNullException(nameof(secondName), string.Format($"{nameof(secondName)} will be not is empty"));

            SurName = surName;
            FirstName = firstName;
            SecondName = secondName;
            DateOfBirth = dateOfBirth;
            Phone = phone ?? throw new ArgumentNullException(nameof(phone), string.Format($"{nameof(phone)} will be not is empty"));
        }

        public User(int userId, string surName, string firstName, string secondName, DateTime dateOfBirth, string phone) : this(surName, firstName, secondName, dateOfBirth, phone)
        {
            UserId = userId;
        }

        public void Edit(string surName, string firstName, string secondName, DateTime dateOfBirth, string phone)
        {
            if (string.IsNullOrWhiteSpace(surName))
                throw new ArgumentNullException(nameof(surName), string.Format($"{nameof(surName)} will be not is empty"));
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException(nameof(firstName), string.Format($"{nameof(firstName)} will be not is empty"));
            if (string.IsNullOrWhiteSpace(secondName))
                throw new ArgumentNullException(nameof(secondName), string.Format($"{nameof(secondName)} will be not is empty"));

            SurName = surName;
            FirstName = firstName;
            SecondName = secondName;
            DateOfBirth = dateOfBirth;
            Phone = phone ?? throw new ArgumentNullException(nameof(phone), string.Format($"{nameof(phone)} will be not is empty"));
        }
    }
}
