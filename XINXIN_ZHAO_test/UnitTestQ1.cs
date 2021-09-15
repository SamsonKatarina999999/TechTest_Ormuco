using NUnit.Framework;
using System;
using static Q1.Q1;

namespace TestProject1
{
    public class UnitTestQ1
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LineTest()
        {
            Line line;
            line.v1 = 1;
            line.v2 = 2;
            line.ValueCheck();
            Assert.IsTrue(line.v1 < line.v2);
            line.v1 = 2;
            line.v2 = 1;
            line.ValueCheck();
            Assert.IsTrue(line.v1 < line.v2);
        }

        [Test]
        public void CrossTest()
        {
            Line l1, l2, l3, l4;
            l1.v1 = 3.3;
            l1.v2 = 12.3;
            l2.v1 = 4.4;
            l2.v2 = 11.4;
            l3.v1 = 1.1;
            l3.v2 = 5.5;
            l4.v1 = 6.6;
            l4.v2 = 11.4;
            Assert.IsTrue(IsCross(l1, l2));
            Assert.IsTrue(IsCross(l1, l3));
            Assert.IsTrue(IsCross(l2, l4));
            Assert.IsFalse(IsCross(l3, l4));
        }

    }
}