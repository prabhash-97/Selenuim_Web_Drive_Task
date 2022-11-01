using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Selenuim_Web_Drive_Task
{
    public class Class1
    {
        IWebDriver m_driver;

        [SetUp]
        public void startBrowser()
        {
            m_driver = new ChromeDriver("C:\\Users\\UPRABKA\\Documents\\C# traning\\5 - Selenium Web Driver\\chromedriver_win32\\");
        }

        [Test]
        public void test()
        {
            
            m_driver.Url = "http://demo.guru99.com/test/guru99home/";
            m_driver.Manage().Window.Maximize();
		
            IWebElement emailTextBox = m_driver.FindElement(By.CssSelector("input[id=philadelphia-field-email]"));
            IWebElement signUpButton = m_driver.FindElement(By.XPath(".//*[@id='philadelphia-field-submit']"));
           
            emailTextBox.Clear();
            emailTextBox.SendKeys("test123@gmail.com");
            signUpButton.Click();

            var expectedAlertText = "Form Submitted Successfully...";
            var alert_win = m_driver.SwitchTo().Alert();

            Assert.AreEqual(expectedAlertText, alert_win.Text);
            alert_win.Accept();

        }

        [TearDown]
        public void closeBrowser()
        {
            m_driver.Close();
        }

    }
}
