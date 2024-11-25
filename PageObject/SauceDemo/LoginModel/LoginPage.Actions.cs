using CsvHelper;
using FrameWorkLayer.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PageObject.SauceDemo.LoginModel
{
    public partial class LoginPage:BasePage
    {
        
        public void Navigate(string url)
        {
            webAppUtilities.NavigateUrl(url);
        }
        public void EnterUserName(string Username)
        {
            element.ClearAndSendKeys(_username, Username);
        }
        public void EnterPassword(string Password)
        {
            element.ClearAndSendKeys(_password,Password);
        }


        public void ClickLoginButton()
        {
            element.Click(loginbutton);
        }

    
        public void AssertLogin(bool shouldBeSuccessful)
        {
            element.AssertElementVisibility(assert, shouldBeSuccessful);
        }
        public void Quit()
        {
            webAppUtilities.Quit();
        }


    }
}
