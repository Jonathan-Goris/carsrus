using CarsRUs.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Linq;
using System.Linq;

namespace CarsRUs.Repositories
{
    public class CustomerSearchResultRepository
    {
        public CustomerSearchResult Search(CustomerSearchCriteria criteria)
        {
            using (var context = ContentSearchManager.GetIndex("sitecore_web_index").CreateSearchContext())
            {
                var filter = PredicateBuilder.True<CustomerSearchResultItem>();

                filter = filter.And(item => item.TemplateId == Templates.Customer.ID);

                foreach (var term in criteria.Terms)
                    filter = filter.And(item => item[term.Key].Like(term.Value));

                foreach (var term in criteria.TermsWithExactMatch)
                    filter = filter.And(item => item[term.Key] == term.Value);

                var result = context.GetQueryable<CustomerSearchResultItem>().Filter(filter);

                foreach (var facet in criteria.Facets)
                    result = result.FacetOn(item => item[facet]);

                return new CustomerSearchResult(result.GetResults().Select(x => x.Document).ToList(), result.GetFacets().Categories);
            }
        }
    }
}