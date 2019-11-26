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

namespace MarsFramework.SpecFlow.Search
{
    [Binding]
    public class SearchSteps
    {
        #region Search Category
        [Given(@"I have clicked on Magnifying glass and in a search page")]
        public void GivenIHaveClickedOnMagnifyingGlassAndInASearchPage()
        {
            Global.GlobalDefinitions.wait(20);

            //Click on Magnifying glass
            GlobalDefinitions.driver.FindElement(By.XPath("//i[contains(@class,'search link icon')]")).Click();
        }

        [When(@"I click on category and subcaterogy")]
        public void WhenIClickOnCategoryAndSubcaterogy()
        {
            Global.GlobalDefinitions.wait(60);

            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[5]")).Click();


            Global.GlobalDefinitions.wait(60);

            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[6]")).Click();

            Global.GlobalDefinitions.wait(60);

            for (var i = 1; i <= 10; i++)
            {
                var Textcode = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[" + i + "]/div[1]/a[2]/p")).Text;
                Console.WriteLine(Textcode);
                if (Textcode == "Animation")
                {
                    GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[" + i + "]/div[1]/a[2]/p")).Click();
                    break;
                }
            }
        }

        [Then(@"it should show the service")]
        public void ThenItShouldShowTheService()
        {
            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate Search By Using Searching bar");

                GlobalDefinitions.wait(10);

                string ExpectedValue = "Animation";
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Searched by searching bar Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Searched by Searching bar");
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

        #region Search filter
        [Given(@"I have clicked on Magnifying glass and I'm in search page")]
        public void GivenIHaveClickedOnMagnifyingGlassAndIMInSearchPage()
        {
            Global.GlobalDefinitions.wait(20);

            //Click on Magnifying glass
            GlobalDefinitions.driver.FindElement(By.XPath("//i[contains(@class,'search link icon')]")).Click();
        }

        [When(@"I click on filter \(Online, OnSite, Show all\)")]
        public void WhenIClickOnFilterOnlineOnSiteShowAll()
        {

            GlobalDefinitions.wait(60);

            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[1]")).Click();

            GlobalDefinitions.wait(20);

                
            for (var i = 1; i <= 10; i++)
           
            {
            
                var Textcode = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[" + i + "]/div[1]/a[2]/p")).Text;
                
                Console.WriteLine(Textcode);
                
                if (Textcode == "website designer")
                
                {
                
                    GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[" + i + "]/div[1]/a[2]/p")).Click();
                    
                    break;
                    
                }
                
            }
                   
                   
        }

        

        [Then(@"it should show the services")]
        public void ThenItShouldShowTheServices()
        {
            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate Search By Using Filter");

                GlobalDefinitions.wait(10);

                string ExpectedValue = "website designer";
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Searched by Filter Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Searched by ilterr");
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

        #region SearchBar

        [Given(@"I have clicked on Magnifying glass and in search page")]
        public void GivenIHaveClickedOnMagnifyingGlassAndInSearchPage()
        {
            Global.GlobalDefinitions.wait(20);

            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[1]/input")).SendKeys("Animation");

            //Click on Magnifying glass
            GlobalDefinitions.driver.FindElement(By.XPath("//i[contains(@class,'search link icon')]")).Click();
        }
                
        [When(@"I search the service in search bar and click on the service")]
        public void WhenISearchTheServiceInSearchBarAndClickOnTheService()
        {

            Global.GlobalDefinitions.wait(20);

            for (var i = 1; i <= 10; i++)
            {
                var Textcode = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[" + i + "]/div[1]/a[2]/p")).Text;
                Console.WriteLine(Textcode);
                if (Textcode == "Animation")
                {
                    GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[" + i + "]/div[1]/a[2]/p")).Click();
                    break;
                }
            }
        }
          
        [Then(@"it should show the service detail")]
        public void ThenItShouldShowTheServiceDetail()
        {
            try
            {
                //Start the Reports
                Base.test = Base.extent.StartTest("Validate Search By Using Searching bar");

                GlobalDefinitions.wait(10);

                string ExpectedValue = "Animation";
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span")).Text;

                GlobalDefinitions.wait(10);

                if (ExpectedValue == ActualValue)
                {
                    Base.test.Log(LogStatus.Pass, "Test Passed, Searched by searching bar Successfully");
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Searched by Searching bar");
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
