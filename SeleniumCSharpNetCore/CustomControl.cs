using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeleniumCSharpNetCore
{
    public class CustomControl: DriverHelper
    {
        public static void ComboBox(string controlName, string value) 
        {
            IWebElement comboControl = Driver.FindElement(By.XPath($"//input[@id='{controlName}-awed']"));

            comboControl.Clear();
            comboControl.SendKeys(value);
            Driver.FindElement(By.XPath($"//div[@id='{controlName}-dropmenu']//li[text()='{value}']")).Click();
        }


        public static void EnterText(IWebElement WebElement, string value) => WebElement.SendKeys(value);


        public static void Click(IWebElement WebElement) => WebElement.Click();

        public static void SelectByValue(IWebElement WebElement, string value)
        {
            SelectElement selectElement = new SelectElement(WebElement);
            selectElement.SelectByValue(value);
        }

        public static void SelectByText(IWebElement WebElement, string text)
        {
            SelectElement selectElement = new SelectElement(WebElement);
            selectElement.SelectByText(text);
        }


    }
}
