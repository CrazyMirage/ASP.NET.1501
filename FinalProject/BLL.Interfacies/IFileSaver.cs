using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies
{
    public interface IFileSaver
    {
        string FileName { get; }
        void Save(String path);
    }
}
