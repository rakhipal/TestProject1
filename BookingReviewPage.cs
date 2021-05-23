using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestProject1.Pages
{
    class BookingReviewPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='detpg_headerright_book_now']")]
        public IWebElement BookNowButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div[3]/div/div[1]/div/p")]
        public IWebElement ReviewText { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='fName']")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='lName']")]
        public IWebElement LatName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='email']")]
        public IWebElement EmailId { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='mNo']")]
        public IWebElement ContactNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div[3]/div/div[2]/div[1]/div[5]/a")]
        public IWebElement PayNow { get; set; }

    }
}
