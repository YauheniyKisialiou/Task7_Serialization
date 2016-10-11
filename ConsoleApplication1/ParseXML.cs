using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApplication1
{
    public class ParseXML
    {
        XDocument xDoc = XDocument.Load(Globals.FileName);

        public Dictionary<string, List<string>> GetBooks()
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();

            var booksList = xDoc.Elements()
                                .First()
                                .Elements();
            //.Select(x => new
            // {
            //     bookId = x.FirstAttribute.ToString(),
            //     bookTags = x.Elements()
            //                .Select(y => y.Value).ToList()
            // }).ToDictionary(x=>x);



            foreach (var book in booksList)
            {
                List<string> list = new List<string>();
                string id = book.FirstAttribute.ToString();
                var bookTags = book.Elements();

                foreach (var item in bookTags)
                {
                    list.Add(item.Value);
                }

                dic.Add(id, list);
            }

            return dic;
        }
    }
}
