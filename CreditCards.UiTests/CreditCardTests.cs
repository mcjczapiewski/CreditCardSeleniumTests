using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace CreditCards.UiTests
{
    public class CreditCardTests
    {
        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadApplicationPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                const string homeUrl = "http://localhost:44108/";
                const string expectedPageTitle = "Home Page - Credit Cards";

                //Act
                driver.Navigate().GoToUrl(homeUrl);
                var pageTitle = driver.Title;
                Thread.Sleep(5000);

                //Assert
                Assert.Equal(expectedPageTitle, pageTitle);
                Assert.Equal(homeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                const string homeUrl = "http://localhost:44108/";

                //Act
                driver.Navigate().GoToUrl(homeUrl);
                var firstGuid = driver.FindElement(By.Id("GenerationToken")).Text;
                Thread.Sleep(2000);
                driver.Navigate().Refresh();
                var secondGuid = driver.FindElement(By.Id("GenerationToken")).Text;
                Thread.Sleep(2000);

                //Assert
                Assert.NotEqual(firstGuid, secondGuid);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePageOnBack()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                const string homeUrl = "http://localhost:44108/";
                const string aboutUrl = "http://localhost:44108/Home/About";
                const string expectedPageTitle = "Home Page - Credit Cards";

                //Act
                driver.Navigate().GoToUrl(homeUrl);
                driver.Navigate().GoToUrl(aboutUrl);
                driver.Navigate().Back();
                driver.Navigate().Forward();
                var pageTitle = driver.Title;
                var pageUrl = driver.Url;
                Thread.Sleep(2000);

                //Assert
                Assert.NotEqual(homeUrl, pageUrl);
                Assert.NotEqual(expectedPageTitle, pageTitle);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ClickEasyApplyNow()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                const string homeUrl = "http://localhost:44108/";
                const string buttonName = "Easy: Apply Now!";

                //Act
                driver.Navigate().GoToUrl(homeUrl);
                var buttonRight = driver.FindElement(By.ClassName("glyphicon-chevron-right"));
                Thread.Sleep(2000);
                
                buttonRight.Click();
                Thread.Sleep(2000);

                var buttonApply = driver.FindElement(By.XPath($"//a[contains(text(),'{buttonName}')]"));

                //Assert
            }
        }
    }
}
