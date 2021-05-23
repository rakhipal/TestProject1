using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestProject1.Pages
{
    class Login
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='SW']/div[1]/div[1]/ul/li[5]/div[3]/div/div[2]/div/p/label")]
        public IWebElement signIn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='username']")]
        public IWebElement Enterusername { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='SW']/div[1]/div[2]/div[2]/section/form/div[2]/button")]
        public IWebElement continueButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='password']")]
        public IWebElement EnterPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='SW']/div[1]/div[2]/div[2]/section/form/div[2]/button/span")]
        public IWebElement loginButton { get; set; }



    }
}
