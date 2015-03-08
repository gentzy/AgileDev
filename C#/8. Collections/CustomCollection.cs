using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6.Collections
{
    class CustomCollection<T> : IEnumerable<T>
    {
        private Dictionary<int, T> m_employees;

        public CustomCollection(Dictionary<int, T> employees)
        {
            m_employees = employees;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (KeyValuePair<int, T> pair in m_employees)
            {
                yield return pair.Value;
            }
        }

        // Must also implement IEnumerable.GetEnumerator, because IEnumerable<T> inherits from IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
