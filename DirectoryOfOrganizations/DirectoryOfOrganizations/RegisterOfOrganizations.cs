using System;
using System.Collections.Generic;
using System.Linq;

namespace DirectoryOfOrganizations
{
    public class RegisterOfOrganizations
    {
        public enum SortType
        {
            ascending = 0,
            decrease
        }

        private List<Organization> Organizations;

        public RegisterOfOrganizations()
        {
            Organizations = new List<Organization>();
        }

        public void Add(Organization organization)
        {
            Organizations.Add(organization);
        }

        public void ShowOrganizations(SortType order)
        {
            switch (order)
            {
                case SortType.ascending:
                    Organizations.OrderBy(x => x.workingCapital).ToList().ForEach(Console.WriteLine);
                    break;

                case SortType.decrease:
                    Organizations.OrderByDescending(x => x.workingCapital).ToList().ForEach(Console.WriteLine);
                    break;
            }
        }

        public void ShowOrganizationsByСity()
        {
            var cities = (from o in Organizations
                     group o by o.adress
                     into grp
                     select new { type = grp.Key, name = grp.Select(n => n.name)})
                     .ToDictionary(d => d.type, d => d.name);

            foreach (var citie in cities)
            {
                Console.WriteLine($"{citie.Key} {string.Join(" ", citie.Value)}");
            }

        }

        public void ShowOrganizationsByOkved(string code)
        {
           
        }
    }
}
