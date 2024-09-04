using Sitecore.Rules;
using Etonon.Feature.GenericFacetFilter.Personalize.Base;
using Sitecore.Rules.Conditions;

namespace Etonon.Feature.GenericFacetFilter.Personalize
{
    public class GenericFacetStringRule<T> : GenericFacetRuleBase<T, string> where T : RuleContext
    {
        public GenericFacetStringRule()
        {
            CompareTo = (value1, value2) => {
                return ConditionsUtility.CompareStrings(value1, value2, OperatorId);
            };
        }
    }
}