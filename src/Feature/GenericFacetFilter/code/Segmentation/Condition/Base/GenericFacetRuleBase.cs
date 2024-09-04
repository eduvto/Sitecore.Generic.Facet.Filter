using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.Framework.Rules;
using Sitecore.XConnect;
using System;
using System.Linq.Expressions;

namespace Etonon.Feature.GenericFacetFilter.Segmentation.Condition.Base
{
    public class GenericFacetRuleBase<T, C> : ICondition
        where T : IComparable, IConvertible, IComparable<T>, IEquatable<T>
        where C : Enum
    {
        public string FacetName { get; set; }

        public string FacetProperty { get; set; }

        public Type ComparisonType { get; set; }

        public C Comparison { get; set; }

        public T FacetValue { get; set; }

        // Evaluates condition for single contact
        public bool Evaluate(IRuleExecutionContext context)
        {
            var contact = context.Fact<Contact>();

            var xConnectFacets = contact?.Facets;
            if (xConnectFacets != null && xConnectFacets.ContainsKey(FacetName) && xConnectFacets[FacetName] != null)
            {
                var xConnectFacet = xConnectFacets[FacetName];
                var facetPropValue = xConnectFacet.GetType().GetProperty(FacetProperty)?.GetValue(xConnectFacet, null);
                if (facetPropValue == null)
                {
                    // When facet property value is null set its value as default type value based on the facetValue param type
                    var facetPropValueType = typeof(T);
                    facetPropValue = facetPropValueType.IsValueType ? Activator.CreateInstance(facetPropValueType) : "";
                }

                var valuesComparison = Expression.Call(ComparisonType.GetMethod("Evaluate", new Type[] { typeof(C), typeof(T), typeof(T) }),
                    Expression.Constant(Comparison),
                    Expression.Constant(facetPropValue),
                    Expression.Constant(FacetValue)
                );

                return Expression.Lambda<Func<bool>>(valuesComparison).Compile()();
            }
            return false;
        }
    }
}