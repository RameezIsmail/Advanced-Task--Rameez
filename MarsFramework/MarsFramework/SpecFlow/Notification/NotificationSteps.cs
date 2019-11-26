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

namespace MarsFramework.SpecFlow.Notification
{
    [Binding]
    public class NotificationSteps
    {
        [Given(@"I'm in profile page")]
        public void GivenIMInProfilePage()
        {

            GlobalDefinitions.wait(20);
            // Click on Language tab
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")).Click();
        }
        
        [When(@"I click on notification tab")]
        public void WhenIClickOnNotificationTab()
        {
            IWebElement Notifications = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[1]"));

            Notifications.Click();


        }
        
        [Then(@"i should be in notification page")]
        public void ThenIShouldBeInNotificationPage()
        {
            IWebElement NotificationsText = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/a/h1"));
            
            Assert.That(NotificationsText.Text, Is.EqualTo("Notifications"));
        }
    }
}
