using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using TechTalk.SpecFlow;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.SpecFlow.Profile
{
    [Binding]
     class SkillSteps
    {
        #region Add

        [Given(@"I clicked on the skill tab under Profile page")]
        public void GivenIClickedOnTheSkillTabUnderProfilePage()
        {
            //Wait
            GlobalDefinitions.wait(20);

            //Click on Skill tab 
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")).Click();
        
        }

        [When(@"I add a new skill")]
        public void WhenIAddANewSkill()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            //Click on add New button 
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            GlobalDefinitions.wait(20);

            //Add Skill
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill"));

            //Click on Skill Level
            IWebElement Skill = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            Skill.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillLevel"));
            Skill.Click();

            //Click on Add button
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]")).Click();

        }

        [Then(@"that skill should be displayed on my listings")]
        public void ThenThatSkillShouldBeDisplayedOnMyListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate Skill Added");


                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "Skill");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Added a Skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "SkillAdded");
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


        #region Edit

        [Given(@"I click on the skill tab under Profile Page")]
        public void GivenIClickOnTheSkillTabUnderProfilePage()
        {
            //Wait
            GlobalDefinitions.wait(20);

            //Click on Skill tab 
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")).Click();

        }

        [When(@"I edit the skill details")]
        public void WhenIEditTheSkillDetails()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            GlobalDefinitions.wait(30);
            try
            {
                for (var i = 1; i <= 10; i++)
                {

                    var textcode = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Console.WriteLine(textcode);
                    if (textcode == GlobalDefinitions.ExcelLib.ReadData(2, "Skill"))
                    {
                        //Wait
                        GlobalDefinitions.wait(30);

                        //Click the edit button
                        GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i")).Click();

                        //Clear the text and then write text
                        IWebElement SkillText = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                        SkillText.Clear();
                        SkillText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Skill"));

                        //Click on the dropdown menu
                        IWebElement SkillLevel = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[2]/select"));
                        SkillLevel.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "SkillLevel"));
                        SkillLevel.Click();

                        //Click update 
                        GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/span/input[1]")).Click();

                        break;
                    }

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Test Failed");
            }
        }

        [Then(@"That skill that have been edited should be displayed on my listings")]
        public void ThenThatSkillThatHaveBeenEditedShouldBeDisplayedOnMyListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate Skill Edited");


                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(3, "Skill");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Edit skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "SkillEdited");
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


        #region Delete

        [Given(@"I clicked on the skill tab under Profile Page")]
        public void GivenIClickedOnSkillTabUnderProfilePage()
        {
            //Wait
            GlobalDefinitions.wait(20);

            //Click on Skill tab 
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")).Click();

        }

        [When(@"I click delete button")]
        public void WhenIClickDeleteButton()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                for (var i = 1; i <= 10; i++)
                {
                    var textcode = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Console.WriteLine(textcode);
                    if (textcode == GlobalDefinitions.ExcelLib.ReadData(3, "Skill"))
                    {
                        //Wait
                        GlobalDefinitions.wait(20);

                        //Click the Delete button
                        GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();

                        break;
                    }

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Test Failed");
            }
        }

        [Then(@"the skill that got clicked should not be displayed on my listings")]
        public void ThenTheSkillThatGotClickedShouldNotBeDisplayedOnMyListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate Skill Deleted");


                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(3, "Skill");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;

                GlobalDefinitions.wait(10);

                if (!(ExpectedValue == ActualValue))
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Deleted Skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "SkillDeleted");
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
