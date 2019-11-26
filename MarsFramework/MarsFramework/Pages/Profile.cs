using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MarsFramework
{
    internal class Profile
    {

        public Profile()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 

        //Click on Availability Edit button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i")]
        private IWebElement AvailabilityEdit { get; set; }

        //Click on Availability Dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select")]
        private IWebElement AvailabilityDropDown { get; set; }

        //Click on Availability Hour dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i")]
        private IWebElement HoursEdit { get; set; }

        //Click on salary
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select")]
        private IWebElement HoursDropDown { get; set; }

        //Click on Location
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i")]
        private IWebElement EarnTargetEdit { get; set; }

        //Choose Location
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select")]
        private IWebElement EarnTargetDropDown { get; set; }


        #region Languages

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")]
        private IWebElement LanguageTab { get; set; }

        //Click on Add new to add new Language
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")]
        private IWebElement AddNewLangBtn { get; set; }

        //Enter the Language on text box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")]
        private IWebElement AddLangText { get; set; }

        //Enter the Language on text box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")]
        private IWebElement ChooseLang { get; set; }

        //Add Language 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")]
        private IWebElement AddLang { get; set; }

        #endregion

        #region Skills

        //Skill tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")]
        private IWebElement SkillTab { get; set; }

        //Click on Add new to add new skill
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")]
        private IWebElement AddNewSkillBtn { get; set; }

        //Enter the Skill on text box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input")]
        private IWebElement AddSkillText { get; set; }

        //Click on skill level dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select")]
        private IWebElement ChooseSkill { get; set; }

        //Add Skill
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]")]
        private IWebElement AddSkill { get; set; }

        #endregion

        #region Education

        //Education Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")]
        private IWebElement Educationtab { get; set; }

        //Click on Add new to Educaiton
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")]
        private IWebElement AddNewEducation { get; set; }

        //Enter university in the text box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input")]
        private IWebElement EnterUniversity { get; set; }

        //Choose the country
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select")]
        private IWebElement ChooseCountry { get; set; }

        //Click on Title dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select")]
        private IWebElement ChooseTitle { get; set; }

        //Degree
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input")]
        private IWebElement Degree { get; set; }

        //Year of graduation
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select")]
        private IWebElement DegreeYear { get; set; }

        //Click on Add
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]")]
        private IWebElement AddEdu { get; set; }

        #endregion

        #region Certification

        //Certification Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")]
        private IWebElement CertificationTab { get; set; }

        //Add new Certificate
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div")]
        private IWebElement AddNewCerti { get; set; }

        //Enter Certification Name
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input")]
        private IWebElement EnterCerti { get; set; }

        //Certified from
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[1]/input")]
        private IWebElement CertiFrom { get; set; }

        //Year
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select")]
        private IWebElement CertiYear { get; set; }

        //Add Ceritification
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]")]
        private IWebElement AddCerti { get; set; }

        #endregion

        #region Description

        //Add Desctiption
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i")]
        private IWebElement DescriptionEdit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea")]
        private IWebElement DescriptionWrite { get; set; }

        //Click on Save Button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button")]
        private IWebElement Save { get; set; }

        #endregion

        #endregion

        internal void EditProfile()
        {

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollections(Base.ExcelPath, "Profile");

            GlobalDefinitions.wait(60);

            //builder.MoveToElement(HoursEdit).Build().Perform();
            AvailabilityEdit.Click();
            HoursEdit.Click();
            EarnTargetEdit.Click();

            AvailabilityDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "AvailableTime"));
            HoursDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Hours"));
            EarnTargetDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EarnTarget"));


            //---------------------------------------------------------
            #region Languages
            //Click on Add New Language button
            AddNewLangBtn.Click();

            GlobalDefinitions.wait(20);

            //Enter the Language
            AddLangText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Language"));

            //Choose Language Level
            ChooseLang.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LanguageLevel"));
            ChooseLang.Click();
            
            AddLang.Click();

            GlobalDefinitions.wait(10);

            Base.test.Log(LogStatus.Info, "Added Language successfully");

            #endregion
            //-----------------------------------------------------------
            #region Skills

            //Click on Skill Tab
            SkillTab.Click();

            //Click on Add New Skill Button
            AddNewSkillBtn.Click();

            GlobalDefinitions.wait(20);

            //Enter the skill 
            AddSkillText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Skill"));

            //Click the skill dropdown
            ChooseSkill.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillLevel"));
            ChooseSkill.Click();
            
            //Click Add button
            AddSkill.Click();

            GlobalDefinitions.wait(10);

            Base.test.Log(LogStatus.Info, "Added Skills successfully");

            #endregion
            //---------------------------------------------------------
            #region Education

            //EducationTab
            Educationtab.Click();

            //Add Education
            AddNewEducation.Click();

            GlobalDefinitions.wait(20);

            //Enter the University
            EnterUniversity.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"University"));

            //Choose Country
            ChooseCountry.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Country"));
            ChooseCountry.Click();

            GlobalDefinitions.wait(10);

            //Choose Title
            ChooseTitle.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            ChooseTitle.Click();

            GlobalDefinitions.wait(10);

            //Enter Degree
            Degree.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Degree"));

            //Year of Graduation
            DegreeYear.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "GraduationYear"));
            DegreeYear.Click();

            GlobalDefinitions.wait(10);

            //Click Add Button
            AddEdu.Click();

            GlobalDefinitions.wait(10);

            Base.test.Log(LogStatus.Info, "Added Education successfully");

            #endregion
            //-------------------------------------------------
            #region Certification

            //CertificationTab
            CertificationTab.Click();

            //Add new Certificate
            AddNewCerti.Click();

            //Enter Certificate Name
            EnterCerti.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Certification"));

            //Enter Certified from
            CertiFrom.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Certified From"));

            //Enter the Year
            CertiYear.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CertYear"));
            CertiYear.Click();

            GlobalDefinitions.wait(10);

            AddCerti.Click();

            GlobalDefinitions.wait(10);

            Base.test.Log(LogStatus.Info, "Added Certificate successfully");

            #endregion
            //-----------------------------------------------------
            #region Description

            //Add Description
            DescriptionEdit.Click();

            GlobalDefinitions.wait(100);

            DescriptionWrite.Click();

            GlobalDefinitions.wait(120);

            DescriptionWrite.Clear();

            GlobalDefinitions.wait(60);

            DescriptionWrite.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Description"));

            GlobalDefinitions.wait(30);

            Save.Click();

            Base.test.Log(LogStatus.Info, "Added Description successfully");
            
            #endregion

        }
    }
}