using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;
using System.IO;

namespace BookUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryFileRepository rep = new BinaryFileRepository(AppDomain.CurrentDomain.BaseDirectory + @"\lib2.bin");
            
            BookListService service = new BookListService(rep);

            var books = service.GetAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();
            try
            {
                //service.AddBook(new Book("Admin", "Stupid Users", "Users are very stupid", "fantasy", 4));

                service.AddBook(new Book("Admin", "Stupid Users 2", "Users are very stupid", "fantasy", 4));
            }
            catch (AlreadyExistsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            books = service.GetAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
