using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Tests.SearchingTests
{
    class SequentialTests
    {
        List<int> Values = new List<int>();

        [SetUp]
        public void Setup()
        {
            var rnd = new Random();

            for (int i = 0; i < 100000; i++)
            {
                Values.Add(rnd.Next(1000));
            }

            Values.Add(1001);
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, true)]
        [TestCase(new[] { 2, 3, 4, 5, 1 }, true)]
        [TestCase(new[] { 0, 2, 3, 4, 5 }, false)]
        public void SequentialSearch_Test(IEnumerable<int> values, bool exists)
        {
            var found = Nutshell.Searching.Sequential.Exists(values, 1);
            Assert.AreEqual(found, exists);
        }

        [Test]
        public void SequentialSearch_Big_Test()
        {
            var found = Nutshell.Searching.Sequential.Exists(Values, 1);
            Assert.IsTrue(found);
        }
    }
}
