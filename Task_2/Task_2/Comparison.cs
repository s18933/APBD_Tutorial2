using System;
using System.Collections.Generic;
using Task_2.Model;

namespace Task_2
{
    public class Comparison : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return StringComparer
                .InvariantCultureIgnoreCase
                .Equals($"{x.Name} {x.Surname}",
                        $"{y.Name} {y.Surname}");
        }
        public int GetHashCode(Student obj)
        {
            return StringComparer
                .CurrentCultureIgnoreCase
                .GetHashCode($"{obj.Name} {obj.Surname}");
        }
    }
}
