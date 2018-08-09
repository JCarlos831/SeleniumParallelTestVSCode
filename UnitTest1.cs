using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumParallelTestVSCode;

namespace Tests
{
    [TestFixture]
    [Parallelizable]
    public class FirefoxTesting : Hooks
    {
        public FirefoxTesting() : base(BrowserType.Firefox)
        {
        }

        [Test]
        public void FirefoxGoogleTest()
        {
            Driver.Navigate().GoToUrl("https://www.google.com");
            System.Threading.Thread.Sleep(5000);
            Driver.FindElement(By.Name("q")).SendKeys("Selenium" + Keys.Enter);
            Assert.That(Driver.PageSource.Contains("Selenium"), Is.EqualTo(true), "The text 'Selenium' does not exist.");
            Driver.Close();
        }
    }

    [TestFixture]
    [Parallelizable]
    public class ChromeTesting : Hooks
    {
        public ChromeTesting() : base(BrowserType.Chrome)
        {
        }

        [Test]
        public void ChromeGoogleTest()
        {
            Driver.Navigate().GoToUrl("https://www.google.com");
            Driver.FindElement(By.Name("q")).SendKeys("ExecuteAutomation" + Keys.Enter);
            Assert.That(Driver.PageSource.Contains("ExecuteAutomation"), Is.EqualTo(true), "The text 'ExecuteAutomation' does not exist.");
            Driver.Close();
        }
    }
}