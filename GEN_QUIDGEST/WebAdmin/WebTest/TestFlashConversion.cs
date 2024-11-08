using NUnit.Framework;

using CSGenio.business;
using CSGenio.persistence;
using CSGenio.framework;

namespace WebTest
{

    /// <summary>
    ///This is a test class for Test and is intended
    ///to contain all Test Unit Tests
    ///</summary>
    public class TestFlashConversion
    {

        /// <summary>
        /// Teste à função ToDateTime
        /// </summary>
        [Test]
        public void TestToDateTime()
        {
            DateTime res;
            DateTime expected;

            // null --> DateTime.MinValue
            res = FlashConversion.ToDateTime(null);
            Assert.AreEqual(DateTime.MinValue, res);

            // DateTime.MinValue --> DateTime.MinValue
            res = FlashConversion.ToDateTime(DateTime.MinValue);
            Assert.AreEqual(DateTime.MinValue, res);

            // DateTime.Now ok
            expected = DateTime.Now;
            res = FlashConversion.ToDateTime(expected);
            Assert.AreEqual(expected, res);

            // DateTime.Today ok
            expected = DateTime.Today;
            res = FlashConversion.ToDateTime(expected);
            Assert.AreEqual(expected, res);

            // 1900-01-01 ok
            expected = new DateTime(1900, 1, 1);
            res = FlashConversion.ToDateTime(expected);
            Assert.AreEqual(expected, res);

            // 1999-12-31 ok
            expected = new DateTime(1999, 12, 31);
            res = FlashConversion.ToDateTime(expected);
            Assert.AreEqual(expected, res);

            // 2012-12-22 ok [the world has ended yet]
            expected = new DateTime(2012, 12, 22);
            res = FlashConversion.ToDateTime(expected);
            Assert.AreEqual(expected, res);

            // DateTime.MaxValue ok
            res = FlashConversion.ToDateTime(DateTime.MaxValue);
            Assert.AreEqual(DateTime.MaxValue, res);

            // a string --> exception
            Assert.Throws<FormatException>(() =>
            {
                res = FlashConversion.ToDateTime("blablabla");
            });

            // an integer --> exception
            Assert.Throws<InvalidCastException>(() =>
            {
                res = FlashConversion.ToDateTime(20110411);
            });
        }

        /// <summary>
        ///Teste à função FromDateTime
        /// </summary>
        [Test]
        public void TestFromDateTime()
        {
            string res = null;

            res = FlashConversion.FromDateTime(DateTime.MinValue, true, true);
            Assert.AreEqual("", res);

            res = FlashConversion.FromDateTime(new DateTime(1900, 2, 1), true, true);
            Assert.AreEqual("1900/02/01 00:00:00", res);
        }


    }
}
