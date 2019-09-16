using System;
using System.Collections.Generic;

namespace DirectoryOfOrganizations
{
    public class Organization
    {
        public string name { get; private set; }
        public int inn { get; private set; }
        public Dictionary<string, string> okved { get; private set; }
        public string adress { get; private set; }
        public decimal workingCapital { get; private set; }

        public Organization(string name, int inn, Dictionary<string, string> okved, string adress, decimal workingCapital)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.inn = inn;
            this.okved = okved ?? throw new ArgumentNullException(nameof(okved));
            this.adress = adress ?? throw new ArgumentNullException(nameof(adress));
            this.workingCapital = workingCapital;
        }

        public override string ToString()
        {
            return $"{name} {inn} [{okved.ToString(" = "," | ")}] {adress} {workingCapital}";
        }
    }
}
