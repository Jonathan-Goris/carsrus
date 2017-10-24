using System.Collections.Generic;

namespace CarsRUs.Models
{
    public class CustomerSearchCriteria
    {   
        public Dictionary<string, string> Terms { get; private set; }
        public Dictionary<string, string> TermsWithExactMatch { get; private set; }
        public List<string> Facets { get; private set; }

        public CustomerSearchCriteria()
        {
            Terms = new Dictionary<string, string>();
            TermsWithExactMatch = new Dictionary<string, string>();
            Facets = new List<string>();
        }
        
        public void AddTerm(string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                Terms.Add(key, value);
        }

        public void AddTermWithExactMatch(string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                TermsWithExactMatch.Add(key, value);
        }

        public void AddFacets(params string[] fieldNames)
        {
            foreach (var fieldName in fieldNames)
                Facets.Add(fieldName);
        }
    }
}