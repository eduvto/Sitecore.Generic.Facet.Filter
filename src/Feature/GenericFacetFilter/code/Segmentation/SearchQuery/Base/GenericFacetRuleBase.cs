using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.XConnect;
using Sitecore.XConnect.Segmentation.Predicates;
using System;
using System.Linq.Expressions;

namespace Etonon.Feature.GenericFacetFilter.Segmentation.SearchQuery.Base
{
    public class GenericFacetRuleBase<T, C> : IContactSearchQueryFactory
        where T : IComparable, IConvertible, IComparable<T>, IEquatable<T>
        where C : Enum
    {
        public Guid FacetProperty { get; set; }

        public Type ComparisonType { get; set; }

        public C Comparison { get; set; }

        public T FacetValue { get; set; }

        public Expression<Func<Contact, bool>> CreateContactSearchQuery(IContactSearchQueryContext context)
        {
            try
            {
                var db = Database.GetDatabase("master");
                var facetPropertyItem = db.GetItem(new ID(FacetProperty));

                var facetPropertyName = facetPropertyItem.Name;
                var facetItem = facetPropertyItem?.Parent;
                var facetName = facetItem.Name;
                var facetNamespace = facetItem.Fields[Constants.Facet.Fields.Namespace].Value;

                //Comparison.Evaluate(contact.GetFacet<FacetType>(FacetName).FacetProperty, FacetValue);
                var contactParameter = Expression.Parameter(typeof(Contact));

                var facet = Expression.Call(contactParameter, "GetFacet", new[] { Type.GetType(facetNamespace) }, Expression.Constant(facetName));

                var facetProperty = Expression.Property(facet, facetPropertyName);
                if (Nullable.GetUnderlyingType(facetProperty.Type) != null)
                    facetProperty = Expression.Property(facetProperty, "Value");

                var facetValue = Expression.Constant(FacetValue);
                var valuesComparison = Expression.Call(ComparisonType.GetMethod("Evaluate", new Type[] { typeof(C), typeof(T), typeof(T) }), Expression.Constant(Comparison), facetProperty, facetValue);

                return Expression.Lambda<Func<Contact, bool>>(valuesComparison, contactParameter);
            }
            catch (Exception ex)
            {
                Log.Error("Error trying CreateContactSearchQuery.", ex, this);
                throw ex;
            }
        }
    }
}