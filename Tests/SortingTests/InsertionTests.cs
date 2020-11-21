using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.SortingTests
{
    class InsertionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new[] {1,2,3,4,5})]
        [TestCase(new[] {5,4,3,2,1})]
        [TestCase(new[] {4,2,5,3,1})]
        [TestCase(new[] {1,1,1,1,1})]
        public void InsertionSort_Test(IEnumerable<int> mixed)
        {
            var sorted = Nutshell.Sorting.Insertion.Sort(mixed).ToList();
            var prev = sorted.First();

            for (int i = 0; i < sorted.Count; i++)
            {
                Assert.IsTrue(sorted[i] >= prev);
                prev = sorted[i];
            }
        }
    }
}
