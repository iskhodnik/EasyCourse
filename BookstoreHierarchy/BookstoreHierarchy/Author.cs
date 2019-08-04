using System;

namespace BookstoreHierarchy
{
    public class Author
    {
        public string Surname;
        public string Name;
        private string patronymic;
        private int phone;
        private string adress;

        public Author(string surname, string name, string patronymic, int phone, string adress)
        {
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            this.patronymic = patronymic ?? throw new ArgumentNullException(nameof(patronymic));
            this.phone = phone;
            this.adress = adress ?? throw new ArgumentNullException(nameof(adress));
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }

        public string GetPhone() => string.Format("# (###) ###-####}", phone);
        public string GetAdress() => adress;
    }
}
