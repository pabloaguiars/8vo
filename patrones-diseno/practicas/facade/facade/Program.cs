using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade
{
    /// <summary>
    /// Class client. Reader.
    /// </summary>
    class Reader
    {
        private string name { get; set; }

        public Reader(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }
    }

    /// <summary>
    /// Abstract class for books.
    /// </summary>
    class Book { 
        public string Name { get; set; }
        public Genre Genre { get; set; }

        public string Details() 
        {
            return "Book name: " + this.Name + " Genre: " + this.Genre.description;
        }
    
    }

    /// <summary>
    /// Books' genre.
    /// </summary>
    class Genre
    {
        public string description { get; set; }
    }

    #region
    //Preparation

    /// <summary>
    /// Interface for preration.
    /// </summary>
    interface ILibrary
    {
        Book SetBook(string Name);
    }

    /// <summary>
    /// ScienceFiction
    /// </summary>
    class PrepScienceFiction : ILibrary
    {
        public Book SetBook(string Name)
        {
            return new Book()
            {
                Name = Name,
                Genre = new Genre() 
                { 
                    description = "Scientific fiction"
                }
            };
        }
    }

    /// <summary>
    /// Drama
    /// </summary>
    class PrepDrama : ILibrary
    {
        public Book SetBook(string Name)
        {
            return new Book()
            {
                Name = Name,
                Genre = new Genre()
                {
                    description = "Drama"
                }
            };
        }
    }

    /// <summary>
    /// Adventure
    /// </summary>
    class PrepAdventure : ILibrary
    {
        public Book SetBook(string Name)
        {
            return new Book()
            {
                Name = Name,
                Genre = new Genre()
                {
                    description = "Adventure"
                }
            };
        }
    }

    /// <summary>
    /// Codding 
    /// </summary>
    class PrepCodding : ILibrary
    {
        public Book SetBook(string Name)
        {
            return new Book()
            {
                Name = Name,
                Genre = new Genre()
                {
                    description = "Codding"
                }
            };
        }
    }
    #endregion

    class Serve
    {
        private PrepScienceFiction PrepScienceFiction = new PrepScienceFiction();
        private PrepAdventure PrepAdventure = new PrepAdventure();
        private PrepDrama PrepDrama = new PrepDrama();
        private PrepCodding PrepCodding = new PrepCodding();


        public Book GetScienceFictionBook(string Name)
        {
            return PrepScienceFiction.SetBook(Name);
        }

        public Book GetDramaBook(string Name)
        {
            return PrepDrama.SetBook(Name);
        }

        public Book GetAdventureBook(string Name)
        {
            return PrepAdventure.SetBook(Name);
        }

        public Book GetCoddingBook(string Name)
        {
            return PrepCodding.SetBook(Name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Serve serve = new Serve();
            Console.WriteLine("Whats your name?");
            string name = Console.ReadLine();
            Reader reader = new Reader(name);
            Console.WriteLine("\n");
            try
            {
                Book book;

                Console.WriteLine("Hello reader " + reader.GetName() + ". \n\nInsert Name for a Science Fiction Book:");
                string science_name = Console.ReadLine();
                book = serve.GetScienceFictionBook(science_name);
                Console.WriteLine(book.Details());

                Console.WriteLine("\nInsert Name for an Adventure Book:");
                string adventure_name = Console.ReadLine();
                book = serve.GetScienceFictionBook(adventure_name);
                Console.WriteLine(book.Details());

                Console.WriteLine("\nInsert Name for a Drama Book:");
                string drama_name = Console.ReadLine();
                book = serve.GetScienceFictionBook(drama_name);
                Console.WriteLine(book.Details());

                Console.WriteLine("\nInsert Name for an Codding Book:");
                string coding_name = Console.ReadLine();
                book = serve.GetScienceFictionBook(coding_name);
                Console.WriteLine(book.Details());

                Console.ReadKey();
            }
            catch (System.Exception exp)
            {
                Console.WriteLine("You need to write a valid data");
            }
        }
    }
}
