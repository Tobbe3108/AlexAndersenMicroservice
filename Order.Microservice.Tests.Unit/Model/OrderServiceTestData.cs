using System;
using System.Collections;
using System.Collections.Generic;

namespace Order.Microservice.Tests.Unit.Model
{
    class OrderServiceTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, DateTime.Now, 1, "Updated", "1" };
            yield return new object[] { 1, DateTime.Now, "IdAsString", "Updated", "1" };
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
