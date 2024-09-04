using Etonon.Feature.GenericFacetFilter.Segmentation.Condition.Base;
using Sitecore.XConnect.Segmentation.Predicates;
using System;

namespace Etonon.Feature.GenericFacetFilter.Segmentation.Condition
{
    public class GenericFacetDateTimeRule : GenericFacetRuleBase<DateTime, NumericOperationType>
    {
        public GenericFacetDateTimeRule()
        {
            ComparisonType = typeof(NumericOperationTypeExtensions);
        }
    }
}