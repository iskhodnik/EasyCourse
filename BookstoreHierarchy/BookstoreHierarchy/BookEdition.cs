using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BookstoreHierarchy
{
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
        public BookGenre Genre;
        public decimal Price;
        public DateTime PublicationDate;
        public string Adress;
        public short Сirculation;

        public BookEdition(string name, List<Author> authors, BookType type, BookGenre genre, decimal price, DateTime publicationDate, string adress, short сirculation)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Authors = authors ?? throw new ArgumentNullException(nameof(authors));
            Type = type;
            Genre = genre;
            Price = price;
            PublicationDate = publicationDate;
            Adress = adress ?? throw new ArgumentNullException(nameof(adress));
            Сirculation = сirculation;
        }
    }
}
