using FrameWorkLayer.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject.DemoQA;
using System;
using System.IO;
using TechTalk.SpecFlow;
using static System.Net.Mime.MediaTypeNames;

namespace Login.StepDefinitions
{
    [Binding]
    public class CheckboxStepDefinitions
    {

        private readonly ElementPage elementPage;
        private readonly LoggerUtility loggerUtility;
        private bool stateOfElement;
        private By locator;
        public CheckboxStepDefinitions(ElementPage elementPage)
        {
            this.elementPage = elementPage;
            loggerUtility = LoggerUtility.Instance;
            loggerUtility.SetFile("ConfigLogger.xml");
            loggerUtility.GetLogger<CheckboxStepDefinitions>();

        }

       
        [Given(@"I am on the checkbox test page")]
        public void GivenIAmOnTheCheckboxTestPage()
        {
            elementPage.Navigate("https://demoqa.com/checkbox");
            
        }

        [When(@"I select the checkbox  ""([^""]*)""")]
        public void WhenISelectTheCheckbox(string home)
        {
            locator = elementPage.GetElementLocatorByTextWithSpan(home);
            elementPage.Check(locator);
            
        }

        
        [Then(@"the checkbox with ""([^""]*)"" should be selected")]
        public void ThenTheCheckboxWithShouldBeSelected(string home)
        {
            
            loggerUtility.LogInfo($"Checking The state of {home}");
            stateOfElement=elementPage.VerifyStateOfElement(true);
            loggerUtility.LogInfo($"State of Element is {stateOfElement}");
           
        }

        [When(@"I deselect the checkbox with ""([^""]*)""")]
        public void WhenIDeselectTheCheckboxWith(string home)
        {
            locator = elementPage.GetElementLocatorByTextWithSpan(home);
            elementPage.Uncheck(locator);

        }

        [Then(@"the checkbox with ""([^""]*)"" should not be selected")]
        public void ThenTheCheckboxWithShouldNotBeSelected(string home)
        {
           
            loggerUtility.LogInfo($"Checking The state of {home}");
            stateOfElement=elementPage.VerifyStateOfElement(false);
            loggerUtility.LogInfo($"State of Element is {stateOfElement}");
        }


        [When(@"I check the state of the checkbox")]
        public void WhenICheckTheStateOfTheCheckbox()
        {
          
            stateOfElement = elementPage.elementState;
            loggerUtility.LogInfo($"State of Element is {stateOfElement}");
        }





    }
}
