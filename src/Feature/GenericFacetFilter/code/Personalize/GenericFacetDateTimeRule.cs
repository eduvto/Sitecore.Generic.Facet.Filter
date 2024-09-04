using Sitecore.Rules;
using Etonon.Feature.GenericFacetFilter.Personalize.Base;
using Sitecore.Rules.Conditions;
using System;
using Sitecore;

namespace Etonon.Feature.GenericFacetFilter.Personalize
{
    public class GenericFacetDateTimeRule<T> : GenericFacetRuleBase<T, DateTime> where T : RuleContext
    {
        public string FacetValueAsString { get; set; }

        public GenericFacetDateTimeRule()
        {
            CompareTo = (datetime1, datetime2) =>
            {
                return DateTimeComparer(datetime1, datetime2);
            };
        }

        protected override bool Execute(T ruleContext)
        {
            FacetValue = DateUtil.ParseDateTime(this.FacetValueAsString, DateTime.MinValue);

            return base.Execute(ruleContext);
        }

        private bool DateTimeComparer(DateTime datetime1, DateTime datetime2)
        {
            switch (ConditionsUtility.GetConditionOperatorById(OperatorId))
            {
                case ConditionOperator.Equal:
                    return datetime1.Equals(datetime2);
                case ConditionOperator.LessThan:
                    return datetime1 < datetime2;
                case ConditionOperator.LessThanOrEqual:
                    return datetime1 <= datetime2;
                case ConditionOperator.GreaterThan:
                    return datetime1 > datetime2;
                case ConditionOperator.GreaterThanOrEqual:
                    return datetime1 >= datetime2;
                case ConditionOperator.NotEqual:
                    return !datetime1.Equals(datetime2);
                default:
                    return false;
            }

        }
    }
}