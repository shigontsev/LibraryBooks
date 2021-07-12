using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Entities
{
    public class Book
    {

        public int Id { get; private set; }

        public string Title { get; private set; }

        public int AuthorId { get; private set; }

        public string AuthorFullName { get; private set; }

        public int Page { get; private set; }

        public string Description { get; private set; }

        public Book(string title, string authorFullName, int page, string description)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title),
                String.Format($"{nameof(title)} can't is null"));
            AuthorFullName = authorFullName ?? throw new ArgumentNullException(nameof(authorFullName),
                String.Format($"{nameof(authorFullName)} can't is null"));
            Page = page;
            Description = description ?? throw new ArgumentNullException(nameof(description),
                String.Format($"{nameof(description)} can't is null"));
        }

        public Book(int id, int authorId, string title, string authorFullName, int page, string description) :
            this(title, authorFullName, page, description)
        {
            Id = id;
            AuthorId = authorId;
        }

        public void Edit(string newTitle, string newAuthorFullName, int newPage, string newDescription)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentNullException(nameof(newTitle), String.Format($"{nameof(newTitle)} can't is empty"));
            if (string.IsNullOrWhiteSpace(newAuthorFullName))
                throw new ArgumentNullException(nameof(newAuthorFullName), String.Format($"{nameof(newAuthorFullName)} can't is empty"));
            if (string.IsNullOrWhiteSpace(newDescription))
                throw new ArgumentNullException(nameof(newDescription), String.Format($"{nameof(newDescription)} can't is empty"));
            Title = newTitle;
            AuthorFullName = newAuthorFullName;
            Page = newPage;
            Description = newDescription;
        }

        public void EditIdAuthor(int id)
        {
            AuthorId = id;
        }
    }
}
