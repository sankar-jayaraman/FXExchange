using Exchange;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExchangeTest
{
	[TestClass]
	public class ExchangeRateCalculatorTest
	{
		[TestMethod]
		public void Test_When_ValidCurrenciesAreGiven_Calculates_Amount_Correctly()
		{
			var exchangeRateRetriever = new Moq.Mock<IExchangeRateRetriever>();

			exchangeRateRetriever.Setup(x => x.ExchangeRate("EUR", "DKK"))
				.Returns(7.4394);

			var calculator = new SimpleExchangeRateCalculator(exchangeRateRetriever.Object);

			Assert.AreEqual(7.4394, calculator.Calculate("EUR", "DKK", 1.0));

		}
	}
}
