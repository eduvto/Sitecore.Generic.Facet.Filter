using Etonon.Feature.GenericFacetFilter.Segmentation.Condition.Base;
using Sitecore.XConnect.Segmentation.Predicates;

namespace Etonon.Feature.GenericFacetFilter.Segmentation.Condition
{
    public class GenericFacetIntegerRule : GenericFacetRuleBase<int, NumericOperationType>
    {
        public GenericFacetIntegerRule()
        {
            ComparisonType = typeof(NumericOperationTypeExtensions);
        }
    }
}