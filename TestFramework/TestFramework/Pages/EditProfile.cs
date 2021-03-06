﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
#pragma warning disable 649
namespace TestFramework.Pages
{
    public class EditProfile : AbstractPage
    {
        private const string BASE_URL = "http://www.kongregate.com/";
        [FindsBy(How = How.Id, Using = "user_uploaded_data")]
        private IWebElement upload_button;
        [FindsBy(How = How.XPath, Using = "//input[@value='Save Changes']")]
        private IWebElement submit_button;
        [FindsBy(How = How.XPath, Using = "//a[text()='Password']")]
        private IWebElement password_btn;
        private string change_pwd_btn_locator = "//input[@value='Change Password']";
        public EditProfile(IWebDriver driver) : base(driver) { }
        public Profile UploadPhoto()
        {
            string avatar = DriverInstance.GetFilesDirectory() + new Random().Next(1, 4) + ".jpg";
            Log.For(this).InfoFormat("avatar path = {0}", avatar);
            upload_button.SendKeys(avatar);
            submit_button.Click();
            return new Profile(driver);    
        }
        public void ChangePassword(string current_password, string new_password)
        {
            password_btn.Click();
            IWebElement current_original_password_input = driver.FindElement(By.Id("user_original_password"));
            IWebElement current_password_input = driver.FindElement(By.Id("user_password"));
            current_original_password_input.SendKeys(current_password);
            current_password_input.SendKeys(new_password);
            IWebElement change_password_button = driver.FindElement(By.XPath(change_pwd_btn_locator));
            change_password_button.Click();
        }
    }
}
