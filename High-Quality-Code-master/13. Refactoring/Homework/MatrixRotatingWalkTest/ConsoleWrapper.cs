
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixRotatingWalkTest
{
    public class ConsoleWrapper : IConsole
    {
        public List<String> LinesToRead = new List<String>();

        public void Write(string message)
        {
        }

        public void WriteLine(string message)
        {
        }

        public string ReadLine()
        {
            string result = this.LinesToRead[0];
            this.LinesToRead.RemoveAt(0);
            return result;
        }
    }
}
