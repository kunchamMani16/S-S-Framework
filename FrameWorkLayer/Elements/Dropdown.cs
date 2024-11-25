using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorkLayer.Elements
{
    public class Dropdown
    {
        private SelectElement selectElement;
       
        public void SelectElement(IWebElement element)
        {
            selectElement=new SelectElement(element);
        }

        public void SelectByText(string text)
        {
            selectElement.SelectByText(text);
        }

        
        public void SelectByValue(string value)
        {
            selectElement.SelectByValue(value);
        }

      
        public void SelectByIndex(int index)
        {
            selectElement.SelectByIndex(index);
        }

        public void DeselectByText(string text)
        {
            selectElement.DeselectByText(text);
        }

        
        public void DeselectByValue(string value)
        {
            selectElement.DeselectByValue(value);
        }

      
        public void DeselectByIndex(int index)
        {
            selectElement.DeselectByIndex(index);
        }

        public bool IsOptionSelected(string text)
        {
            
            return selectElement.SelectedOption.Text.Equals(text, StringComparison.OrdinalIgnoreCase);
        }
        

    }
}
