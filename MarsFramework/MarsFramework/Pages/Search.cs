using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class Search
    {
        public Search()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[1]/input")]
        private IWebElement SearchBar { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[contains(@class,'search link icon')]")]
        private IWebElement MagnifyingGlass { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@role='listitem'][contains(.,'Video & Animation15')]")]
        private IWebElement VideoAnimation { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@role='listitem'][contains(.,'Promotional Videos2')]")]
        private IWebElement PromotionalVideos { get; set; }
        
        internal void SearchAnimation()
        {
            Global.GlobalDefinitions.wait(20);

            SearchBar.SendKeys("Animation");

            Global.GlobalDefinitions.wait(60);

            MagnifyingGlass.Click();

            Global.GlobalDefinitions.wait(60);


            for (var i = 1; i <= 10; i++)
            {
                var Textcode = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[" + i + "]/div[1]/a[2]/p")).Text;
                Console.WriteLine(Textcode);
                if (Textcode == "Animation")
                {
                    GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[" + i + "]/div[1]/a[2]/p")).Click();

                    Console.WriteLine("Test Passed");
                    Base.test.Log(LogStatus.Info, "Successfully Searched Animation");
                    return;
                }
            }
        }

        public void SearchByCategories()
        {
            Global.GlobalDefinitions.wait(20);

            MagnifyingGlass.Click();

            Global.GlobalDefinitions.wait(60);

            VideoAnimation.Click();

            Global.GlobalDefinitions.wait(60);

            PromotionalVideos.Click();

            Global.GlobalDefinitions.wait(60);
            
            for (var i = 1; i <= 10; i++)                    
            {              
                var Textcode = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[" + i + "]/div[1]/a[2]/p")).Text;                   
                Console.WriteLine(Textcode);                    
                if (Textcode == "Animation")           
                {
                    Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[" + i + "]/div[1]/a[2]/p")).Click();
                    Console.WriteLine("Test Passed");
                    Base.test.Log(LogStatus.Info, "Successfully Searched By Categories");
                    return;
                }  
            }   



        }
    }
}
