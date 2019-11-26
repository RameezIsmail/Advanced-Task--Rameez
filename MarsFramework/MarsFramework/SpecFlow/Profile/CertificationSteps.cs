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
    public class CertificationSteps
    {
        #region Add

        [Given(@"I clicked on the Certifications tab under Profile Page")]
        public void GivenIClickedOnTheCertificationsTabUnderProfilePage()
        {
            //Wait
            GlobalDefinitions.wait(20);

            //Click on Certifications Tab
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")).Click();

        }

        [When(@"I add new certification details")]
        public void WhenIAddNewCertificationDetails()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            //Click on Add new Button 
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div")).Click();

            //Wait 
            GlobalDefinitions.wait(20);

            //Add Certificate or Award
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Certification"));

            //Add Certified From
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[1]/input")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Certified From"));

            //Click on Year
            IWebElement ChooseYear = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select"));
            ChooseYear.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CertYear"));
            ChooseYear.Click();

            //Click on Add Button
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]")).Click();

        }

        [Then(@"that certification details should be displayed on my listings")]
        public void ThenThatCertificationDetailsShouldBeDisplayedOnMyListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate Certification Add");


                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "Certification");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Added a Certification Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "CertificationAdded");
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

        [Given(@"I clicked on the certification tab under Profile Page")]
        public void GivenIClickedOnTheCertificationTabUnderProfilePage()
        {
            //Wait
            GlobalDefinitions.wait(20);

            //Click on Certifications Tab
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")).Click();

        }

        [When(@"I edit the certification details")]
        public void WhenIEditTheCertificationDetails()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                for (var i = 1; i <= 10; i++)
                {

                    var textcode = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Console.WriteLine(textcode);
                    if (textcode == GlobalDefinitions.ExcelLib.ReadData(2, "Certification"))
                    {
                        //Wait
                        GlobalDefinitions.wait(20);

                        //Click the edit button 
                        GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[4]/span[1]/i")).Click();

                        //Clear the text and then write new text under Certifcation/Award
                        IWebElement CertAward = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td/div/div/div[1]/input"));
                        CertAward.Clear();
                        CertAward.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Certification"));

                        //Clear the text and then write new text under Certified From
                        IWebElement CertFrom = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td/div/div/div[2]/input"));
                        CertFrom.Clear();
                        CertFrom.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Certified From"));

                        //Click on the dropdown menu
                        IWebElement ChooseYear = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td/div/div/div[3]/select"));
                        ChooseYear.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "CertYear"));
                        ChooseYear.Click();

                        //Click update
                        GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td/div/span/input[1]")).Click();

                        break;
                    }

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Test Failed");
            }
        }

        [Then(@"That certification that been edited should be displayed on my listings")]
        public void ThenThatCertificationThatBeenEditedShouldBeDisplayedOnMyListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate Certification Edit");


                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(3, "Certification");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Eddited a Certification Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "CertificationEditted");
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

        [Given(@"I clicked on the certifications tab under Profile Page")]
        public void GivenIClickedOnCertificationsTabUnderProfilePage()
        {
            //Wait
            GlobalDefinitions.wait(20);

            //Click on Certifications Tab
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")).Click();

        }

        [When(@"I click the delete button")]
        public void WhenIClickTheDeleteButton()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                for (var i = 1; i <= 10; i++)
                {

                    var textcode = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Console.WriteLine(textcode);
                    if (textcode == GlobalDefinitions.ExcelLib.ReadData(3, "Certification")) 
                    {
                        //Wait
                        GlobalDefinitions.wait(20);

                        //Click the Delete button
                        GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[4]/span[2]/i")).Click();

                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Test Failed");
            }
        }

        [Then(@"the certification that got clicked should not be displayed on my listings")]
        public void ThenTheCertificationThatGotClickedShouldNotBeDisplayedOnMyListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate Certification Edit");


                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(3, "Certification");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]")).Text;

                GlobalDefinitions.wait(10);

                if (!(ExpectedValue == ActualValue))
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Deleted a Certification Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "CertificationDeleted");
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
