using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Xunit;

namespace CreditCards.UITests
{
    public class CreditCardTests
    {
        private const string HomeUrl = "http://localhost:44108/";
        private const string AboutUrl = "http://localhost:44108/Home/About";
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
                Pause(3000);

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
                Pause(3000);

                driver.Navigate().Refresh();

                //Assert
                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePageOnBack()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange

                //Act
                driver.Navigate().GoToUrl(HomeUrl);
                var initialToken = driver.FindElement(By.Id("GenerationToken")).Text;
                Pause();
                driver.Navigate().GoToUrl(AboutUrl);
                Pause();
                driver.Navigate().Back();
                Pause();

                var realoadedToken = driver.FindElement(By.Id("GenerationToken")).Text;

                //Assert
                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);

                Assert.NotEqual(initialToken, realoadedToken);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePageOnForward()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange

                //Act
                driver.Navigate().GoToUrl(AboutUrl);
                Pause();
                driver.Navigate().GoToUrl(HomeUrl);
                var initialToken = driver.FindElement(By.Id("GenerationToken")).Text;

                Pause();
                driver.Navigate().Back();
                Pause();

                driver.Navigate().Forward();
                var realoadedToken = driver.FindElement(By.Id("GenerationToken")).Text;
                Pause();

                //Assert
                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);

                Assert.NotEqual(initialToken, realoadedToken);
            }
        }

        private void Pause(int sleep = 2000)
        {
            if (sleep > 0)
                Thread.Sleep(sleep);
        }
    }
}
