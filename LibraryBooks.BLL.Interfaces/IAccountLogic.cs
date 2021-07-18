using LibraryBooks.Entities;

namespace LibraryBooks.BLL.Interfaces
{
    public interface IAccountLogic
    {
        void Create(string login, string password, User userInfo);

        void Delete(int id);

        bool IsAuthentication(string login, string password);

        AuthData GetAuthDataByLogin(string login);

        bool Exist(string login);
    }
}
