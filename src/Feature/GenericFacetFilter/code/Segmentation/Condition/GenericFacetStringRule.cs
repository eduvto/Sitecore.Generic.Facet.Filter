using Etonon.Feature.GenericFacetFilter.Helper;
using Etonon.Feature.GenericFacetFilter.Segmentation.Condition.Base;

namespace Etonon.Feature.GenericFacetFilter.Segmentation.Condition
{
    public class GenericFacetStringRule : GenericFacetRuleBase<string, CustomStringOperationType>
    {
        public GenericFacetStringRule()
        {
            ComparisonType = typeof(CustomStringOperationTypeExtensions);
        }
    }
}