using OpenQA.Selenium;
using System.IO;
using System.Reflection;


namespace PageObject.DemoQA
{
    public partial class ElementPage : BasePage
    {
       
       
        public string path = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/Screenshots/";
        public IWebElement Element;
        public bool elementState;

        public By GetElementLocatorByTextWithSpan(string text)
        {
            string xpath = $"//span[text()='{text}']";
            return By.XPath(xpath);
        } 
        public By GetElementLocatorById(string text)
        {
            return By.Id(text);
            
        }


       
    }
}
