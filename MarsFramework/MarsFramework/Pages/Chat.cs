using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class Chat
    {
        public Chat()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[1]")]
        private IWebElement ChatHis { get; set; }

        [FindsBy(How=How.XPath, Using = "//*[@id='message-section']/div[2]/h2/div/text()")]
        private IWebElement chat { get; set; }

        internal void ChatHistory()
        {
            GlobalDefinitions.wait(60);

            Actions builder = new Actions(Global.GlobalDefinitions.driver);
            builder.MoveToElement(ChatHis).Build().Perform();

            WebDriverWait wait = new WebDriverWait(GlobalDefinitions.driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(ChatHis));

            Assert.That(chat.Text, Is.EqualTo("You don't have any open chats"));

            Base.test.Log(LogStatus.Info, "Sucessfully in Chat History Page");
        }

    }
}
