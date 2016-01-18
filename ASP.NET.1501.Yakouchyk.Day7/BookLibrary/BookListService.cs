using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom;
using NLog;

namespace BookLibrary
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string message)
            : base(message)
        {
        }

    }

    public class BookListService
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        private IBookRepository repository;

        public BookListService(IBookRepository repository)
        {
            this.repository = repository;
        }

        public void AddBook(Book book)
        {
            var books = repository.LoadBooks();
            if (books.Contains(book))
            {
              try
              {
                throw new AlreadyExistsException("Such book are already exist. Book: "+ book);
              }
              catch(AlreadyExistsException ex)
              {
                log.Error("Such book are already exist", ex);
                throw;
              }
            }
            books = books.Concat(new[]{book});
            repository.SaveBooks(books);
        }

        public void SortBooks(Func<Book,Book,int> comparator)
        {
            var books = repository.LoadBooks();
            var arr = books.ToArray();
            Matrix.Sort(arr,comparator);
            repository.SaveBooks(arr);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return repository.LoadBooks();
        }
    }
}
