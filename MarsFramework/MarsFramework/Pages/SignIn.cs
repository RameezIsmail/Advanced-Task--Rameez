using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div/div[1]/div/a")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div[1]/div/div[1]/input")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div[1]/div/div[2]/input")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div[1]/div/div[4]/button")]
        private IWebElement LoginBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[1]/div[2]/div/span")]
        private IWebElement UsernameNavigation{ get; set;}

        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[1]/div[2]/div/span/div/a[2]")]
        private IWebElement ChangePasswordMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div[2]/form/div[1]/input")]
        private IWebElement CurrentPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div[2]/form/div[1]/input")]
        private IWebElement NewPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div[2]/form/div[3]/input")]
        private IWebElement ConfirmPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div[2]/form/div[4]/button")]
        private IWebElement Savebutton { get; set; }



        
        #endregion

        internal void LoginSteps()
        {
            //extent Reports
            Base.test = Base.extent.StartTest("Login Test");

            //Populate the Excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Global.Base.ExcelPath, "SignIn");

            //Navigate to the Url
            GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2,"Url"));

            //Click on Sign In tab
            SignIntab.Click();
            GlobalDefinitions.wait(10);

            //Enter the data in Username textbox
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Username"));

            GlobalDefinitions.wait(10);

            //Enter the password 
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Click on Login button
            LoginBtn.Click();

            GlobalDefinitions.wait(20);

            string text = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/a")).Text;

            if (text == "MarsLogo")
            {
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Login Successful");
            }
            else
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Login Unsuccessful");

        }

        internal void ChangePassword()
        {
            //Populate the Excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Global.Base.ExcelPath, "SignIn");

            GlobalDefinitions.wait(60);

            Actions builder = new Actions(Global.GlobalDefinitions.driver);
            builder.MoveToElement(UsernameNavigation).Build().Perform();

            UsernameNavigation.Click();

            GlobalDefinitions.wait(60);

            ChangePasswordMenu.Click();



            CurrentPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CurrentPassword"));

            NewPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "NewPassword"));

            ConfirmPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPassword"));

            GlobalDefinitions.wait(60);

            Savebutton.Click();
        }
    }
}