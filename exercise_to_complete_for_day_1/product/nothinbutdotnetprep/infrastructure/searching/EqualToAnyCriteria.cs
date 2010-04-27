using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class EqualToAnyCriteria<T> : Criteria<T>
    {
        IList<T> values;

        public EqualToAnyCriteria(IList<T> values)
        {
            this.values = values;
        }

        public bool is_satisfied_by(T item)
        {
            return values.Contains(item);
        }
    }
}