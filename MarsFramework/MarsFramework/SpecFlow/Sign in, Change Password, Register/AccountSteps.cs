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

namespace MarsFramework.SpecFlow.Sign_in__Change_Password__Register
{
    [Binding]
    public class AccountSteps
    {
        #region login

        [Given(@"I am in home page and want to sign in")]
        public void GivenIAmInHomePageAndWantToSignIn()
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

        [When(@"I enter login detail")]
        public void WhenIEnterLoginDetail()
        {

            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a")).Click();

            GlobalDefinitions.wait(30);

            //Enter the data in Username textbox
            IWebElement Email = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));

            GlobalDefinitions.wait(10);

            //Enter the password 
            IWebElement Password = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));

            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Click on Login button
            GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button")).Click();

            GlobalDefinitions.wait(20);

        }

        [Then(@"I should be in profile page")]
        public void ThenIShouldBeInProfilePage()
        {
            string text = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/a")).Text;

            if (text == "MarsLogo")
            {
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Login Successful");
            }
            else
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Login Unsuccessful");
        }

        #endregion


        #region Register

        [Given(@"I am in home page and want to register")]
        public void GivenIAmInHomePageAndWantToRegister()
        {
            Actions builder = new Actions(Global.GlobalDefinitions.driver);
            IWebElement Signout = GlobalDefinitions.driver.FindElement(By.XPath("//*//button[contains(.,'Sign Out')]"));
            builder.MoveToElement(Signout).Build().Perform();

            WebDriverWait wait = new WebDriverWait(GlobalDefinitions.driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(Signout));

            Signout.Click();

            GlobalDefinitions.wait(120);


        }

        [When(@"I enter the register detail")]
        public void WhenIEnterTheRegisterDetail()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "SignUp");

            GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[1]/div/button")).Click();

            GlobalDefinitions.wait(120);

            //Enter FirstName
            GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='First name']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName"));

            //Enter LastName
            GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='Last name']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));

            //Enter Email
            GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='Email address']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Email"));

            //Enter Password
            GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Enter Password again to confirm
            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@placeholder,'Confirm Password')]")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPswd"));

            //Click on Checkbox
            GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@type,'checkbox')]")).Click();

            //Click on join button to Sign Up
            GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(@id,'submit-btn')]")).Click();
        }

        [Then(@"it should tell you to verify account \(Unless the email is already taken\)")]
        public void ThenItShouldTellYouToVerifyAccountUnlessTheEmailIsAlreadyTaken()
        {
            string text = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div")).Text;

            if (text == "This email has already been used to register an account.")
            {
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Login Successful");

            }
            else
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Login Unsuccessful");
        }

        #endregion

        #region Change Password

        [Given(@"I am in profile page and click change password")]
        public void GivenIAmInProfilePageAndClickChangePassword()
        {
            GlobalDefinitions.wait(50);

            IWebElement UsernameNavigation = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"));
            Actions builder = new Actions(Global.GlobalDefinitions.driver);
            //builder.MoveToElement(UsernameNavigation).Build().Perform();

            WebDriverWait wait = new WebDriverWait(GlobalDefinitions.driver, TimeSpan.FromSeconds(60));
            //wait.Until(ExpectedConditions.ElementToBeClickable(UsernameNavigation));

            AutoItX.MouseMove(1700, 150);


            GlobalDefinitions.wait(500);

            UsernameNavigation.Click();

            GlobalDefinitions.wait(20);

            IWebElement ChangePassword = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/div/a[2]"));

            builder.MoveToElement(ChangePassword).Build().Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(ChangePassword));
            ChangePassword.Click();

        }

        [When(@"I enter the details and new password")]
        public void WhenIEnterTheDetailsAndNewPassword()
        {

            GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='Current Password']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CurrentPassword"));

            GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='New Password']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "NewPassword"));

            GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='Confirm Password']")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPassword"));

            GlobalDefinitions.driver.FindElement(By.XPath("//button[@type='button']")).Click();

            GlobalDefinitions.wait(500);


        }

        [Then(@"the new details should get saved")]
        public void ThenTheNewDetailsShouldGetSaved()
        {
            IWebElement Warning = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

            Assert.That(Warning.Text, Is.EqualTo("Current Password and New Password should not be same"));


        }

        #endregion
    }
}
