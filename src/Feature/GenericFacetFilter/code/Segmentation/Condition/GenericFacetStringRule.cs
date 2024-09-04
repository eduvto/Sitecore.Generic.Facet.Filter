using Etonon.Feature.GenericFacetFilter.Segmentation.Condition.Base;
using Sitecore.XConnect.Segmentation.Predicates;

namespace Etonon.Feature.GenericFacetFilter.Segmentation.Condition
{
    public class GenericFacetStringRule : GenericFacetRuleBase<string, StringOperationType>
    {
        public GenericFacetStringRule()
        {
            ComparisonType = typeof(StringOperationTypeExtensions);
        }
    }
}