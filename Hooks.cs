using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumParallelTestVSCode
{
    public enum BrowserType
    {
        Chrome,
        Firefox
    }
    [TestFixture]
    public class Hooks : Base
    {
        private BrowserType _browserType;
        public Hooks(BrowserType browser)
        {
            _browserType = browser;
        }

        [SetUp]
        public void InitializeTest()
        {
            ChooseDriverInstance(_browserType);
        }

        private void ChooseDriverInstance(BrowserType browserType)
        {
            if (browserType == BrowserType.Chrome)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--headless");
                Driver = new ChromeDriver(options);
            }
            else if (browserType == BrowserType.Firefox)
            {
                FirefoxOptions option = new FirefoxOptions();
                option.AddArgument("--headless");
                Driver = new FirefoxDriver("/Users/JuanCMontoya/Desktop", option);
            }
        }
    }
}