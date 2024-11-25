using FrameWorkLayer.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using PageObject.SauceDemo.LoginModel;
using System.Globalization;
using BoDi;
using System.ComponentModel;

namespace Login.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly LoginPage login;
        private IEnumerable<dynamic> userdata;


        public LoginStepDefinitions(LoginPage login)
        {
            this.login = login;
        }

        [Given(@"I am in login page")]
        public void GivenIAmInLoginPage()
        {
            login.Navigate("https://www.saucedemo.com/");
        }

        




        [When(@"I entered username")]
        public void WhenIEnteredUsername()
        {
            login.EnterUserName("standard_user");
           
        }

        [When(@"I entered password")]
        public void WhenIEnteredPassword()
        {
            login.EnterPassword("secret_sauce");
        }
        [When(@"I enter username and password from data source csv as ""([^""]*)"" and ""([^""]*)""")]
        public void WhenIEnterUsernameAndPasswordFromDataSourceCsvAsAnd(string username, string password)
        {
            login.EnterUserName(username);
            login.EnterPassword(password);
        }
        
        [When(@"I entered username as ""([^""]*)""")]
        public void WhenIEnteredUsernameAs(string username)
        {
            
            login.EnterUserName(username);
        }

        [When(@"I entered password as ""([^""]*)""")]
        public void WhenIEnteredPasswordAs(string password)
        {
            
            login.EnterPassword(password);
        }



        [When(@"I Clicked login button")]
        public void WhenIClickedLoginButton()
        {
            login.ClickLoginButton();
        }



        [Then(@"logged in successfully")]
        public void ThenLoggedInSuccessfully()
        {
            login.AssertLogin(true);
        }
        [Then(@"logged  unsuccessfully")]
        public void ThenLoggedUnsuccessfully()
        {
            login.AssertLogin(false);
        }



    }
}
