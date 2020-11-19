using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Xunit;

namespace CreditCards.UITests
{
    public class CreditCardTests
    {
        private const string HomeUrl = "http://localhost:44108/";
        private const string HomeTitle = "Home Page - Credit Cards";
        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadApplicationPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange

                //Act
                driver.Navigate().GoToUrl(HomeUrl);
                Thread.Sleep(3000);

                //Assert
                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange

                //Act
                driver.Navigate().GoToUrl(HomeUrl);
                Thread.Sleep(3000);

                driver.Navigate().Refresh();

                //Assert
                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);
            }
        }
    }
}
