using FrameWorkLayer.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PageObject.SauceDemo.LoginModel
{
   
    public partial class LoginPage:BasePage
    {
       

        public By _username = By.Id("user-name");
        public By _password = By.Id("password");
        public By loginbutton = By.Id("login-button");
        public By assert = By.XPath("//span[@data-test='title']");





    }

}
