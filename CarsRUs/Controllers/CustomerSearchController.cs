using CarsRUs.Models;
using CarsRUs.Repositories;
using System.Web.Mvc;

namespace CarsRUs.Controllers
{
    public class CustomerSearchController : Controller
    {
        public ActionResult Index()
        {
            var criteria = PrepareSearchCriteriaWithFacets();

            var result = new CustomerSearchResultRepository().Search(criteria);

            var model = new CustomerSearchViewModel();
            PrepareResults(result, model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CustomerSearchViewModel model)
        {
            CustomerSearchCriteria criteria = PrepareSearchCriteriaWithFacets();
            criteria.AddTerm("name", model.Name);
            criteria.AddTerm("street", model.Street);
            criteria.AddTermWithExactMatch("purchased_car_make", model.PurchasedCarMake);
            criteria.AddTermWithExactMatch("purchased_car_model", model.PurchasedCarModel);
            criteria.AddTermWithExactMatch("done_business_with", model.DoneBusinessWith);

            var result = new CustomerSearchResultRepository().Search(criteria);

            PrepareResults(result, model);

            return View(model);
        }

        private static CustomerSearchCriteria PrepareSearchCriteriaWithFacets()
        {
            var criteria = new CustomerSearchCriteria();
            criteria.AddFacets("purchased_car_make", "purchased_car_model", "done_business_with");
            return criteria;
        }

        private static void PrepareResults(CustomerSearchResult result, CustomerSearchViewModel model)
        {
            model.CarMakes = result.GetFilteredFacetValuesFor("purchased_car_make");
            model.CarModels = result.GetFilteredFacetValuesFor("purchased_car_model");
            model.SalesPeople = result.GetFilteredFacetValuesFor("done_business_with");
            model.Customers = result.Results;
        }
    }
}