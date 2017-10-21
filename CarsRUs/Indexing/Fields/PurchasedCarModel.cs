using Sitecore;
using Sitecore.Data.Fields;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using System.Collections.Generic;

namespace CarsRUs.Indexing.Fields
{
    public class PurchasedCarModel : AbstractComputedIndexField
    {
        public override object ComputeFieldValue(IIndexable indexable)
        {
            var item = indexable as SitecoreIndexableItem;

            if (item == null)
                return null;

            var purchasedModels = new List<string>();

            if (item.Item.TemplateID == Templates.Customer.ID)
            {
                var referrers = Globals.LinkDatabase.GetItemReferrers(item, false);

                foreach (var referrer in referrers)
                {
                    var sourceItem = referrer.GetSourceItem();

                    if (sourceItem.TemplateID == Templates.CarPurchase.ID)
                    {
                        foreach (var carItem in ((MultilistField)sourceItem.Fields[Templates.CarPurchase.Fields.Cars]).GetItems())
                        {
                            purchasedModels.Add(carItem.Fields[Templates.Car.Fields.Model].Value);
                        }
                    }
                }
            }

            return purchasedModels;
        }
    }
}