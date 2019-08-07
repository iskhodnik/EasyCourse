using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BookstoreHierarchy
{
    /// <summary>
    /// Издание
    /// </summary>
    public class BookEdition
    {
        public enum BookType
        {
            [Description("Агитационно-пропагандистская")] Propaganda,
            [Description("Учебная")] Educational,
            [Description("Научно-популярная")] PopularScience,
            [Description("Научная")] Scientific,
            [Description("Художественная")] ProductionAndTechnical,
            [Description("Производственно-техническая")] Art,
            [Description("Программно-методическая")] Methodological,
            [Description("Справочная")] Reference,
            [Description("До­кументальная")] Documentary,
            [Description("Инструктивная")] Instructive
        }

        public enum BookGenre
        {
            [Description("Фантастика")] Fantasy,
            [Description("Детективы")] Detectives,
            [Description("Боевики")] Militants,
            [Description("Проза")] Prose,
            [Description("Любовные романы")] LoveAffairs,
            [Description("Приключения")] Adventure,
            [Description("Поэзия")] Poetry,
            [Description("Драматургия")] Dramaturgy,
            [Description("Наука")] Science,
            [Description("Образование")] Education
        }

        public string Name;
        public List<Author> Authors;
        public BookType Type;
        public List<BookGenre> Genre;
        public decimal Price;
        public DateTime PublicationDate;
        public string Adress;
        public short Circulation;

        public BookEdition(string name, List<Author> authors, BookType type, List<BookGenre> genre, decimal price, DateTime publicationDate, string adress, short circulation)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Authors = authors ?? throw new ArgumentNullException(nameof(authors));
            Type = type;
            Genre = genre ?? throw new ArgumentNullException(nameof(genre));
            Price = price;
            PublicationDate = publicationDate;
            Adress = adress ?? throw new ArgumentNullException(nameof(adress));
            Circulation = circulation;
        }

        public override string ToString()
        {
            

            return $"{Name} | {string.Join(", ", Authors.Select(x => x.ToString()).ToList())} {Type} {string.Join(", ", Genre.ToArray())} {Price} {PublicationDate} {Adress} {Circulation}";
        }
    }
}
