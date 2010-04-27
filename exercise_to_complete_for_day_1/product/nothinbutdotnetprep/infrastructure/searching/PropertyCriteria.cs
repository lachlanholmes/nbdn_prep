using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class PropertyCriteria<ItemToSearch,PropertyType> : Criteria<ItemToSearch>
    {
        Func<ItemToSearch, PropertyType> accessor;
        Criteria<PropertyType> real_criteria;

        public PropertyCriteria(Func<ItemToSearch, PropertyType> accessor, Criteria<PropertyType> real_criteria)
        {
            this.accessor = accessor;
            this.real_criteria = real_criteria;
        }

        public bool is_satisfied_by(ItemToSearch item)
        {
            return real_criteria.is_satisfied_by(accessor(item));
        }
    }
}