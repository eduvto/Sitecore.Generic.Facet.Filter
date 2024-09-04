using Sitecore.Diagnostics;
using System;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using Sitecore.Analytics;
using Sitecore.Analytics.XConnect.Facets;
using Sitecore.Analytics.Model;
using Sitecore.Data;

namespace Etonon.Feature.GenericFacetFilter.Personalize.Base
{
    public class GenericFacetRuleBase<T, T2> : WhenCondition<T>
        where T : RuleContext
        where T2 : IComparable, IConvertible, IComparable<T2>, IEquatable<T2>
    {
        public Guid FacetProperty { get; set; }

        public string OperatorId { get; set; }

        public T2 FacetValue { get; set; }

        protected Func<T2, T2, bool> CompareTo { get; set; }

        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull(ruleContext, "ruleContext");
            Assert.IsNotNull(Tracker.Current, "Tracker.Current is not initialized");
            Assert.IsNotNull(Tracker.Current.Session, "Tracker.Current.Session is not initialized");
            Assert.IsNotNull(Tracker.Current.Session.Interaction, "Tracker.Current.Session.Interaction is not initialized");

            var contact = Tracker.Current.Contact;

            if (contact?.IdentificationLevel != ContactIdentificationLevel.Known)
                return false;

            var facetPropertyItem = Sitecore.Context.Database.GetItem(new ID(FacetProperty));
            var facetItem = facetPropertyItem?.Parent;
            if (facetItem == null || facetPropertyItem == null)
            {
                Log.Error("Error while processing generic facet personalize rule. Facet Property cannot be empty", this);
                return false;
            }

            var facetName = facetItem.Name;
            var facetPropertyName = facetPropertyItem.Name;
            var xConnectFacets = contact.GetFacet<IXConnectFacets>("XConnectFacets")?.Facets;
            if (xConnectFacets == null || !xConnectFacets.ContainsKey(facetName) || xConnectFacets[facetName] == null)
                return false;

            var xConnectFacet = xConnectFacets[facetName];
            var facetPropValue = xConnectFacet.GetType().GetProperty(facetPropertyName)?.GetValue(xConnectFacet, null);
            if (facetPropValue == null)
            {
                // When facet property value is null set its value as default type value based on the facetValue param type
                var facetPropValueType = typeof(T2);
                facetPropValue = facetPropValueType.IsValueType ? Activator.CreateInstance(facetPropValueType) : "";
            }
            return CompareTo((T2)facetPropValue, FacetValue);
        }
    }
}