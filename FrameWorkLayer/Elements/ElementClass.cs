using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorkLayer.Elements
{
    public class ElementClass
    {
        private readonly IWebDriver driver;
        public ElementClass(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement GetElement(By Locator)
        {
            WebDriverWait wait= new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return wait.Until(driver => driver.FindElement(Locator));
        }
        public void ClearAndSendKeys(By Locatar, string value)
        {
            GetElement(Locatar).Clear();
            GetElement(Locatar).SendKeys(value);
        }
        public void Click(By Locator) => GetElement(Locator).Click();

        public void submit(By locator) => GetElement(locator).Submit();


        public void AssertElementVisibility(By locator, bool shouldBeVisible)
        {
            try
            {
                var element = driver.FindElement(locator);
                Assert.That(element.Displayed, Is.EqualTo(shouldBeVisible));
            }
            catch (NoSuchElementException)
            {
                if (shouldBeVisible)
                {
                    Assert.Fail();
                }

            }
        }
        public void SelectElement(IWebElement element)
        {
            if (!element.Selected && element.Enabled)
            {
                element.Click();
            }
        }

        public void DeSelectElement(IWebElement element)
        {
            if (element.Selected && element.Enabled)
            {
                element.Click();
            }
        }
        public bool VerifyStateOfElement(bool expectedState, bool actualState)
        {
            if (expectedState != actualState)
            {
                throw new Exception($"Expected checkbox state to be {expectedState} but was {actualState}.");
            }
            return expectedState == actualState;
        }
    }
}
