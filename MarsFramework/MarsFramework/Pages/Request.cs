using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    internal class Request
    {


        public Request()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

       [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[1]")]
        private IWebElement ReceiveRequest { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[2]")]
        private IWebElement SentRequest { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/div[1]")]
        private IWebElement ClickManageRequests { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='received-request-section']/div[2]/h2")]
        private IWebElement ReceivedTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='sent-request-section']/div[2]/h2")]
        private IWebElement SentTitle { get; set; }


        public void ReceivedRequests()
        {
            GlobalDefinitions.wait(60);


            Actions builder = new Actions(Global.GlobalDefinitions.driver);
            builder.MoveToElement(ClickManageRequests).Build().Perform();
            ClickManageRequests.Click();

            GlobalDefinitions.wait(60);

            WebDriverWait wait = new WebDriverWait(GlobalDefinitions.driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(ReceiveRequest));

            ReceiveRequest.Click();

            Assert.That(ReceivedTitle.Text, Is.EqualTo("Received Requests"));

            Base.test.Log(LogStatus.Info, "Sucessully in Received Requests Page");



        }

        internal void SentRequests()
        {
            GlobalDefinitions.wait(120);

            Actions builder = new Actions(Global.GlobalDefinitions.driver);
            builder.MoveToElement(ClickManageRequests).Build().Perform();
            ClickManageRequests.Click();

            GlobalDefinitions.wait(60);

            WebDriverWait wait = new WebDriverWait(GlobalDefinitions.driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(SentRequest));
            SentRequest.Click();

            Assert.That(SentTitle.Text, Is.EqualTo("Sent Requests"));

            Base.test.Log(LogStatus.Info, "Sucessfully in Sent Requests Page");
        }
    }
}
