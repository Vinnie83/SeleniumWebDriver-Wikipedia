using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriverNunitDemo
{
    public class WebDriverTests
    {

        private WebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }

        [Test]
        public void Test_Wikipedia_CheckTitle()
        {
            driver.Url = "https://wikipedia.org";

            var pageTitle = driver.Title;

            Assert.That("Wikipedia",Is.EqualTo(pageTitle));
        }

        [Test]
        public void Test_Wikipedia_SearchField()
        {
            driver.Url = "https://wikipedia.org";

            var searchField = driver.FindElement(By.Id("searchInput"));
            searchField.SendKeys("QA" + Keys.Enter);

            var pageTitle = driver.Title;

            Assert.That("QA - Wikipedia", Is.EqualTo(pageTitle));
        }

        [Test]
        public void Test_Wikipedia_CheckDeutsch()
        {
            driver.Url = "https://wikipedia.org";

            var allStrongElements = driver.FindElements(By.TagName("strong"));

            var deutschLinkText = allStrongElements[5].Text;

            Assert.That("Deutsch", Is.EqualTo(deutschLinkText));
        }

        [Test]
        public void Test_Wikipedia_CheckEnglish()
        {
            driver.Url = "https://wikipedia.org";

            var allStrongElements = driver.FindElements(By.TagName("strong"));

            var englishLinkText = allStrongElements[1].Text;

            Assert.That("English", Is.EqualTo(englishLinkText));
        }

    }
}