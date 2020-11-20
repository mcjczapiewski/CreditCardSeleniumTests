using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Xunit;

namespace CreditCards.UITests
{
    public class SeleniumEasyTests
    {
        [Fact]
        [Trait("Category", "SeleniumEasy")]

        public void SingleInputField()
        {
            using (var driver = new ChromeDriver())
            {
                //Arrange
                const string TestUrl = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
                const string InputBoxId = "user-message";
                const string MyMessage = "Hello world!";
                const string ButtonName = "Show Message";
                const string DisplayId = "display";

                //Act
                driver.Navigate().GoToUrl(TestUrl);
                var closeAddButton = driver.FindElement(By.Id("at-cv-lightbox-close"));
                closeAddButton.Click();

                var inputBox = driver.FindElement(By.Id(InputBoxId));
                inputBox.SendKeys(MyMessage);

                var showButton = driver.FindElement(By.XPath($"//button[contains(text(),'{ButtonName}')]"));
                showButton.Click();

                //Assert
                var display = driver.FindElement(By.Id(DisplayId));
                Assert.Equal(MyMessage, display.Text);
            }
        }
    }
}
