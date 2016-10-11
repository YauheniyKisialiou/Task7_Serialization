using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerialization ser = new XmlSerialization();
            ser.Save();
            var b = XmlSerialization.Load();
            Console.ReadLine();
        }
    }
}
