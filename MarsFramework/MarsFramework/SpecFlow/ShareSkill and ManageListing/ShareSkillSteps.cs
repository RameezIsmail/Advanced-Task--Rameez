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

namespace MarsFramework.SpecFlow.ShareSkill_and_ManageListing
{
    [Binding]
    public class ShareSkillSteps
    {
        #region Add
        [Given(@"I clicked on the ShareSkill button under Profile Page")]
        public void GivenIClickedOnTheShareSkillButtonUnderProfilePage()
        {
            GlobalDefinitions.wait(20);

            GlobalDefinitions.driver.FindElement(By.XPath("//a[@href='/Home/ServiceListing']")).Click();

        }


        [When(@"I add new skillshare details")]
        public void WhenIAddNewSkillshareDetails()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "ShareSkill");

            GlobalDefinitions.wait(20);

            //Title
            GlobalDefinitions.driver.FindElement(By.Name("title")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Description
            GlobalDefinitions.driver.FindElement(By.Name("description")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            GlobalDefinitions.wait(20);

            //Category
            IWebElement Category = GlobalDefinitions.driver.FindElement(By.Name("categoryId"));
            Category.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            Category.Click();

            //SubCategory
            IWebElement SubCategory = GlobalDefinitions.driver.FindElement(By.Name("subcategoryId"));
            SubCategory.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));
            SubCategory.Click();

