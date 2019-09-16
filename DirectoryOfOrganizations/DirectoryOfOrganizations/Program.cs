using System;
using System.Collections.Generic;

namespace DirectoryOfOrganizations
{
    class Program
    {
        static void Main(string[] args)
        {
            var register = new RegisterOfOrganizations();
            register.Add(new Organization("ОПГ1", 777, new Dictionary<string, string> { {"01.11.31", "Выращивание семян подсолнечника" }, {"01.11.11", "Выращивание ячменя" } }, "Анапа", 1000));
            register.Add(new Organization("ОПГ2", 7777, new Dictionary<string, string> { {"01.11.32", "Выращивание семян рапса" }, {"01.11.11", "Выращивание ячменя" } }, "Томск", 3000));
            register.Add(new Organization("ОПГ3", 77777, new Dictionary<string, string> { {"01.11.33", "Выращивание семян соевых бобов" }, {"01.19.2", "Цветоводство" } }, "Сочи", 5000));
            register.Add(new Organization("ОПГ4", 777777, new Dictionary<string, string> { {"01.11.39", "Выращивание семян прочих масличных культур" }, {"01.16.2", "Выращивание льна" } }, "Томск", 100));
            register.Add(new Organization("ОПГ5", 7777777, new Dictionary<string, string> { {"01.13.1", "Выращивание овощей" }, {"01.13.31", "Выращивание картофеля" } }, "Череповец", 10000));


            register.ShowOrganizations(RegisterOfOrganizations.SortType.ascending);
            register.ShowOrganizations(RegisterOfOrganizations.SortType.decrease);

            register.ShowOrganizationsByСity();

            Console.ReadKey();
        }
    }
}
