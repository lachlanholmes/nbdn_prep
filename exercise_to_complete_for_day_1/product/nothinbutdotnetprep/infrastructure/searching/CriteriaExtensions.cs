using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public static class CriteriaExtensions
    {
        public static Criteria<T> or<T>(this Criteria<T> left_side, Criteria<T> right_side)
        {
            return new OrCriteria<T>(left_side, right_side);
        }

        public static Criteria<T> and<T>(this Criteria<T> left_side, Criteria<T> right_side)
        {
            return new AndCriteria<T>(left_side, right_side);
        }

        public static Criteria<T> equal_to<T, PropertyType>(this Func<T, PropertyType> accessor,
                                                          PropertyType value_to_match)
        {
            return new AnonymousCriteria<T>(t => accessor(t).Equals(value_to_match)); 
        }

				public static Criteria<T> not_equal_to<T, PropertyType>(this Func<T, PropertyType> accessor,
																													PropertyType value_to_match)
				{
					return new AnonymousCriteria<T>(someVal => !accessor(someVal).Equals(value_to_match));
				}

				public static Criteria<T> equal_to_any<T, PropertyType>(this Func<T, PropertyType> accessor,
																													params PropertyType[] values_to_match)
				{
					List<PropertyType> valuesList = new List<PropertyType>(values_to_match);
					return new AnonymousCriteria<T>(someVal => valuesList.Contains(accessor(someVal)));
				}
}
}