using FrameWorkLayer.Action;
using FrameWorkLayer.Elements;
using FrameWorkLayer.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    public abstract class BasePage
    {
        
        protected readonly WebAppUtilities webAppUtilities;
        protected readonly Dropdown dropdown;
        protected readonly ElementClass element;
        protected readonly ActionClass action;
        protected readonly WaitHelper waitHelper;
        protected readonly ScreenShot screenShot;
        protected BasePage() 
        {
            
            webAppUtilities = WebAppUtilities.Instance;
            waitHelper = new WaitHelper(webAppUtilities.GetDriver());
            dropdown = new Dropdown();
            element = new ElementClass(webAppUtilities.GetDriver());
            action = new ActionClass(webAppUtilities.GetDriver());
            screenShot = new ScreenShot(webAppUtilities.GetDriver());
        }
    }
}
