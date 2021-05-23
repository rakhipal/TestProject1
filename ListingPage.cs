using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestProject1.Pages
{
    class ListingPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='seoH1DontRemove']")]
        public IWebElement VerifyHotelListing { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Listing_hotel_0']")]
        public IWebElement SelectHotel { get; set; }

    }
}
