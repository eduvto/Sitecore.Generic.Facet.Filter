using Etonon.Feature.GenericFacetFilter.Segmentation.SearchQuery.Base;
using Sitecore.XConnect.Segmentation.Predicates;

namespace Etonon.Feature.GenericFacetFilter.Segmentation.SearchQuery
{
    public class GenericFacetIntegerRule : GenericFacetRuleBase<int, NumericOperationType>
    {
        public GenericFacetIntegerRule()
        {
            ComparisonType = typeof(NumericOperationTypeExtensions);
        }
    }
}