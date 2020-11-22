using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.SortingTests
{
    internal class BucketTests
    {
        List<int> Mixed = new List<int>();

        [SetUp]
        public void Setup()
        {
            var rnd = new System.Random();

            for (int i = 0; i < 100000; i++)
            {
                Mixed.Add(rnd.Next(1000));
            }
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, 5)]
        [TestCase(new[] { 5, 4, 3, 2, 1 }, 1, 5)]
        [TestCase(new[] { 4, 2, 5, 3, 1 }, 1, 5)]
        [TestCase(new[] { 1, 1, 1, 1, 1 }, 1, 1)]
        [TestCase(new[] { -1, 0, 1, 1, -2 }, -2, 1)]
        [TestCase(new[] { 10, 100, -10000, 100, 1 }, -10000, 100)]
        public void BucketSort_Test(IEnumerable<int> mixed, int min, int max)
        {
            var sorted = Nutshell.Sorting.Bucket.Sort(mixed, min, max).ToList();
            var prev = sorted.First();

            for (int i = 0; i < sorted.Count; i++)
            {
                Assert.IsTrue(sorted[i] >= prev);
                prev = sorted[i];
            }
        }

        [Test]
        public void BucketSortBig_Test()
        {
            var sorted = Nutshell.Sorting.Bucket.Sort(Mixed, 0, 1000).ToList();
            var prev = sorted.First();

            for (int i = 0; i < sorted.Count; i++)
            {
                Assert.IsTrue(sorted[i] >= prev);
                prev = sorted[i];
            }
        }
    }
}
