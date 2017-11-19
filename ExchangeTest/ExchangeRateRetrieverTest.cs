using System;
using Exchange;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ExchangeTest
{
	[TestClass]
    public class ExchangeRateRetrieverTest
    {
        private static int Multiplier = 100;
        private static double EURDKK = 743.94 / Multiplier;
        private static double USDDKK = 663.11 / Multiplier;
        private static double EURUSD = EURDKK/USDDKK;
        private static string MainCurrency = "EUR";
        private static string MoneyCurrency = "USD";
        private static string DKK = "DKK";

        [TestMethod]
        public void Test_When_MainCurrencyAndMoneyCurrencyAreTheSame_ItReturnsOne()
        {
            var mocks = new MockRepository(MockBehavior.Default);

            var exchageRateStore =  mocks.Create<IExchangeRateStore>();

            var logger = mocks.Create<ILogger>();

            var retriever = new ExchangeRateRetriever(exchageRateStore.Object, logger.Object);

            Assert.AreEqual(1.0, retriever.ExchangeRate(MainCurrency, MainCurrency));
        }

        [TestMethod]
        public void Test_When_MoneyCurrencyIsDKK_ItReturnsCorrectExchangeRate()
        {
            var mocks = new MockRepository(MockBehavior.Default);

            var logger = mocks.Create<ILogger>();

            var retriever = new ExchangeRateRetriever(new HardCodedExchangeRateStore(), logger.Object);

            Assert.AreEqual(EURDKK, retriever.ExchangeRate(MainCurrency, DKK));
        }

        [TestMethod]
        public void Test_When_MoneyCurrencyIsNotDKK_ItReturnsCorrectExchangeRate()
        {
            var mocks = new MockRepository(MockBehavior.Default);

            var logger = mocks.Create<ILogger>();

            var retriever = new ExchangeRateRetriever(new HardCodedExchangeRateStore(), logger.Object);

            Assert.AreEqual(EURUSD, retriever.ExchangeRate(MainCurrency, MoneyCurrency));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_When_MainOrMoneyCurrencyIsNotInStore_ItThrowsArgumentException()
        {
            var mocks = new MockRepository(MockBehavior.Default);

            var logger = mocks.Create<ILogger>();

            var retriever = new ExchangeRateRetriever(new HardCodedExchangeRateStore(), logger.Object);

            var d = retriever.ExchangeRate("ARS", DKK);    
            
        }
    }
}
