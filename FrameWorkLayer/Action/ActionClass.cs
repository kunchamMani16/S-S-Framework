using FrameWorkLayer.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorkLayer.Action
{
    public class ActionClass
    {

        private readonly IWebDriver driver;
        private Actions action;

        public ActionClass(IWebDriver driver)
        {
            action = new Actions(driver);
        }
        public void ScrollToElement(IWebElement webElement) => action.ScrollToElement(webElement).Perform();
        public void MoveToElemenet(IWebElement webElement) => action.MoveToElement(webElement).Perform();
        public void Click(IWebElement webElement) => action.Click(webElement).Perform();
        public void Click() => action.Click().Perform();

        
    }
}
