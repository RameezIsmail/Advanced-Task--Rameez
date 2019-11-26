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
    public class EducationSteps
    {

        #region Add

        [Given(@"I clicked on the education tab under Profile page")]
        public void GivenIClickedOnTheEducationTabUnderProfilePage()
        {
            //Wait
            GlobalDefinitions.wait(20);

            //Click on Education Tab
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")).Click();
        
        }

        [When(@"I add new education details")]
        public void WhenIAddNewEducationDetails()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            GlobalDefinitions.wait(30);

            //Click on Add New button
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")).Click();

            GlobalDefinitions.wait(20);

            //Add College/University Name
            GlobalDefinitions.driver.FindElement(By.XPath("//*//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "University"));

            //Click on Country Of College/University
            IWebElement Country = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select"));
            Country.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Country"));
            Country.Click();

            //Click on Title
            IWebElement Title =  GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select"));
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            Title.Click();

            //Add Degree
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Degree"));

            //Click on year of graduation
            IWebElement YearOfGrad = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select"));
            YearOfGrad.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "GraduationYear"));
            YearOfGrad.Click();

            //Click on Add button
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]")).Click();

        }

        [Then(@"that education details should be displayed on my listings")]
        public void ThenThatEducationDetailsShouldBeDisplayedOnMyListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate Education Add");


                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "University");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Added an Education Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "EducationAdded");
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

        [Given(@"I click on the education tab under Profile Page")]
        public void GivenIClickOnTheEducationTabUnderProfilePage()
        {
            //Wait
            GlobalDefinitions.wait(20);

            //Click on Education Tab
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")).Click();

        }

        [When(@"I edit the education details")]
        public void WhenIEditTheEducationDetails()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                for (var i = 1; i <= 10; i++)
                {

                    var textcode = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[2]")).Text;
                    Console.WriteLine(textcode);
                    if (textcode == GlobalDefinitions.ExcelLib.ReadData(2, "University"));
                    {
                        //Wait
                        GlobalDefinitions.wait(20);

                        //Click the edit button 
                        GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[6]/span[1]/i")).Click();

                        //Clear the text and then write new text under College/Uni Name
                        IWebElement Uni = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[1]/div[1]/input"));
                        Uni.Clear();
                        Uni.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "University"));

                        //Select Country of College/uni
                        IWebElement Country = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[1]/div[2]/select"));
                        Country.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Country"));
                        Country.Click();

                        //Select Title
                        IWebElement Title = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[2]/div[1]/select"));
                        Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Title"));

                        //Clear the text and then write new text under Degree
                        IWebElement Degree = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[2]/div[2]/input"));
                        Degree.Clear();
                        Degree.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Degree"));

                        //Select Year of Graduation
                        IWebElement YearOfGrad = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[2]/div[3]/select"));
                        YearOfGrad.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "GraduationYear"));
                        YearOfGrad.Click();

                        //Click update
                        GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[3]/input[1]")).Click();

                        break;
                    }

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Test Failed");
            }
        }

        [Then(@"That education that been edited should be displayed on my listings")]
        public void ThenThatEducationThatBeenEditedShouldBeDisplayedOnMyListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate Education Edit");


                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(3, "University");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Edit Education Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "EducationEdited");
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

        [Given(@"I clicked on the education tab under Profile Page")]
        public void GivenIClickedOnEducationTabUnderProfilePage()
        {
            //Wait
            GlobalDefinitions.wait(20);

            //Click on Education Tab
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")).Click();

        }

        [When(@"I click that delete button")]
        public void WhenIClickThatDeleteButton()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                for (var i = 1; i <= 10; i++)
                {
                    var textcode = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[2]")).Text;
                    Console.WriteLine(textcode);
                    if (textcode == GlobalDefinitions.ExcelLib.ReadData(3, "University"));
                    {
                        //Wait
                        GlobalDefinitions.wait(20);

                        //Click the Delete button
                        GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[6]/span[2]/i")).Click();

                        break;
                    }

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Test Failed");
            }
        }

        [Then(@"the education that got clicked should not be displayed in my listings")]
        public void ThenTheEducationThatGotClickedShouldNotBeDisplayedInMyListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate Education Delete");


                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(3, "University");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]")).Text;

                GlobalDefinitions.wait(10);

                if (!(ExpectedValue == ActualValue))
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Delete Education Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "EducationDeleted");
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
