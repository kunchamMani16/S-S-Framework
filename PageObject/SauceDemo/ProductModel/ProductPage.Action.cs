using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject.SauceDemo.ProductModel
{
    public partial class ProductPage:BasePage
    {
        public void Naviagate(string url)
        {
            webAppUtilities.NavigateUrl(url);
        }
        public void Login(string Username, string Password)
        {

            element.ClearAndSendKeys(_username, Username);
            element.ClearAndSendKeys(_password, Password);
            element.Click(loginbutton);
        }
        public void SelectElementClass()
        {
            IWebElement _element = element.GetElement(dropdownSelectElement);
            dropdown.SelectElement(_element);

        }
        public void SelectOption(string option)
        {
            dropdown.SelectByText(option);
        }
        public void VerifyOptionSelection(string text)
        {
            bool isSelected = dropdown.IsOptionSelected(text);
            if (!isSelected)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
