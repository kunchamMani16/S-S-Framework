using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace FrameWorkLayer.Utilities
{
    public class WaitHelper
    {
        private readonly IWebDriver driver;


        public WaitHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ImplicitWait(int sec)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(sec);
        }


        public void WaitForElementVisible(By locator, int timeOutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }
        public void WaitForElementClickable(By locator, int timeOutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));

        }

        public void WaitForElementToBePresent(By locator, int timeOutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(driver => driver.FindElements(locator).Count > 0);
        }

        public void WaitElementExsits(By locator, int timeOutInSeconds)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(ExpectedConditions.ElementExists(locator));


        }

        public void FluentWait(By locator, int timeOutInSeconds, int pollinginterval)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(timeOutInSeconds),
                PollingInterval = TimeSpan.FromMilliseconds(pollinginterval)
            };

            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement element = wait.Until(x => x.FindElement(locator));
        }


    }
}
