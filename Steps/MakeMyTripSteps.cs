using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using NUnit;
using NUnit.Framework;
using System.Collections;
using SeleniumExtras.WaitHelpers;
using TestProject1.Pages;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using TestProject1.Base;
using TestProject1.Hooks;

namespace TestProject1.Steps 
{
    [Binding]
    public class MakeMyTripStep
    {
      
        String currentWindowHandle;
        Login loginPage = new Login();
        HomePage homePage = new HomePage();
        ListingPage listPage = new ListingPage();
        BookingReviewPage reviewPage = new BookingReviewPage();
        public IWebDriver driver;
        String TestURL = "https://www.makemytrip.com/";

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver(@"C:\Users\91882\source\repos\TestProject1\Driver");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(TestURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

       
        [Given(@"Click on the login button in login pop up")]
        public void GivenClickOnTheLoginButtonInLoginPopUp()
        {

            PageFactory.InitElements(driver, loginPage);
            loginPage.signIn.Click();

            // Using wait here because sometimes my systems performance
            // so slow and takes time to load next page
            Thread.Sleep(6000);

        }

        [When(@"Enter (.*)")]
        public void WhenEnterUserName(string username)
        {
            loginPage.Enterusername.SendKeys(username);
        }

        [When(@"Click on continue button")]
        public void WhenClickOnContinueButton()
        {
            loginPage.continueButton.Click();
            Thread.Sleep(6000);
        }

        [Then(@"Enter (.*)")]
        public void ThenEnterPassword(string password)
        {
            loginPage.EnterPassword.SendKeys(password);
        }

        [Then(@"Click on login button")]
        public void ThenClickOnLoginButton()
        {
            loginPage.loginButton.Click();
        }

        [Given(@"Click on hotel Tab")]
        public void GivenClickOnHotelIcon()
        {
            driver.Navigate().Refresh();
            Thread.Sleep(5000);
            PageFactory.InitElements(driver, homePage);
            homePage.hotel.Click();
            Thread.Sleep(6000);
        }

        [When(@"Select the city from drop down")]
        public void WhenSelectTheCityFromDropDown()
        {
        }

        [When(@"Select the Checkin and Checkout date")]
        public void WhenSelectTheCheckinAndCheckoutDate()
        {
        }

        [Then(@"Click on search button")]
        public void ThenClickOnSearchButton()
        {
            homePage.searchButton.Click();
        }

        [Then(@"verify that listing page is showing with hotel list")]
        public void ThenVerifyThatListingPageIsShowingWithHotelList()
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='seoH1DontRemove']")));

            IWebElement VerifyHotelText = driver.FindElement(By.XPath("//*[@id='seoH1DontRemove']"));
            String ActualText = VerifyHotelText.Text;
            String ExpectedText = "Hotels, Villas, Apartments and more in Goa";
            Assert.AreEqual(ExpectedText, ActualText);

        }


        [Then(@"Select one hotel from listing page")]
        public void ThenSelectOneHotelFromListingPage()
        {
            Thread.Sleep(6000);
            currentWindowHandle = driver.CurrentWindowHandle;
            PageFactory.InitElements(driver, listPage);  
            listPage.SelectHotel.Click();
            Thread.Sleep(6000);

        }

        [Then(@"click on book now button")]
        public void ThenClickOnBookNowButton()
        {
            var tabs = new ArrayList(driver.WindowHandles);
            int size = tabs.Count;
            string firstTab = (string)tabs[0];
            string secTab = (string)tabs[1];
            if (currentWindowHandle == firstTab)
            {
                driver.SwitchTo().Window(secTab);

            }
            else
            {
                driver.SwitchTo().Window(firstTab);
            }

            PageFactory.InitElements(driver, reviewPage);
            reviewPage.BookNowButton.Click();
            Thread.Sleep(6000);
        }
        [Then(@"Verify that user is redirected to review booking page")]
        public void ThenVerifyThatUserIsRedirectedToReviewBookingPage()
        {
            IWebElement review = driver.FindElement(By.XPath("//*[@id='root']/div/div[3]/div/div[1]/div/p"));
            String ActualReviewText = review.Text;
            String ExpecReviewText = "Review your Booking";
            Assert.AreEqual(ExpecReviewText, ActualReviewText);
        }

        [Then(@"Fill the mandatory guest details")]
        public void ThenFillTheMandatoryGuestDetails()
        {
            reviewPage.FirstName.SendKeys("Rakhi");
            reviewPage.LatName.SendKeys("Pal");
            reviewPage.EmailId.SendKeys("rakhi.pal54@gmail.com");
            reviewPage.ContactNumber.SendKeys("8826026571");
        }

        [Then(@"click on pay now button")]
        public void ThenClickOnPayNowButton()
        {
            reviewPage.PayNow.Click();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }


    }
}
