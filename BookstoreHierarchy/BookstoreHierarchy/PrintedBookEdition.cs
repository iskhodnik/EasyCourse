using System;

namespace BookstoreHierarchy
{
    /// <summary>
    /// Выпущенное издание
    /// </summary>
    public class ReleasedBookEdition
    {
        public BookEdition bookEdition;
        public int amountOfBooks;

        public ReleasedBookEdition(BookEdition bookEdition, int amountOfBooks)
        {
            this.bookEdition = bookEdition ?? throw new ArgumentNullException(nameof(bookEdition));
            this.amountOfBooks = amountOfBooks;
        }
    }
}