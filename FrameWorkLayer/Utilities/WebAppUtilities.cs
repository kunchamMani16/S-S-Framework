using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.Extensions;
using System;

namespace FrameWorkLayer.Utilities
{
    public sealed class WebAppUtilities
    {
        public IWebDriver driver;
        private static readonly WebAppUtilities instance = new WebAppUtilities();
        private WebAppUtilities() { }
        public static WebAppUtilities Instance
        {
            get
            {
                return instance;
            }
        }
        public void DriverInit(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome": driver = new ChromeDriver(); break;
                case "edge": driver = new EdgeDriver(); break;
                default: throw new ArgumentException("Browser not supported");
            }

        }
        

        public IWebDriver GetDriver() => driver;
        public void NavigateUrl(string url) => driver.Navigate().GoToUrl(url);
       
        public void MaximizeBrowser() => driver.Manage().Window.Maximize();
        public void NavigateBack() => driver.Navigate().Back();
        public void NavigateForward() => driver.Navigate().Forward();
        public Screenshot TakeScreenshot() => driver.TakeScreenshot();
        public void Close() => driver.Close();
        public void Quit() => driver.Quit();

        


    }
}
