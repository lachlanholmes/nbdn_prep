using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ComparableCriteriaFactory<ItemToSearch, PropertyType> : CriteriaFactory<ItemToSearch, PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        CriteriaFactory<ItemToSearch, PropertyType> basic;
        Func<ItemToSearch, PropertyType> accessor;

        public ComparableCriteriaFactory(CriteriaFactory<ItemToSearch, PropertyType> basic, Func<ItemToSearch, PropertyType> accessor)
        {
            this.basic = basic;
            this.accessor = accessor;
        }

        public Criteria<ItemToSearch> equal_to_any(params PropertyType[] values)
        {
            return basic.equal_to_any(values);
        }

        public Criteria<ItemToSearch> equal_to(PropertyType value)
        {
            return basic.equal_to(value);
        }

        public Criteria<ItemToSearch> between(PropertyType start, PropertyType end)
        {
            return new PropertyCriteria<ItemToSearch, PropertyType>(accessor,
                                                                    new FallsInRangeCriteria<PropertyType>(
                                                                        new InclusiveRange<PropertyType>(start, end)));
        }

    }
}