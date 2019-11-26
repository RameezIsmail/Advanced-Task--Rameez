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

namespace MarsFramework.SpecFlow.Sanity_Test
{
    [Binding]
    public class SanityTestSteps
    {
        [Given(@"I have clicked on sign out button")]
        public void GivenIHaveClickedOnSignOutButton()
        {
            GlobalDefinitions.wait(120);

            Actions builder = new Actions(Global.GlobalDefinitions.driver);
            IWebElement Signout = GlobalDefinitions.driver.FindElement(By.XPath("//*//button[contains(.,'Sign Out')]"));
            builder.MoveToElement(Signout).Build().Perform();

            WebDriverWait wait = new WebDriverWait(GlobalDefinitions.driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(Signout));

            Signout.Click();

            GlobalDefinitions.wait(120);
        }
        
        [When(@"I sign in and click on each tabs")]
        public void WhenISignInAndClickOnEachTabs()
        {
            #region Sign in
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a")).Click();

            GlobalDefinitions.wait(30);

            //Enter the data in Username textbox
            IWebElement Email = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));

            GlobalDefinitions.wait(10);

            //Enter the password 
            IWebElement Password = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));

            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Sanity Test Login");

            //Click on Login button
            GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button")).Click();

            GlobalDefinitions.wait(20);
            #endregion

            #region Profile
            //Click on Skill tab 
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")).Click();

            //Click on skill add New button 
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Sanity Skill");

            //Click on Education Tab
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")).Click();

            //Click on education Add New button
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")).Click();

            SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Sanity Education");

            //Click on Certifications Tab
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")).Click();

            //Click on certification Add new Button 
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div")).Click();

            SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Sanity Certification");

            // Click on Language tab
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")).Click();

            //Click on Add New button
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Sanity Language");
            #endregion

            #region SkillShare and ManageListing
            GlobalDefinitions.wait(20);

            GlobalDefinitions.driver.FindElement(By.XPath("//a[@href='/Home/ServiceListing']")).Click();

            SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Sanity ShareSkill");

            GlobalDefinitions.wait(20);

            GlobalDefinitions.driver.FindElement(By.XPath("//a[@href='/Home/ListingManagement']")).Click();

            SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Sanity ManageListing");
            #endregion

            #region Sign Out
            GlobalDefinitions.wait(120);

            Actions builder = new Actions(Global.GlobalDefinitions.driver);
            IWebElement Signout = GlobalDefinitions.driver.FindElement(By.XPath("//*//button[contains(.,'Sign Out')]"));
            builder.MoveToElement(Signout).Build().Perform();

            WebDriverWait wait = new WebDriverWait(GlobalDefinitions.driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(Signout));

            Signout.Click();

            #endregion
        }

        [Then(@"all the functions should still work correctly to the end")]
        public void ThenAllTheFunctionsShouldStillWorkCorrectlyToTheEnd()
        {
            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate Sanity Test");

                GlobalDefinitions.wait(10);

                string ExpectedValue = "Sign In";
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Sanity Test");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Sanity Testr");
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
