using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;

namespace BookLibrary
{
    public class BinarySerializeRepository : IBookRepository
    {
        public string FileName { get; private set; }

        public BinarySerializeRepository(string fileName)
        {
            FileName = fileName;
        }

        public IEnumerable<Book> LoadBooks()
        {
            List<Book> list = null;
            using (Stream stream = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                list = (List<Book>)bf.Deserialize(stream);
            }

            return list;
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            using (Stream stream = new FileStream(FileName, FileMode.Create, FileAccess.Write))
            {
                List<Book> list = new List<Book>(books);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, list);
            }

        }
    }
}
