using Etonon.Feature.GenericFacetFilter.Segmentation.SearchQuery.Base;
using Sitecore.XConnect.Segmentation.Predicates;

namespace Etonon.Feature.GenericFacetFilter.Segmentation.SearchQuery
{
    public class GenericFacetStringRule : GenericFacetRuleBase<string, StringOperationType>
    {
        public GenericFacetStringRule()
        {
            ComparisonType = typeof(StringOperationTypeExtensions);
        }
    }
}