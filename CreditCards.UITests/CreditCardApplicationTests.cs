using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Xunit;

namespace CreditCards.UITests
{
    [Trait("Category", "Applications")]
    public class CreditCardApplicationTests
    {
        private const string HomeUrl = "http://localhost:44108/";
        private const string ApplyUrl = "http://localhost:44108/Apply";

        [Fact]
        public void BeInitiatedFromHomePage_NewLowRate()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                Pause();

                var applyLink = driver.FindElement(By.Name("ApplyLowRate"));
                applyLink.Click();

                Pause();
                Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
                Assert.Equal(ApplyUrl, driver.Url);
            }
        }

        [Fact]
        public void BeInitiatedFromHomePage_EasyApplication()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                var buttonToMoveCarouselRight = driver.FindElement(By.CssSelector("[data-slide='next']")); 
                buttonToMoveCarouselRight.Click();
                Pause(1000);

                var applyLink = driver.FindElement(By.LinkText("Easy: Apply Now!"));
                applyLink.Click();

                Pause();
                Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
                Assert.Equal(ApplyUrl, driver.Url);
            }
        }

         private void Pause(int sleep = 2000)
        {
            if (sleep > 0)
                Thread.Sleep(sleep);
        }
    }
}
