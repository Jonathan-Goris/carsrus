using Sitecore;
using Sitecore.Data.Fields;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using System.Collections.Generic;

namespace CarsRUs.Indexing.Fields
{
    public class DoneBusinessWith : AbstractComputedIndexField
    {
        public override object ComputeFieldValue(IIndexable indexable)
        {
            var item = indexable as SitecoreIndexableItem;

            if (item == null)
                return null;

            var doneBusinessWith = new List<string>();

            if (item.Item.TemplateID == Templates.Customer.ID)
            {
                var referrers = Globals.LinkDatabase.GetItemReferrers(item, false);

                foreach (var referrer in referrers)
                {
                    var sourceItem = referrer.GetSourceItem();

                    if (sourceItem.TemplateID == Templates.CarPurchase.ID)
                    {
                        doneBusinessWith.Add(((ReferenceField)sourceItem.Fields[Templates.CarPurchase.Fields.SalesPerson]).TargetItem?.Fields[Templates.SalesPerson.Fields.Name].Value);
                    }
                }
            }

            return doneBusinessWith;
        }
    }
}