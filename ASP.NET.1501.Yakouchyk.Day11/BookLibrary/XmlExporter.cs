using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace BookLibrary
{
    public class XmlExporter: IXmlFormatExporter
    {
        public string FileName { get; private set; }

        public XmlExporter(string filename)
        {
            FileName = filename;
            
        }
        
        public void Export(IEnumerable<Book> books)
        {
            if (books == null)
                throw new ArgumentNullException();

            List<XElement> xmlBooks = new List<XElement>();
            foreach(var book in books){
                xmlBooks.Add(GetXmlFromBook(book));
            }

            XDocument xDoc = new XDocument(new XElement("Library", xmlBooks.ToArray()));
            using (var writer = XmlWriter.Create(FileName))
            {
                xDoc.Save(writer);
            }
        }

        private XElement GetXmlFromBook(Book book)
        {
            return new XElement("Book",
                new XElement("Title", book.Title),
                new XElement("Author", book.Author),
                new XElement("Genre", book.Genre),
                new XElement("Text", book.Text),
                new XElement("SizePages", book.SizePages)
                );
        }

    }
}
