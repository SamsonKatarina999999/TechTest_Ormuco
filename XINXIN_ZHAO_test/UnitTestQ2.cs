using NUnit.Framework;
using System;
using static Q2.Q2;

namespace TestProject1
{
    public class UnitTestQ2
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VersionTest()
        {
            string v1 = "1.3.4";
            string v2 = "2.3.4";
            string v3 = "2.3.4.1";
            string v4 = "2.3.4.";
            Assert.IsTrue(VersionComparator(v1, v2));
            Assert.IsFalse(VersionComparator(v2, v1));
            Assert.IsTrue(VersionComparator(v2, v3));
            Assert.IsFalse(VersionComparator(v3, v2));
            Assert.IsTrue(VersionComparator(v1, v3));
            Assert.IsFalse(VersionComparator(v3, v1));
            Assert.Throws<System.FormatException>(delegate { VersionComparator(v3, v4); });
        }
    }
}
