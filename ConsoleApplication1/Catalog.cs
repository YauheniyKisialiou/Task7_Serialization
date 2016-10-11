using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [XmlType(TypeName = "catalog")]
    public class Catalog
    {
        [XmlArray("books"), XmlArrayItem("book")]
        public List<Book> CatalogOfBooks { get; set; }

        public Catalog()
        {

        }
    }
}
