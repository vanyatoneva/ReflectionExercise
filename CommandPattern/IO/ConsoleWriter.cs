using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPattern.IO.Interfaces;

namespace CommandPattern.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string args) => Console.Write(args);

        public void WriteLine(string args) => Console.WriteLine(args);
    }
}
