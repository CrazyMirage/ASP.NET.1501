using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace BookLibrary
{
    public class BinaryFileRepository : IBookRepository
    {
        public string FileName { get; private set; }

        public BinaryFileRepository(string fileName)
        {
            FileName = fileName;
        }


        public IEnumerable<Book> LoadBooks()
        {
            List<Book> list = null;
            
            using (var stream = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    list  = new List<Book>();
                    while (stream.Length > stream.Position)
                    {
                        list.Add(new Book(
                            author: reader.ReadString(),
                            title: reader.ReadString(),
                            text: reader.ReadString(),
                            genre: reader.ReadString(),
                            sizePages: reader.ReadInt32()
                            ));
                    }
                }
            }

            return list;
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            using (BinaryWriter writer = new BinaryWriter(new FileStream(FileName, FileMode.Create, FileAccess.Write)))
            {
                foreach (var book in books)
                {
                    writer.Write(book.Author);
                    writer.Write(book.Title);
                    writer.Write(book.Text);
                    writer.Write(book.Genre);
                    writer.Write(book.SizePages);
                }
            }
        }

    }
}
