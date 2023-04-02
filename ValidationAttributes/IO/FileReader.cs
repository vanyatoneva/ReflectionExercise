using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.IO.Interfaces;

namespace ValidationAttributes.IO
{
    public class FileReader : IReader
    {
        public FileReader(string path)
        {
            Path = path;
        }
        public string Path { get; private set; }

        public string ReadLine()
        {
            using (StreamReader sr =  new StreamReader(Path))
            {
                return sr.ReadLine();
            }
        }
    }
}
