using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPattern.IO.Interfaces;

namespace CommandPattern.IO
{
    public class FileWriter : IWriter
    {

        public FileWriter(string path)
        {
            Path = path;
        }

        public string Path { get; private set; }
        public void Write(string args)
        {
            using(StreamWriter sw = new StreamWriter(Path))
            {
                sw.Write(args);
            }
        }

        public void WriteLine(string args)
        {
            using (StreamWriter sw = new StreamWriter(Path))
            {
                sw.WriteLine(args);
            }
        }
    }
}
