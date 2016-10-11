using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    public class XmlSerialization
    {
        public void Save()
        {
            string fileName = Globals.ResultFileName;

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                try
                {
                    XmlSerializer xser = new XmlSerializer(typeof(Catalog));
                    Catalog c = new Catalog();

                    ParseXML parse = new ParseXML();

                    var books = parse.GetBooks();
                    List<Book> listOfBooks = new List<Book>();
                    foreach (var book in books)
                    {
                        listOfBooks.Add(new Book(book));
                    }
                    c.CatalogOfBooks = listOfBooks;
                    xser.Serialize(fs, c);
                    fs.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                    Console.WriteLine("Inner exception: {0}", e.InnerException);
                }


            }

        }

        public static Catalog Load()
        {
            Catalog catalog = null;
            string fileName = Globals.ResultFileName;

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                try
                {
                    XmlSerializer xser = new XmlSerializer(typeof(Catalog));
                    catalog = (Catalog)xser.Deserialize(fs);
                    fs.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException);
                }
            }
            return catalog;
        }
    }
}
