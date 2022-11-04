using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace Selenuim_Web_Drive_Task
{
    public class Class1
    {
        string testURL = "http://demo.guru99.com/test/guru99home/";
        IWebDriver m_driver;

        [SetUp]
        public void startBrowser()
        {
            m_driver = new ChromeDriver("C:\\Users\\UPRABKA\\Documents\\C# traning\\5 - Selenium Web Driver\\chromedriver_win32\\");
            m_driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test()
        {

            m_driver.Url = testURL;
            m_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            IWebElement course = m_driver.FindElement(By.XPath(".//*[@id='awf_field-91977689']"));
            IWebElement emailTextBox = m_driver.FindElement(By.CssSelector("input[id=philadelphia-field-email]"));

            WebDriverWait wait = new WebDriverWait(m_driver, TimeSpan.FromSeconds(50));
            IWebElement signUpButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(".//*[@id='philadelphia-field-submit']")));

            var selectTest = new SelectElement(course);
            selectTest.SelectByValue("sap-abap");

            m_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

            emailTextBox.Clear();
            emailTextBox.SendKeys("test123@gmail.com");
    
            signUpButton.Click();

            var expectedAlertText = "Form Submitted Successfully...";
            var alert_win = m_driver.SwitchTo().Alert();

            Assert.AreEqual(expectedAlertText, alert_win.Text);

            m_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            alert_win.Accept();

        }

        [TearDown]
        public void closeBrowser()
        {
            m_driver.Close();
        }

    }
}
