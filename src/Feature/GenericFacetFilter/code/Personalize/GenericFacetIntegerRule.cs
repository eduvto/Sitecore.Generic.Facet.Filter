using Sitecore.Rules;
using Etonon.Feature.GenericFacetFilter.Personalize.Base;
using Sitecore.Rules.Conditions;

namespace Etonon.Feature.GenericFacetFilter.Personalize
{
    public class GenericFacetIntegerRule<T> : GenericFacetRuleBase<T, int> where T : RuleContext
    {
        public GenericFacetIntegerRule()
        {
            CompareTo = (value1, value2) => {
                return ConditionsUtility.GetInt32Comparer(OperatorId)(value1, value2);
            };
        }
    }
}