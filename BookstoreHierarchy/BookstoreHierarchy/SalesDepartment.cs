using System;
using System.Collections.Generic;

namespace BookstoreHierarchy
{
    /// <summary>
    /// Отдел продаж
    /// </summary>
    public class SalesDepartment
    {
        public enum Payment
        {
            InCash,
            Cashless
        }

        /// <summary>
        /// Проданная книга
        /// </summary>
        public class SoldBook
        {
            private BookEdition book;
            private DateTime dateOfSale;
            private int amount;
            private decimal totalPrice;
            private Payment payment;

            public SoldBook(BookEdition book, DateTime dateOfSale, int amount, decimal totalPrice, Payment payment)
            {
                this.book = book ?? throw new ArgumentNullException(nameof(book));
                this.dateOfSale = dateOfSale;
                this.amount = amount;
                this.totalPrice = totalPrice;
                this.payment = payment;
            }
        }

        private Dictionary<string, ReleasedBookEdition> books;
        private Dictionary<string, SoldBook> booksSold;

        public SalesDepartment()
        {
            this.books = new Dictionary<string, ReleasedBookEdition>();
            this.booksSold = new Dictionary<string, SoldBook>();
        }

        /// <summary>
        /// Заказ книг у издательства
        /// </summary>
        /// <param name="publishingHouse"></param>
        /// <param name="BookEdition"></param>
        /// <param name="amount"></param>
        public void OrderBooksFromPublisher(PublishingHouse publishingHouse, string bookName, int amount) // TODO: заказ уже существующей книги 
        {
            var booksOrdered = publishingHouse.GettingBatchOfBooks(bookName, amount);

            if (booksOrdered == null)
            {
                Console.WriteLine("Заказ не совершился.");
                return;
            }
            books.Add(booksOrdered.Name, new ReleasedBookEdition(booksOrdered, amount));
        }

        public void ShowBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Value.bookEdition.ToString()} | {book.Value.amountOfBooks}");
            }
        }

        public void ShowBooks(BookEdition.BookGenre genres)
        {
            foreach (var book in books)
            {
                if (book.Value.bookEdition.Genre.Contains(genres))
                {
                    Console.WriteLine($"{book.Value.bookEdition.ToString()} | {book.Value.amountOfBooks}");
                }
            }
        }

        public void BuyBook(string bookName, int amount, Payment payment)
        {
            var book = books[bookName];

            if (book == null)
            {
                Console.WriteLine("Книга отсутствует в магазине.");
                return;
            }

            if (book.amountOfBooks < amount)
            {
                Console.WriteLine("Недостаточное количество книг в магазине.");
                return;
            }

            booksSold.Add(bookName, new SoldBook(book.bookEdition, DateTime.Now, amount, book.bookEdition.Price * amount, payment));

            book.amountOfBooks = book.amountOfBooks - amount;

            if(book.amountOfBooks == 0)
            {
                books.Remove(bookName);
            }
        }
    }
}
