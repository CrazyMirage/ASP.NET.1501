using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BookLibrary
{
    public interface IXmlFormatExporter
    {
        void Export(IEnumerable<Book> books);
    }
}
