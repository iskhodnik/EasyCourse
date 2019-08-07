using System;
using System.Collections.Generic;

namespace BookstoreHierarchy
{
    /// <summary>
    /// Издательство
    /// </summary>
    public class PublishingHouse
    {
        public string Name;
        public string City;
        public string Country;
        public string Adress;
        public Dictionary<string, ReleasedBookEdition> PrintedBookEditions;

        public PublishingHouse(string name, string city, string country, string adress)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            City = city ?? throw new ArgumentNullException(nameof(city));
            Country = country ?? throw new ArgumentNullException(nameof(country));
            Adress = adress ?? throw new ArgumentNullException(nameof(adress));
            PrintedBookEditions = new Dictionary<string, ReleasedBookEdition>();
        }

        public void PublishBooks(string bookName, List<Author> authors, BookEdition.BookType type, List<BookEdition.BookGenre> genre, decimal price, DateTime publicationDate, short сirculation)
        {
            PrintedBookEditions.Add(bookName, new ReleasedBookEdition(new BookEdition(bookName, authors, type, genre, price, publicationDate, Adress, сirculation), сirculation));
        }


        public int GetNumberOfBooks(string bookName)
        {
            var printedEdition = PrintedBookEditions[bookName];

            if (printedEdition == null)
            {
                Console.WriteLine("Издание не найдено!");
                return -1;
            }

            return printedEdition.amountOfBooks;
        }

        /// <summary>
        /// Получение партии книг
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="numberOfBooks"></param>
        /// <returns></returns>
        public BookEdition GettingBatchOfBooks(string bookName, int amountOfBooks)
        {
            var printedEdition = PrintedBookEditions[bookName];
            if (printedEdition == null)
            {
                Console.WriteLine("Издание не найдено!");
                return null;
            }

            var currentNumber = GetNumberOfBooks(bookName);
            if (currentNumber == -1)
            {
                return null;
            }
            else if (currentNumber < amountOfBooks)
            {
                Console.WriteLine("Запрашиваемое количество больше имеющегося в издательстве.");
                return null;
            }

            printedEdition.amountOfBooks = printedEdition.amountOfBooks - amountOfBooks;
            return printedEdition.bookEdition;
        }
    }
}
