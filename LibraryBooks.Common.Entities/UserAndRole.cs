using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Entities
{
    public class UserAndRole
    {
        public int UserId { get; private set; }

        public string UserLogin { get; private set; }

        public int RoleId { get; private set; }

        public string RoleName { get; private set; }

        public UserAndRole(int userId, int roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        public UserAndRole(int userId, int roleId, string userLogin, string roleName) : this(userId, roleId)
        {
            if (string.IsNullOrWhiteSpace(userLogin))
                throw new ArgumentNullException(nameof(userLogin), string.Format($"{nameof(userLogin)} will be not is empty"));
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentNullException(nameof(roleName), string.Format($"{nameof(roleName)} will be not is empty"));
            UserLogin = userLogin;
            RoleName = roleName;
        }
    }
}
