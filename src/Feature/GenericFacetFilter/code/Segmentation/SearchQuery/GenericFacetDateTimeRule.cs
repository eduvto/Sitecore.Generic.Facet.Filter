using Etonon.Feature.GenericFacetFilter.Segmentation.SearchQuery.Base;
using Sitecore.XConnect.Segmentation.Predicates;
using System;

namespace Etonon.Feature.GenericFacetFilter.Segmentation.SearchQuery
{
    public class GenericFacetDateTimeRule : GenericFacetRuleBase<DateTime, NumericOperationType>
    {
        public GenericFacetDateTimeRule()
        {
            ComparisonType = typeof(NumericOperationTypeExtensions);
        }
    }
}