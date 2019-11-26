using AutoIt;
using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.SpecFlow.Profile
{
    [Binding]
    public class ProfileSteps
    {
        [Given(@"I am in profile page and click on edit button")]
        public void GivenIAmInProfilePageAndClickOnEditButton()
        {

            GlobalDefinitions.wait(60);

            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i")).Click();

        }

        [When(@"I update Availability")]
        public void WhenIUpdateAvailability()
        {

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");
            GlobalDefinitions.wait(60);

            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "AvailableTime"));
        }

        [Then(@"the result should be updated beside Availability")]
        public void ThenTheResultShouldBeUpdatedBesideAvailability()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Availability");

                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "AvailableTime");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Availability Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Availability");
                }

                else
                    Base.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                Base.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }


        }

        #region Hours
        [Given(@"I am in profile page and click edit button")]
        public void GivenIAmInProfilePageAndClickEditButton()
        {
            GlobalDefinitions.wait(60);

            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i")).Click();


        }

        [When(@"I update Hours")]
        public void WhenIUpdateHours()
        {

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            GlobalDefinitions.wait(60); 
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Hours"));
        }


        [Then(@"the result should be updated beside Hours")]
        public void ThenTheResultShouldBeUpdatedBesideHours()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Hours");

                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "Hours");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Hours Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Hours");
                }

                else
                    Base.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                Base.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
#endregion

        #region Earn Target
        [Given(@"I am in profile and click on edit button")]
        public void GivenIAmInProfileAndClickOnEditButton()
        {

            GlobalDefinitions.wait(60);

            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i")).Click();
        }
            
        [When(@"I update Earn Target")]
        public void WhenIUpdateEarnTarget()
        {

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");
            GlobalDefinitions.wait(60);

            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EarnTarget"));
        }
      
        [Then(@"the result should be updated beside Earn Target")]
        public void ThenTheResultShouldBeUpdatedBesideEarnTarget()
        {

            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Earn Target");

                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "EarnTarget");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Earn Target Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "EarnTarget");
                }

                else
                    Base.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                Base.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
        #endregion
    }
}
