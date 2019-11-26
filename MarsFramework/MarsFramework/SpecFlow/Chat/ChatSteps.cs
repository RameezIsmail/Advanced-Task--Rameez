using AutoIt;
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

namespace MarsFramework.SpecFlow.Chat
{
    [Binding]
    public class ChatSteps
    {
        [Given(@"I am in profile page and click on manage listings tab")]
        public void GivenIAmInProfilePageAndClickOnManageListingsTab()
        {
            GlobalDefinitions.wait(20);

            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[3]")).Click();
        }

        [When(@"I click on view for one of the listing and click chat")]
        public void WhenIClickOnViewForOneOfTheListingAndClickChat()
        {
            GlobalDefinitions.wait(20);

            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[1]")).Click();

            GlobalDefinitions.wait(120);

            IWebElement chat = GlobalDefinitions.driver.FindElement(By.XPath("//a[@href='/Home/Message/?user=5d48afb95179e8000503c1f4']"));

            Actions builder = new Actions(GlobalDefinitions.driver);
            builder.MoveToElement(chat).Build().Perform();

            WebDriverWait wait = new WebDriverWait(GlobalDefinitions.driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(chat));

            chat.Click();

            GlobalDefinitions.wait(100);

            //driver.Navigate().Refresh();

            GlobalDefinitions.wait(500);

            IWebElement Chatbox = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='chatTextBox']"));
            wait.Until(ExpectedConditions.ElementToBeClickable(Chatbox));
            Chatbox.Click();
            Chatbox.SendKeys("Hello");

            GlobalDefinitions.wait(60);

            IWebElement SendButton = GlobalDefinitions.driver.FindElement(By.XPath("//button[contains(@id,'btnSend')]"));
            wait.Until(ExpectedConditions.ElementToBeClickable(SendButton));

            AutoItX.MouseMove(1500, 800);

            SendButton.Click();
        }

        [Then(@"it should display chat for that listing")]
        public void ThenItShouldDisplayChatForThatListing()
        {
            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate Chat");

                GlobalDefinitions.wait(10);

                string ExpectedValue = "Rameez";
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='chatList']/div[1]/div[2]/div[1]")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, sent to Chat Page Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Chat");
                }

                else
                    Base.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                Base.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

        [Given(@"I am in profile page")]
        public void GivenIAmInProfilePage()
        {
            GlobalDefinitions.wait(20);
            // Click on Language tab
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")).Click();
        }
                
        [When(@"I click on chat")]
        public void WhenIClickOnChat()
        {
            IWebElement ChatHis = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[1]"));

            Actions builder = new Actions(Global.GlobalDefinitions.driver);
            builder.MoveToElement(ChatHis).Build().Perform();

            WebDriverWait wait = new WebDriverWait(GlobalDefinitions.driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(ChatHis));

            ChatHis.Click();
        }
              
        [Then(@"it should display chat history")]
        public void ThenItShouldDisplayChatHistory()
        {
            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate Chat History");

                GlobalDefinitions.wait(10);

                string ExpectedValue = "Rameez";
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='chatList']/div[1]/div[2]/div[1]")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, sent to Chat History PAge Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Chat History");
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
