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

            BinarySerializeRepository repSerialize = new BinarySerializeRepository(AppDomain.CurrentDomain.BaseDirectory + @"\library_serialize.bin");

            BookListService service = new BookListService(rep);


            Console.WriteLine(rep.FileName);
            var books = service.GetAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine();
            //service.WriteToRepository(repSerialize);

            Console.WriteLine(repSerialize.FileName);
            service = new BookListService(repSerialize);

            books = service.GetAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

            service.ExportToXml(new XmlExporter(AppDomain.CurrentDomain.BaseDirectory + @"\library2.xml"));

            //Console.WriteLine();
            //try
            //{
            //    //service.AddBook(new Book("Admin", "Stupid Users", "Users are very stupid", "fantasy", 4));

            //    service.AddBook(new Book("Admin", "Stupid Users 2", "Users are very stupid", "fantasy", 4));
            //}
            //catch (AlreadyExistsException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //books = service.GetAllBooks();
            //foreach (var book in books)
            //{
            //    Console.WriteLine(book);
            //}
        }
    }
}
