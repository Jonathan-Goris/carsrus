using Sitecore.ContentSearch.Linq;
using System.Collections.Generic;
using System.Linq;
using Sitecore.ContentSearch.SearchTypes;

namespace CarsRUs.Models
{
    public class CustomerSearchResult
    {
        public List<CustomerSearchResultItem> Results { get; private set; }
        public List<FacetCategory> Facets { get; private set; }

        public CustomerSearchResult(List<CustomerSearchResultItem> results, List<FacetCategory> facets)
        {
            Results = results;
            Facets = facets;
        }
        
        public List<string> GetFilteredFacetValuesFor(string facetName)
        {
            return Facets
                .Where(fc => fc.Name == facetName)
                .SelectMany(fc => fc.Values)
                .Select(fv => fv.Name).ToList();
        }
    }
}