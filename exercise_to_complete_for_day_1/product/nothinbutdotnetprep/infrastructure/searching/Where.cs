using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToSearch>
    {
        public static ComparableCriteriaFactory<ItemToSearch, PropertyType> has_an<PropertyType>(Func<ItemToSearch, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparableCriteriaFactory<ItemToSearch, PropertyType> (new BasicCriteriaFactory<ItemToSearch, PropertyType>(accessor),accessor);
        }

        public static BasicCriteriaFactory<ItemToSearch, PropertyType> has_a<PropertyType>(Func<ItemToSearch, PropertyType> accessor)
        {
            return new BasicCriteriaFactory<ItemToSearch, PropertyType> (accessor);
        }
    }
}