            //Tags
            IWebElement Tags = GlobalDefinitions.driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]"));
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //Click on Hourly basis service or One-off service
            if (GlobalDefinitions.ExcelLib.ReadData(2, "Service Type") == "Hourly basis service")
            {
                //Hourly
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")).Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "Service Type") == "One-off service")
            {
                //One Off 
                GlobalDefinitions.driver.FindElement(By.XPath(" //*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")).Click();
            }

            GlobalDefinitions.wait(20);

            //Click on On-site or Online
            if (GlobalDefinitions.ExcelLib.ReadData(2, "Location Type") == "On-site")
            {
                //OnSite
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")).Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "Location Type") == "Online")
            {
                //Online
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")).Click();
            }

            GlobalDefinitions.wait(60);
            
            
            //Click on "Today"
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div/div[1]/ul[1]/li[1]/a")).Click();

            GlobalDefinitions.wait(20);

            //Click on "Day"
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div/div[1]/ul[2]/li[2]/a")).Click();

            GlobalDefinitions.wait(20);

            //Click on Calendar
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div/div[1]/ul[1]/li[4]/a/span[3]")).Click();

            //Click on right > arrow
            GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/a[3]")).Click();

            //Click on calendar date: 29th December 2019
            GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[2]/div/div/table/tbody/tr[5]/td[1]/a")).Click();
            
            //Click on 9:00AM
            IWebElement Time = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div/table/tbody/tr[2]/td[2]/div/table/tbody/tr[5]/td"));
            Actions action = new Actions(driver);
            action.MoveToElement(Time).DoubleClick().Perform();

            GlobalDefinitions.wait(60);

            //Calendar Title
            IWebElement CalendarTitle = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div[2]/input"));
            CalendarTitle.Clear();
            CalendarTitle.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CalendarTitle"));

            GlobalDefinitions.wait(60);

            //Convert excel dateformat to C# - Enter data in Startdate
            string dateformat = "MM/dd/yyyy h:mm tt";
            string sdate = GlobalDefinitions.ExcelLib.ReadData(2, "Startdate");
            string newStartDate = DateTime.Parse(sdate).ToString(dateformat);
            IWebElement StartTime = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div[4]/span[1]/span/input"));
            StartTime.Clear();
            StartTime.SendKeys(newStartDate);

            GlobalDefinitions.wait(120);

            StartTime.SendKeys(Keys.Enter);

            GlobalDefinitions.wait(60);

            //Convert excel timeformat to C# - enter data in Enddate
            string edate = GlobalDefinitions.ExcelLib.ReadData(2, "Enddate");
            string newEndDate = DateTime.Parse(edate).ToString(dateformat);
            IWebElement EndTime = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div[6]/span[1]/span/input"));
            EndTime.Clear();
            EndTime.SendKeys(newEndDate);

            GlobalDefinitions.wait(120);

            EndTime.SendKeys(Keys.Enter);

            //Calendar Description
            GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div[13]/textarea")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CalendarDescription"));

            GlobalDefinitions.wait(60);

            
           //Save button
            IWebElement SaveButton = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div[16]/a[1]"));

            Actions builder = new Actions(Global.GlobalDefinitions.driver);
            builder.MoveToElement(SaveButton).Build().Perform();

            WebDriverWait wait = new WebDriverWait(GlobalDefinitions.driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(SaveButton));

            SaveButton.Click();

            SaveButton.SendKeys(Keys.Escape);

            GlobalDefinitions.wait(100);

            IWebElement Calendar = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div/table/tbody/tr[1]/td[2]/div/div/div/div/div/div"));

            if (Calendar.Text == GlobalDefinitions.ExcelLib.ReadData(2, "CalendarTitle"))
            {

                var element = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
                Actions actions = new Actions(driver);
                actions.MoveToElement(element);
                actions.Perform();



                //Click on Skill-exchange or Credit
                if (GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade") == "Skill-exchange")
                {
                    GlobalDefinitions.driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(8) > div:nth-child(2) > div > div:nth-child(1) > div > input[type=radio]")).Click();

                    IWebElement SkillExchange = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
                    SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
                    SkillExchange.SendKeys(Keys.Enter);

                }

                else if (GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade") == "Credit")
                {
                    GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")).Click();
                    IWebElement CreditAmount = GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@name,'charge')]"));
                    CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
                }

                //Click on Active or Hidden
                if (GlobalDefinitions.ExcelLib.ReadData(2, "Active") == "Active")
                {
                    GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")).Click();
                }

                else if (GlobalDefinitions.ExcelLib.ReadData(2, "Active") == "Hidden")
                {
                    GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input")).Click();
                }

                //Upload a file
                IWebElement Upload = GlobalDefinitions.driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));
                Upload.Click();
                string path = GlobalDefinitions.ExcelLib.ReadData(2, "WorkSample");
                GlobalDefinitions.wait(60);
                AutoItX.WinWaitActive("Open");
                AutoItX.Send(path);
                AutoItX.Send("{ENTER}");


                GlobalDefinitions.driver.FindElement(By.XPath("//input[@value='Save']")).Click();
            }
        }



        [Then(@"that shareskill details should be displayed on my listing under ManageListing page")]
        public void ThenThatShareskillDetailsShouldBeDisplayedOnMyListingUnderManageListingPage()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "ShareSkill");

            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate ShareSkill Added");

                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "Category");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[2]")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Added a ShareSkill Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "ShareSkillAdded");
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

        [Given(@"I clicked on the ManageListing tab under Profile Page")]
        public void GivenIClickedOnTheManageListingTabUnderProfilePage()
        {
            GlobalDefinitions.wait(20);

            GlobalDefinitions.driver.FindElement(By.XPath("//a[@href='/Home/ListingManagement']")).Click();
        }


        [When(@"I click on Edit button on ShareSkill under ManageListing Page and edit skillshare details")]
        public void WhenIClickOnEditButtonOnShareSkillUnderManageListingPageAndEditSkillshareDetails()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "ShareSkill");

            GlobalDefinitions.wait(20);

            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]")).Click();

            GlobalDefinitions.wait(20);

            //Title
            IWebElement Title = GlobalDefinitions.driver.FindElement(By.Name("title"));
            Title.Clear();
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Title"));

            //Description 
            IWebElement Description = GlobalDefinitions.driver.FindElement(By.Name("description"));
            Description.Clear();
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Description"));

            GlobalDefinitions.wait(20);

            //Category
            IWebElement Category = GlobalDefinitions.driver.FindElement(By.Name("categoryId"));
            Category.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Category"));
            Category.Click();

            //SubCategory
            IWebElement SubCategory = GlobalDefinitions.driver.FindElement(By.Name("subcategoryId"));
            SubCategory.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "SubCategory"));
            SubCategory.Click();

            //Tags
            IWebElement Tags = GlobalDefinitions.driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]"));

            //Remove tag
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/span/a")).Click();

            GlobalDefinitions.wait(20);

            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //Click on Hourly basis service or One-off service
            if (GlobalDefinitions.ExcelLib.ReadData(3, "Service Type") == "Hourly basis service")
            {
                //Hourly
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")).Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(3, "Service Type") == "One-off service")
            {
                //One Off 
                GlobalDefinitions.driver.FindElement(By.XPath(" //*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")).Click();
            }

            GlobalDefinitions.wait(20);

            //Click on On-site or Online
            if (GlobalDefinitions.ExcelLib.ReadData(3, "Location Type") == "On-site")
            {
                //OnSite
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")).Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(3, "Location Type") == "Online")
            {
                //Online
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")).Click();
            }

            GlobalDefinitions.wait(60);

            //Click on "Today"
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div/div[1]/ul[1]/li[1]/a")).Click();

            GlobalDefinitions.wait(20);

            //Click on "Day"
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div/div[1]/ul[2]/li[2]/a")).Click();

            GlobalDefinitions.wait(20);

            //Click on Calendar
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div/div[1]/ul[1]/li[4]/a/span[3]")).Click();

            GlobalDefinitions.wait(20);

            //Click on right > arrow
            GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/a[3]")).Click();

            //Click on calendar date: 30th December 2019
            GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[2]/div/div/table/tbody/tr[5]/td[2]/a")).Click();

            //Click on 11:00AM
            IWebElement Time = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div/table/tbody/tr[2]/td[2]/div/table/tbody/tr[9]/td"));
            Actions action = new Actions(driver);
            action.MoveToElement(Time).DoubleClick().Perform();

            GlobalDefinitions.wait(60);

            //Calendar Title
            IWebElement CalendarTitle = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div[2]/input"));
            CalendarTitle.Clear();
            CalendarTitle.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "CalendarTitle"));

            GlobalDefinitions.wait(60);

            //Convert excel dateformat to C# - Enter data in Startdate
            string dateformat = "MM/dd/yyyy h:mm tt";
            string sdate = GlobalDefinitions.ExcelLib.ReadData(3, "Startdate");
            string newStartDate = DateTime.Parse(sdate).ToString(dateformat);
            IWebElement StartTime = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div[4]/span[1]/span/input"));
            StartTime.Clear();
            StartTime.SendKeys(newStartDate);

            GlobalDefinitions.wait(120);

            StartTime.SendKeys(Keys.Enter);

            GlobalDefinitions.wait(60);

            //Convert excel timeformat to C# - enter data in Enddate
            string edate = GlobalDefinitions.ExcelLib.ReadData(3, "Enddate");
            string newEndDate = DateTime.Parse(edate).ToString(dateformat);
            IWebElement EndTime = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div[6]/span[1]/span/input"));
            EndTime.Clear();
            EndTime.SendKeys(newEndDate);

            GlobalDefinitions.wait(120);

            EndTime.SendKeys(Keys.Enter);

            //Calendar Description
            GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div[13]/textarea")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CalendarDescription"));

            GlobalDefinitions.wait(60);

            //Save button
            IWebElement SaveButton = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div[16]/a[1]"));

            Actions builder = new Actions(Global.GlobalDefinitions.driver);
            builder.MoveToElement(SaveButton).Build().Perform();

            WebDriverWait wait = new WebDriverWait(GlobalDefinitions.driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(SaveButton));
            SaveButton.Click();

            //Press escape button
            SaveButton.SendKeys(Keys.Escape);

            GlobalDefinitions.wait(100);

            IWebElement Calendar = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div/table/tbody/tr[1]/td[2]/div/div/div/div/div/div"));

            if (Calendar.Text == GlobalDefinitions.ExcelLib.ReadData(3, "CalendarTitle"))
            {

                var element = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));
                Actions actions = new Actions(driver);
                actions.MoveToElement(element);
                actions.Perform();

                //Click on Skill-exchange or Credit

                if (GlobalDefinitions.ExcelLib.ReadData(3, "SkillTrade") == "Skill-exchange")
                {

                    GlobalDefinitions.wait(60);

                    GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")).Click();

                    IWebElement SkillExchange = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
                    SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
                    SkillExchange.SendKeys(Keys.Enter);

                }

                else if (GlobalDefinitions.ExcelLib.ReadData(3, "SkillTrade") == "Credit")

                {
                    GlobalDefinitions.wait(60);

                    IWebElement Credit = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));
                    Credit.Click();

                    IWebElement CreditAmount = GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@name,'charge')]"));

                    CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Credit"));

                }


                //Click on Active or Hidden

                if (GlobalDefinitions.ExcelLib.ReadData(3, "Active") == "Active")
                {
                    GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")).Click();
                }

                else if (GlobalDefinitions.ExcelLib.ReadData(3, "Active") == "Hidden")
                {
                    GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input")).Click();
                }

                //Upload a file
                IWebElement Upload = GlobalDefinitions.driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));

                Upload.Click();
                string path = GlobalDefinitions.ExcelLib.ReadData(3, "WorkSample");
                GlobalDefinitions.wait(60);
                AutoItX.WinWaitActive("Open");
                AutoItX.Send(path);
                AutoItX.Send("{ENTER}");
                


                AutoItX.Send(path);


                //Click Save button
                GlobalDefinitions.driver.FindElement(By.XPath("//input[@value='Save']")).Click();
            }
        }
        

        [Then(@"that shareskill details should be displayed on my listings under ManageListing page")]
        public void ThenThatShareskillDetailsShouldBeDisplayedOnMyListingsUnderManageListingPage()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "ShareSkill");

            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate ShareSkill Edited");

                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(3, "Category");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[2]")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Edited ShareSkill Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "ShareSkillEdited");
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

        [Given(@"I clicked on the ManageListings tab under Profile Page")]
        public void GivenIClickedOnTheManageListingsTabUnderProfilePage()
        {
            GlobalDefinitions.wait(20);

            GlobalDefinitions.driver.FindElement(By.XPath("//a[@href='/Home/ListingManagement']")).Click();
        }

        [When(@"I delete skillshare details")]
        public void WhenIDeleteSkillshareDetails()
        {
            GlobalDefinitions.wait(20);

            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]")).Click();

            GlobalDefinitions.wait(20);

            GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]")).Click();
        }

        [Then(@"that shareskill details should not be displayed on my listings under ManageListing page")]
        public void ThenThatShareskillDetailsShouldNotBeDisplayedOnMyListingsUnderManageListingPage()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "ShareSkill");

            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate ShareSkill Deleted");

                GlobalDefinitions.wait(10);

                string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(3, "Category");
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[2]")).Text;

                GlobalDefinitions.wait(10);

                if (!(ExpectedValue == ActualValue))
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Deleted a ShareSkill Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "ShareSkillDeleted");
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
