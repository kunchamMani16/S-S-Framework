using FrameWorkLayer.Elements;
using FrameWorkLayer.Utilities;
using Login.StepDefinitions;
using OpenQA.Selenium;
using PageObject.DemoQA;
using System;
using TechTalk.SpecFlow;

namespace TestLayer.StepDefinitions
{
    [Binding]
    public class RadioButtonStepDefinitions
    {
        private readonly ElementPage elementPage;
        private readonly LoggerUtility loggerUtility;
        private bool stateOfElement;
        private By locator;
        public RadioButtonStepDefinitions(ElementPage elementPage)
        {
            this.elementPage = elementPage;
            loggerUtility = LoggerUtility.Instance;
            loggerUtility.SetFile("ConfigLogger.xml");
            loggerUtility.GetLogger<CheckboxStepDefinitions>();
        }
        [Given(@"I am on the ""([^""]*)"" page")]
        public void GivenIAmOnThePage(string txt)
        {
            loggerUtility.LogInfo("Laun the Rdaio button Page for :- " + txt);
            elementPage.Navigate("https://artoftesting.com/samplesiteforselenium");   
        }

        [When(@"I select the ""([^""]*)"" radio button")]
        public void WhenISelectTheRadioButton(string text)
        {
            locator = elementPage.GetElementLocatorById(text);
            elementPage.Check(locator);

        }

        [Then(@"the ""([^""]*)"" radio button should be selected")]
        public void ThenTheRadioButtonShouldBeSelected(string option)
        {
           
            loggerUtility.LogInfo($"Checking The state of {option}");
            stateOfElement = elementPage.VerifyStateOfElement(true);
            loggerUtility.LogInfo($"State of Element is {stateOfElement}");
        }
    }
}
