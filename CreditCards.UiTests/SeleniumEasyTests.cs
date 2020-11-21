using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace CreditCards.UiTests
{
    public class SeleniumEasyTests
    {
        [Fact]
        [Trait("Category", "Smoke")]
        public void SingleInputField()
        {
            var homeUrl = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";

            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                const string inputText = "Stop the count!";
                const string buttonName = "Show Message";

                //Act
                driver.Navigate().GoToUrl(homeUrl);
                Thread.Sleep(1500);
                
                var closeAdd = driver.FindElement(By.Id("at-cv-lightbox-close"));
                closeAdd.Click();
                Thread.Sleep(2000);

                var inputBox = driver.FindElement(By.Id("user-message"));
                inputBox.SendKeys(inputText);
                Thread.Sleep(2000);
                
                var showButton = driver.FindElement(By.XPath($"//button[contains(text(),'{buttonName}')]"));
                showButton.Click();

                var display = driver.FindElement(By.Id("display"));

                //Assert
                Assert.Equal(inputText, display.Text);
            }
        }
    }
}
