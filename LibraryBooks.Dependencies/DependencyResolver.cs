using LibraryBooks.BLL.BLL;
using LibraryBooks.BLL.Interfaces;
using LibraryBooks.DAL.Interfaces;
using LibraryBooks.DAL.SQL;

namespace LibraryBooks.Dependencies
{
    public class DependencyResolver
    {
        #region SINGLETONE

        private static DependencyResolver _instance;

        public static DependencyResolver Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new DependencyResolver();
                }
                return _instance;
            }
        }
        #endregion SINGLETONE

        #region SqlBD
        private IAccountDAO AccountDAO => new AccountDAO();

        public IAccountLogic AccountLogic => new AccountLogic(AccountDAO);

        private IUsersAndRolesDAO UsersAndRolesDAO => new UsersAndRolesDAO();

        public IUsersAndRolesLogic UsersAndRolesLogic => new UsersAndRolesLogic(UsersAndRolesDAO);

        private IUserInfoDAO UserInfoDAO => new UserInfoDAO();

        public IUserInfoLogic UserInfoLogic => new UserInfoLogic(UserInfoDAO);

        private IBookDAO BookDAO => new BookDAO();

        public IBookLogic BookLogic => new BookLogic(BookDAO);

        private IAuthorDAO AuthorDAO => new AuthorDAO();

        public IAuthorLogic AuthorLogic => new AuthorLogic(AuthorDAO);

        private IAuthorsAndBooksDAO AuthorsAndBooksDAO => new AuthorsAndBooksDAO();

        public IAuthorsAndBooksLogic AuthorsAndBooksLogic => new AuthorsAndBooksLogic(AuthorsAndBooksDAO);

        private IUsersAndBooksDAO UsersAndBooksDAO => new UsersAndBooksDAO();

        public IUsersAndBooksLogic UsersAndBooksLogic => new UsersAndBooksLogic(UsersAndBooksDAO);
        #endregion SqlBD
    }
}
