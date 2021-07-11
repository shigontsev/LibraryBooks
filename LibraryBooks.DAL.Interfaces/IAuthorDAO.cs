using LibraryBooks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.DAL.Interfaces
{
    public interface IAuthorDAO
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
