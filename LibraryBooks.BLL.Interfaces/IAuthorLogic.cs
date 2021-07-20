using LibraryBooks.Entities;
using System.Collections.Generic;

namespace LibraryBooks.BLL.Interfaces
{
    public interface IAuthorLogic
    {
        IEnumerable<Author> GetAll();

        void Add(string fullName);

        void Edit(Author author);

        Author GetById(int id);

        Author GetByFullName(string fullName);

        void Delete(int id);

        bool Exist(string fullName);
    }
}
