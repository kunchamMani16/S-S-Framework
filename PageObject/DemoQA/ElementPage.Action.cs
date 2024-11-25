using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

namespace PageObject.DemoQA
{
    public  partial class ElementPage:BasePage
    {
        public void Navigate(string url)
        {
            webAppUtilities.NavigateUrl(url);
        }
        public void Check(By Locator)
        {

            Element = element.GetElement(Locator);
            waitHelper.FluentWait(Locator, 10, 200);
            action.ScrollToElement(Element);
            element.SelectElement(Element);
            elementState = true;
        } 
        public void Uncheck(By Locator)
        {
            Element = element.GetElement(Locator);
            element.DeSelectElement(Element);
            elementState = false;
        }
        public bool VerifyStateOfElement(bool expectedState)
        {
           return element.VerifyStateOfElement(expectedState, elementState);
        }

    }
}
