using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using TechTalk.SpecFlow;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.SpecFlow.Request
{
    [Binding]
    public class RequestSteps
    {
        [Given(@"I am in profile page and hover over Manage Requests")]
        public void GivenIAmInProfilePageAndHoverOverManageRequests()
        {
            Actions builder = new Actions(Global.GlobalDefinitions.driver);
            IWebElement ClickManageRequests = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]"));
            builder.MoveToElement(ClickManageRequests).Build().Perform();
            ClickManageRequests.Click();
        }
       
        
        [When(@"I click on Received Requests")]
        public void WhenIClickOnReceivedRequests()
        {
            GlobalDefinitions.wait(60);

            IWebElement ReceiveRequest = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[1]"));
            WebDriverWait wait = new WebDriverWait(GlobalDefinitions.driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(ReceiveRequest));

            ReceiveRequest.Click();
        }

        [Then(@"it should display Received Requests")]
        public void ThenItShouldDisplayReceivedRequests()
        {
            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate Received Requests");

                GlobalDefinitions.wait(10);

                string ExpectedValue = "Received Requests";
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/h2")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, sent to Received Requests page Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Received Requests");
                }

                else
                    Base.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                Base.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

        [Given(@"I am in profile page and hover over Manage Request")]
        public void GivenIAmInProfilePageAndHoverOverManageRequest()
        {
            Actions builder = new Actions(Global.GlobalDefinitions.driver);
            IWebElement ClickManageRequests = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]"));
            builder.MoveToElement(ClickManageRequests).Build().Perform();
            ClickManageRequests.Click();
        }

        [When(@"I click on Sent Requests")]
        public void WhenIClickOnSentRequests()
        {

            GlobalDefinitions.wait(60);

            IWebElement SentRequest = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[2]"));
            WebDriverWait wait = new WebDriverWait(GlobalDefinitions.driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(SentRequest));
            SentRequest.Click();
        }

        [Then(@"it should display Sent Requests")]
        public void ThenItShouldDisplaySentRequests()
        {
            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate Sent Requests");

                GlobalDefinitions.wait(10);

                string ExpectedValue = "Sent Requests";
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/h2")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, sent to Sent Requests page Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Sent Requests");
                }

                else
                    Base.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                Base.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}
