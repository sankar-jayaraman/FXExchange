namespace ExchangeTest
{

    using Exchange;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExchangeCommandLineValidationTest
    {
        private static readonly ICommandLineValidation _exchangeCommandLineValidation =
            new ExchangeCommandLineValidation();
       
        [TestMethod]
        public void Test_When_NoParametersArePassed_ItOutputsUsage()
        {

            Assert.IsFalse(_exchangeCommandLineValidation.ValidateCommandLine(new string[] {}));

        }

        [TestMethod]
        public void Test_When_OnlyExchangeRateIsPassed_ItOutputsUsage()
        {

            Assert.IsFalse(_exchangeCommandLineValidation.ValidateCommandLine(new string[] {"EUR/DKK"}));
        }

        [TestMethod]
        public void Test_When_OnlyAmountIsPassed_ItOutputsUsage()
        {

            Assert.IsFalse(_exchangeCommandLineValidation.ValidateCommandLine(new string[] { "1" }));
        }

        [TestMethod]
        public void Test_When_ExchangeRateIsPassedInWrongFormat_ItOutputsUsage()
        {

            Assert.IsFalse(_exchangeCommandLineValidation.ValidateCommandLine(new string[] { @"123/456", "1" }));
        }

        [TestMethod]
        public void Test_When_AmountIsPassedAsAnythingButNumerals_ItOutputsUsage()
        {

            Assert.IsFalse(_exchangeCommandLineValidation.ValidateCommandLine(new string[] {"EUR/DKK", "er.3"}));
        }

        [TestMethod]
        public void Test_When_MoreThanTwoParametersArePassed_ItOutputsUsage()
        {
            Assert.IsFalse(_exchangeCommandLineValidation.ValidateCommandLine(new string[] { "EUR/DKK", "er.3" , "blah"}));
        }

        [TestMethod]
        public void Test_When_ParametersArePassedCorrectly_ItReturnsTrue()
        {
            Assert.IsTrue(_exchangeCommandLineValidation.ValidateCommandLine(new string[] { "EUR/DKK", "3.5" }));
        }
    }
}
