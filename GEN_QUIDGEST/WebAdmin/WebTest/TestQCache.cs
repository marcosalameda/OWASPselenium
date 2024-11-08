using CSGenio.framework;
using NUnit.Framework;


namespace WebTest
{
    internal class TestQCache
    {
        private QCacheInstance qCache;

        [SetUp]
        public void SetUp()
        {
            qCache = new QCacheInstance();
        }


        [Test]
        public void PutSet()
        {
            qCache.Put("testKey", "testValue");
            var value = qCache.Get("testKey");
            Assert.AreEqual("testValue", value);
        }


        [Test]
        public void InvalidateCache()
        {
            qCache.Put("testKey", "testValue");

            qCache.Invalidate("testKey");
            var value = qCache.Get("testKey");

            Assert.IsNull(value);
        }

        [Test]
        public void TimeoutInPut()
        {
            qCache.Put("testKey", "testValue", TimeSpan.FromMilliseconds(50));

            var value = qCache.Get("testKey");
            Assert.AreEqual("testValue", value);

            Thread.Sleep(50);

            value = qCache.Get("testKey");
            Assert.IsNull(value);
        }
    }
}
