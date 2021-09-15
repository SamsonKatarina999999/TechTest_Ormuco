using NUnit.Framework;
using Q3;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestProject1
{
    class UnitTestQ3
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CapacityTest()
        {
            LRUCache.Clean();
            LRUCache lRUCache = LRUCache.GetInstance(4, new TimeSpan(0, 0, 30));

            lRUCache.Put(1, "a");
            lRUCache.Put(2, "b");
            lRUCache.Put(3, "c");
            lRUCache.Put(4, "d");
            lRUCache.Put(5, "e");
            lRUCache.Put(1, "a");
            lRUCache.Put(2, "b");
            lRUCache.Put(3, "c");
            Assert.AreEqual("c", lRUCache.GetHead());
            Assert.AreEqual("e", lRUCache.GetTail());
            Assert.AreEqual(4, lRUCache.Count);
        }

        [Test]
        public void ExpireTest()
        {
            LRUCache.Clean();
            LRUCache lRUCache = LRUCache.GetInstance(7, new TimeSpan(0, 0, 1));
            lRUCache.Put(1, "a");
            Thread.Sleep(3000);
            lRUCache.RemoveExpiredNodes();
            Assert.AreEqual(0, lRUCache.Count);
        }
    }
}
