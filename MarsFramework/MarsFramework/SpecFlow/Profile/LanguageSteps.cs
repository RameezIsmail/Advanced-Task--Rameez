using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using TechTalk.SpecFlow;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Specflow
{
    [Binding]
    class LanguageSteps : Base
    {


        #region Add
        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {

            GlobalDefinitions.wait(20);
            // Click on Language tab
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")).Click();

        }


        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            //Click on Add New button
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            GlobalDefinitions.wait(20);

            //Add Language
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Language"));

            //Click on Language Level
            IWebElement Lang = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            Lang.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LanguageLevel"));
            Lang.Click();

            GlobalDefinitions.wait(20);

            //Click on Add button
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();

        }


        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                //Start the Reports
                test = extent.StartTest("Validate Language Added");

                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "Language");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "LanguageAdded");
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
        [Given(@"I click on the language tab under Profile Page")]
        public void GivenIClickOnTheLanguageTabUnderProfilePage()
        {
            GlobalDefinitions.wait(20);
            // Click on Language tab
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")).Click();

        }


        [When(@"I edit the language details")]
        public void WhenIEditTheLanguageDetails()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

             for (var i = 1; i <= 10; i++)
             {
                 var textcode = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                 Console.WriteLine(textcode);
                 if (textcode == GlobalDefinitions.ExcelLib.ReadData(2, "Language"))
                 {
                     //Wait
                     GlobalDefinitions.wait(10);

                     //Click the edit button
                     GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i")).Click();


                     GlobalDefinitions.wait(30);

                     //Clear the text and then write Konglish
                     IWebElement Lang = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                     Lang.Clear();
                     Lang.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Language"));

                     GlobalDefinitions.wait(30);

                     //Click on the dropdown menu
                     IWebElement LangLevel = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[2]/select"));
                     LangLevel.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "LanguageLevel"));
                     LangLevel.Click();

                     //Click update
                     GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/span/input[1]")).Click();

                    break;
                }

            }

        }


        [Then(@"that language that been edited should be displayed on my listings")]
        public void ThenThatLanguageThatBeenEditedShouldBeDisplayedOnMyListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                //Start the Reports
                test = extent.StartTest("Validate Language Edit");

                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(3, "Language");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Edited a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "LanguageEdited");
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
        [Given(@"I clicked on the Languages tab under Profile Page")]
        public void GivenIClickedOnTheLanguagesTabUnderProfilePage()
        {
            GlobalDefinitions.wait(20);
            // Click on Language tab
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")).Click();

        }


        [When(@"I click on the delete button")]
        public void WhenIClickOnTheDeleteButton()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                for (var i = 1; i <= 10; i++)
                {
                    var textcode = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Console.WriteLine(textcode);
                    if (textcode == GlobalDefinitions.ExcelLib.ReadData(3, "Language"))
                    {
                        //Wait
                        GlobalDefinitions.wait(20);

                        //Click the Delete button
                        GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();


                        break;
                    }
                    
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Test Failed");
            }
        }


        [Then(@"the language that got clicked should not be displayed on my listings")]
        public void ThenTheLanguageThatGotClickedShouldNotBeDisplayedOnMyListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                //Start the Reports
                test = extent.StartTest("Validate Language Delete");

                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(3, "Language");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;

                GlobalDefinitions.wait(10);

                if (!(ExpectedValue == ActualValue))
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Deleted a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "LanguageDeleted");
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

        #endregion
    