using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.IWebElement;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow.Assist;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature1Steps : Utils.Start
    {
        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);
       
            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
           
        }
        
        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys("English");

            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")).Click();

            //Choose the language level
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[1];
           
            Lang.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();

        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "English";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if(ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch(Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed",e.Message);
            }
           
        }

       
         
                       

        


        [Given(@"I clicked on the skills tab on the profile page")]
        public void GivenIClickedOnTheSkillsTabOnTheProfilePage()
        {
            //Wait
            Thread.Sleep(1500);
            //Click on Skills tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab = 'second']")).Click();
        }

        [When(@"I add a new (.*) and (.*)")]
        public void WhenIAddANewTestingAndExpert(String skill, String skillLevel)
        {
            //Click on Add New Button
            Driver.driver.FindElement(By.XPath("//div[@class = 'ui teal button']")).Click();
            
            // Add a skill
            Driver.driver.FindElement(By.XPath("//input[@placeholder = 'Add Skill']")).SendKeys(skill);

            //Choose Skill Level
            SelectElement skillLevelOption = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name = 'level']")));
            ICollection <IWebElement> skillSize = skillLevelOption.Options;
            for (int i = 0; i<skillSize.Count(); i++)
            {
                if(skillLevel == skillLevelOption.Options.ElementAt(i).Text)
                {
                    skillLevelOption.SelectByIndex(i);
                }
            }
            // Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value = 'Add']")).Click();
        }

        [Then(@"the (.*) should be displayed on my listings")]
        public void ThenTheTestingShouldBeDisplayedOnMyListings(String ExpectedSkill)
        {
            //ScenarioContext.Current.Pending();
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill");

                Thread.Sleep(1000);
                String ActualSkill = Driver.driver.FindElement(By.XPath("//table[@class ='ui fixed table']//td[text()='" + ExpectedSkill + "']")).Text;

                String ExpectedAddSkillMsg = $"{ExpectedSkill} has been added to your skills";
                String AcutalAddSkillMsg = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div")).Text;

                if (ExpectedSkill == ActualSkill)
                {
                    if (ExpectedAddSkillMsg == AcutalAddSkillMsg)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Skill Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillAdded");
                    }
                    else
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed, Success message displayed is wrong");
                }
                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

        
        [When(@"I delete a skill '(.*)'")]
        public void WhenIDeleteASkill(string SkillToBeDeleted)
        {
            //Click on delete
            Driver.driver.FindElement(By.XPath("//td[text() = '"+SkillToBeDeleted+"']//following-sibling::td[@class = 'right aligned']//i[@class='remove icon']")).Click();
        }

        [Then(@"the skill '(.*)' should be deleted from my listings")]
        public void ThenTheSkillShouldBeDeletedFromMyListings(string SkillToBeDeleted)
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Skill");

                Thread.Sleep(1000);
                String ExpectedDeleteSkillMsg = $"{SkillToBeDeleted} has been deleted";
                String ActualDeleteSkillMsg = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div")).Text;

                if (ExpectedDeleteSkillMsg == ActualDeleteSkillMsg)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted a Skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Skill Deleted");
                }
                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed, Message displayed is wrong");
            }

            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
        [When(@"I edit a skill (.*) with (.*)")]
        public void WhenIEditASkillWith(string skill, string newSkill)
        {
            //Clicks on Edit icon
            Driver.driver.FindElement(By.XPath("//td[text()='"+ skill +"']//following-sibling::td[@class='right aligned']//i[@class='outline write icon']")).Click();

            //Edit the Skill
            IWebElement addSkillTextbox =  Driver.driver.FindElement(By.XPath("//input[@placeholder = 'Add Skill']"));
            addSkillTextbox.Clear();
            addSkillTextbox.SendKeys(newSkill);

            //Click on Update button
            Driver.driver.FindElement(By.XPath("//input[@value = 'Update']")).Click();
        }

        [Then(@"the skill (.*) should be updated on my listings")]
        public void ThenTheSkillShouldBeUpdatedOnMyListings(string expectedSkill)
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Update a Skill");

                Thread.Sleep(1000);
                String ActualSkill = Driver.driver.FindElement(By.XPath("//table[@class ='ui fixed table']//td[text()='" + expectedSkill + "']")).Text;


                String ExpectedEditSkillMsg = $"{expectedSkill} has been updated to your skills";
                String AcutalEditSkillMsg = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div")).Text;

                if (expectedSkill == ActualSkill)
                {
                    if (ExpectedEditSkillMsg == AcutalEditSkillMsg)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Updated a Skill Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillUpdated");
                    }
                    else
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed,Success message displayed is wrong");
                }
                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
            }
            catch (Exception e)

            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

                      
       
    }

}
