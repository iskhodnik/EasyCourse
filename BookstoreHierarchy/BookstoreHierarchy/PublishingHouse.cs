using System;
using System.Collections.Generic;

namespace BookstoreHierarchy
{
    public class PublishingHouse
    {
        public string Name;
        public string City;
        public string Country;
        public string Adress;
        public List<BookEdition> BookEditions;
        private Dictionary<string, short> NumberOfBooksInCirculation;

        public PublishingHouse(string name, string city, string country, string adress)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            City = city ?? throw new ArgumentNullException(nameof(city));
            Country = country ?? throw new ArgumentNullException(nameof(country));
            Adress = adress ?? throw new ArgumentNullException(nameof(adress));
            BookEditions = new List<BookEdition>();
            NumberOfBooksInCirculation = new Dictionary<string, short>();
        }

        public void PublishBooks(string bookName, List<Author> authors, BookEdition.BookType type, BookEdition.BookGenre genre, decimal price, DateTime publicationDate, string adress, short сirculation)
        {
            BookEditions.Add(new BookEdition(bookName, authors, type, genre, price, publicationDate, adress, сirculation));
            NumberOfBooksInCirculation.Add(bookName, сirculation);
        }

        public short GetNumberOfBooks(string bookName)
        {
            return NumberOfBooksInCirculation[bookName];
        }

        public BookEdition PutBatchOfBooksInStore(string bookName, short numberOfBooks)
        {
            var currentNumber = NumberOfBooksInCirculation[bookName];


            if (currentNumber < numberOfBooks)
            {
                Console.WriteLine("");
                return null;
            }

            return null;

        }
    }
}
