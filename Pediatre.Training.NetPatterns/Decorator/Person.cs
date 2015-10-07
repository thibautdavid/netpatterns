using System;
using System.Collections.Generic;

namespace Pediatre.Training.NetPatterns.Decorator
{
    internal static class Extensions
    {
        public static IComparer<T> Reversed<T>(this IComparer<T> inner)
        {
            return new ReverseComparer<T>(inner);
        }

        public static IComparer<Person> ThenBy(this IComparer<Person> inner, IComparer<Person> compareByAge)
        {
            return new ThenByComaprer<Person>(inner, compareByAge);
        }

        private class ReverseComparer<T> : IComparer<T>
        {
            private readonly IComparer<T> _inner;

            public ReverseComparer(IComparer<T> inner)
            {
                _inner = inner;
            }

            public int Compare(T x, T y)
            {
                return _inner.Compare(y, x);
            }
        }
        class ThenByComaprer<T> : IComparer<T>
        {
            private readonly IComparer<T> _left;
            private readonly IComparer<T> _right;

            public ThenByComaprer(IComparer<T> left, IComparer<T> right)
            {
                _left = left;
                _right = right;
            }

            public int Compare(T x, T y)
            {
                var result = _left.Compare(x, y);
                if (result == 0)
                {
                    return _right.Compare(x, y);
                }

                return result;
            }
        }
    }

    public class Person
    {
        public static readonly IComparer<Person> ByName = new CompareByName();
        public static readonly IComparer<Person> ByAge = new CompareByAge();
        
        public int Age  { get; set; }
        public string Name { get; set; }

        class CompareByName : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return String.Compare(x.Name, y.Name, StringComparison.Ordinal);
            }
        }

        public class CompareByAge : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x.Age.CompareTo(y.Age);
            }
        }
    }
}
