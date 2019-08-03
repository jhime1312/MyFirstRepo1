using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTestSolution
{
    [TestClass]
    public class Class1
    {
        //framework base:  c#
        //ui frmaework: selenium web driver
        //clasificar y correr test --> unit framekork: MsTest

        IWebDriver webDriver;

        public Class1()
        {
            webDriver = new ChromeDriver(@"E:\jhime\QA Automation\seleniumWebDriver"); // agregar @ para corregir los errores en la ruta
        }

        [TestMethod]
        public void MyFirstTest()
        {
            //navigate to automation practice site
            webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php");

            //capture contact us botton
            IWebElement contactUsButton = webDriver.FindElement(By.Id("contact-link")); //capturamos ese control
            contactUsButton.Click(); //le enviamos la funcion que deberia hacer. 

            //capture subject heading combo box
            IWebElement subejecjtHeading = webDriver.FindElement(By.Id("id_contact"));
            SelectElement subjectHeadingCombobox = new SelectElement(subejecjtHeading);
            //customer service
            subjectHeadingCombobox.SelectByText("Customer service");

            //capture email address input
            IWebElement emailAddressInput = webDriver.FindElement(By.Name("from")); //good practice: nombrar bien las variables
            emailAddressInput.SendKeys("daniel.terceros.b@gmail.com");

            //id_order
            IWebElement orderReferenceInput = webDriver.FindElement(By.Name("id_order"));
            orderReferenceInput.SendKeys("1234");

            // file upload
            IWebElement attachFile = webDriver.FindElement(By.Id("fileUpload"));
            attachFile.SendKeys(@"E:\jhime\QA Automation\file.txt");

            //message
            IWebElement messageInput = webDriver.FindElement(By.Id("message"));
            messageInput.SendKeys("Test message");

            // submit message
            IWebElement SendButton = webDriver.FindElement(By.Id("submitMessage"));
            SendButton.Click();

            //your message has been successfully sent to our team
            ////p[@class='alert alert-success']
            IWebElement confirmationLabel = webDriver.FindElement(By.XPath("//p[@class='alert alert-success']"));
            string actualMessage = confirmationLabel.Text;
            string expectedMessage = "Your message has been successfully sent to our team"; //expected data

            Assert.AreEqual(expectedMessage, actualMessage);

        }
    }

}
