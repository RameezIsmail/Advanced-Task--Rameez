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

namespace MarsFramework.SpecFlow.Profile
{
    [Binding]
    public class DescriptionSteps
    {
        [Given(@"Im in profile page and click on edit button")]
        public void GivenImInProfilePageAndClickOnEditButton()
        {

            GlobalDefinitions.wait(20);

            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i")).Click();

        }

        [When(@"I update Description")]
        public void WhenIUpdateDescription()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            GlobalDefinitions.wait(20);

            IWebElement Description = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea"));

            Description.Click();

            GlobalDefinitions.wait(20);

            Description.Clear();

            Description.SendKeys(Keys.Control + "a");

            Description.SendKeys(Keys.Backspace);

            GlobalDefinitions.wait(20);

            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Description"));

            GlobalDefinitions.wait(20);

            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button")).Click();

        }

        [Then(@"the description box should be updated")]
        public void ThenTheDescriptionBoxShouldBeUpdated()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate Description");

                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "Description");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, updated Desciprtion Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Description");
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
