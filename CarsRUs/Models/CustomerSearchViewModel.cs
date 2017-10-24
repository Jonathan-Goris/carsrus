using System.Collections.Generic;
using System.ComponentModel;

namespace CarsRUs.Models
{
    public class CustomerSearchViewModel
    {
        public string Name { get; set; }
        public string Street { get; set; }

        [DisplayName("Purchased Car Make")]
        public string PurchasedCarMake { get; set; }

        [DisplayName("Purchased Car Model")]
        public string PurchasedCarModel { get; set; }

        [DisplayName("Done Business With")]
        public string DoneBusinessWith { get; set; }

        public List<string> CarMakes { get; set; }
        public List<string> CarModels { get; set; }
        public List<string> SalesPeople { get; set; }

        public List<CustomerSearchResultItem> Customers { get; set; }
    }
}