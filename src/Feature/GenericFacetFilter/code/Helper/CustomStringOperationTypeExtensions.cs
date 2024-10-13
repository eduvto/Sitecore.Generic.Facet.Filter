using System;
using System.Runtime.CompilerServices;

namespace Etonon.Feature.GenericFacetFilter.Helper
{
    public static class CustomStringOperationTypeExtensions
    {
        public static bool IsNegativeEquality(this CustomStringOperationType operation) => operation == CustomStringOperationType.IsCaseInsensitiveAndNotEqualTo;

        public static bool Evaluate(this CustomStringOperationType operation, string left, string right)
        {
            if (left == null || right == null)
                return false;

            if (operation == CustomStringOperationType.IsCaseInsensitiveAndEqualTo)
                return left.Equals(right, StringComparison.InvariantCultureIgnoreCase);

            if (operation == CustomStringOperationType.IsCaseInsensitiveAndNotEqualTo)
                return left.Equals(right, StringComparison.InvariantCultureIgnoreCase);

            if (operation == CustomStringOperationType.StartsWith)
                return left.StartsWith(right);

            if (operation == CustomStringOperationType.EndsWith)
                return left.EndsWith(right);

            if (operation == CustomStringOperationType.Contains)
                return left.Contains(right);

            throw new ArgumentOutOfRangeException(FormattableString.Invariant(FormattableStringFactory.Create("Unrecognised StringOperationType : {0}", (object)operation)));
        }
    }
}