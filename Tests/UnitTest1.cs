using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test1(bool val)
        {
            Assert.IsTrue(val);
        }
    }
}