using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestProject1.Pages
{
    class HomePage
    {
       
        [FindsBy(How =How.XPath,Using = "//*[@id='SW']/div[1]/div[2]/div/div/nav/ul/li[2]/a")]
        public IWebElement hotel { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='hsw_search_button']")]
        public IWebElement searchButton { get; set; }



    }
}
