using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    public class Book
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("isbn")]
        public string Isbn { get; set; }

        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("genre")]
        public Genre Genre { get; set; }

        [XmlElement("publisher")]
        public string Publisher { get; set; }

        [XmlIgnore]
        public DateTime Publish_date { get; set; }

        [XmlElement("publish_date")]
        public string Publish_date_String { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlIgnore]
        public DateTime Registration_date { get; set; }

        [XmlElement("registration_date")]
        public string Registration_date_String { get; set; }

        public Book()
        {
        }

        public Book(KeyValuePair<string, List<string>> book)
        {
            if (book.Value.Count == 8)
            {
                this.Id = book.Key;

                this.Isbn = book.Value[0];

                this.Author = book.Value[1];

                this.Title = book.Value[2];

                this.Genre = GetGenre(book.Value[3]);

                this.Publisher = book.Value[4];

                string publishDate = book.Value[5];
                Publish_date = Convert.ToDateTime(publishDate);
                Publish_date_String = Publish_date.ToString("yyyy-MM-dd");

                this.Description = book.Value[6];

                string registrationDate = book.Value[7];
                Registration_date = Convert.ToDateTime(registrationDate);
                Registration_date_String = Registration_date.ToString("yyyy-MM-dd");
            }
            else
            {
                this.Id = book.Key;

                this.Author = book.Value[0];

                this.Title = book.Value[1];

                this.Genre = GetGenre(book.Value[2]);

                this.Publisher = book.Value[3];

                string publishDate = book.Value[4];
                Publish_date = Convert.ToDateTime(publishDate);
                Publish_date_String = Publish_date.ToString("yyyy-MM-dd");

                this.Description = book.Value[5];

                string registrationDate = book.Value[6];
                Registration_date = Convert.ToDateTime(registrationDate);
                Registration_date_String = Registration_date.ToString("yyyy-MM-dd");
            }
            
        }

        Genre GetGenre(string genre)
        {
            switch (genre)
            {
                case "Computer":
                    return Genre.Computer;
                case "Fantasy":
                    return Genre.Fantasy;
                case "Romance":
                    return Genre.Romance;
                case "Horror":
                    return Genre.Horror;
                case "Science Fiction":
                    return Genre.ScienceFiction;
                default:
                    return Genre.Nothing;
            }
        }
    }

    public enum Genre
    {
        [XmlEnum]
        Computer,
        [XmlEnum]
        Fantasy,
        [XmlEnum]
        Romance,
        [XmlEnum]
        Horror,
        [XmlEnum]
        ScienceFiction,
        [XmlEnum]
        Nothing
    }
}
