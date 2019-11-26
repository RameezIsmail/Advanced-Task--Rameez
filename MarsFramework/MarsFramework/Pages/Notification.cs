using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace MarsFramework.Pages
{
    class Notification
    {
        public Notification()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/a[1]")]
        private IWebElement NotificationTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/a/h1")]
        private IWebElement NotificationsText { get; set; }


        public void Notifications()
        {

            NotificationTab.Click();

            Assert.That(NotificationsText.Text, Is.EqualTo("Notifications"));
        }
    }
}
