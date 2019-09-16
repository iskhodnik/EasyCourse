using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirectoryOfOrganizations
{
    public static class DictionaryOverride
    {
        public static string ToString(this Dictionary<string, string> source, string keyValueSeparator, string sequenceSeparator)
        {
            if (source == null)
                throw new ArgumentException("Parameter source can not be null.");

            var pairs = source.Select(x => string.Format("{0}{1}{2}", x.Key, keyValueSeparator, x.Value));

            return string.Join(sequenceSeparator, pairs);
        }
    }
}
