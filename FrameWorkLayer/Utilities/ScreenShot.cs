using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorkLayer.Utilities
{
    public class ScreenShot
    {
        private readonly IWebDriver driver;
        public ScreenShot(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void GetScreenshot(string filename, string pathname, WebAppUtilities webAppUtilities)
        {
            GetDirectory(pathname);
            Screenshot screenshot = webAppUtilities.TakeScreenshot();
            screenshot.SaveAsFile(pathname + $"{filename}.jpg");
        }

        public string GetDirectory(string pathname)
        {
            if (!Directory.Exists(pathname))
            {
                Directory.CreateDirectory(pathname);
            }
            return pathname;
        }
    }
}
