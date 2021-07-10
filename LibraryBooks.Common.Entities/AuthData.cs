using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Entities
{
    public class AuthData
    {
        public int Id { get; private set; }

        public string Login { get; private set; }

        public string HashPassword { get; private set; }

        //public string Password { get; set; }
    }
}
