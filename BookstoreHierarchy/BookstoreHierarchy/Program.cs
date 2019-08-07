using System;
using System.Collections.Generic;

namespace BookstoreHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            var author1 = new Author("Дон","Цу","Ван","89999999999","Китай, г. Пекин, ул. Вутонг, д. 11");
            var author2 = new Author("Ци","Чжоу","Тан","89999999998","Китай, г. Пекин, ул. Вутонг, д. 1");

            // Публикация книг
            var publishingHouse = new PublishingHouse("Читай много", "Темрюк", "Россия", "городулицадомквартира");
            publishingHouse.PublishBooks("Оттенки прекрасного", new List<Author> { author1 , author2}, BookEdition.BookType.Documentary, new List<BookEdition.BookGenre> { BookEdition.BookGenre.Adventure, BookEdition.BookGenre.Education}, 999, DateTime.Now, 1000);
            publishingHouse.PublishBooks("Оттенки прекрасного2", new List<Author> {author2}, BookEdition.BookType.Instructive, new List<BookEdition.BookGenre> { BookEdition.BookGenre.LoveAffairs, BookEdition.BookGenre.Poetry}, 888, DateTime.Now, 1500);

            // Заказ книг в магазин
            var salesDepartment = new SalesDepartment();
            salesDepartment.OrderBooksFromPublisher(publishingHouse, "Оттенки прекрасного", 100);
            salesDepartment.OrderBooksFromPublisher(publishingHouse, "Оттенки прекрасного2", 200);

            // Покупка книг
            salesDepartment.ShowBooks();
            salesDepartment.BuyBook("Оттенки прекрасного", 10, SalesDepartment.Payment.InCash);
            salesDepartment.ShowBooks();

            // Фильтация
            salesDepartment.ShowBooks(BookEdition.BookGenre.Adventure);
            salesDepartment.ShowBooks(BookEdition.BookGenre.Science);

            Console.ReadKey();
        }
    }
}
