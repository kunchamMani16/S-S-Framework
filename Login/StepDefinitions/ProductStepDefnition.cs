using OpenQA.Selenium;
using PageObject.DemoQA;
using PageObject.SauceDemo.ProductModel;
using System;
using TechTalk.SpecFlow;

namespace Login.StepDefinitions
{
    [Binding]
    public class ProductStepDefnition
    {
        
        private readonly ProductPage productPage;
        public ProductStepDefnition(ProductPage productPage)
        {
            this.productPage = productPage;
        }

        [Given(@"I need to Logged in and see the Product page")]
        public void GivenINeedToLoggedInAndSeeTheProductPage()
        {
            productPage.Naviagate("https://www.saucedemo.com/");
            productPage.Login("standard_user", "secret_sauce");
        }

        [When(@"I select the option ""([^""]*)"" from the dropdown")]
        public void WhenISelectTheOptionFromTheDropdown(string text)
        {
            productPage.SelectElementClass();
            productPage.SelectOption(text);
        }

        [Then(@"The option ""([^""]*)"" should be selected")]
        public void ThenTheOptionShouldBeSelected(string text)
        {
            productPage.VerifyOptionSelection(text);
        }
    }
}
