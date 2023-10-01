using BDD_JourneyPlanner_Tests.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BDD_JourneyPlanner_Tests.Pages;

public class JourneyPlannerPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    
    private string _fromLocation;
    private string _destination;

    public string FromLocation
    {
        get { return _fromLocation; }
        set { _fromLocation = value; }
    }
    public string Destination
    {
        get { return _destination; }
        set { _destination = value; }
    }

    public JourneyPlannerPage(IWebDriver driver)
    {
        this._driver = driver;
        this._wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
    }

    #region JourneyPlannerPageProperties

    IWebElement AcceptCookiesButton
    {
        get
        {
            return _driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
        }
    }
    IWebElement FromLocationField
    {
        get
        {
            return _driver.FindElement(By.Id("InputFrom"));
        }
    }
    IWebElement ToLocationField
    {
        get
        {
            return _driver.FindElement(By.Id("InputTo"));
        }
    }
    IWebElement SelectFirstItemFromDestinationDropdown
    {
        get
        {
            return _driver.FindElement(By.Id("stops-recent-magic-searches-suggestion-0"));
        }
    }
    IWebElement JourneyPlannerButton
    {
        get
        {
            return _driver.FindElement(By.Id("plan-journey-button"));
        }
    }
    IWebElement JourneyPlannerHeader
    {
        get
        {
            return _driver.FindElement(By.ClassName("hero-headline"));
        }
    }
    IWebElement JourneyPlannerValidationErrorMessageForEmptyFromField
    {
        get
        {
            return _driver.FindElement(By.Id("InputFrom-error"));
        }
    }
    IWebElement JourneyPlannerValidationErrorMessageForEmptyToField
    {
        get
        {
            return _driver.FindElement(By.Id("InputTo-error"));
        }
    }
    IWebElement RecentTab
    {
        get
        {
            return _driver.FindElement(By.Id("jp-recent-tab-jp"));
        }
    }
    IWebElement RecentJourneys
    {
        get
        {
            return _driver.FindElement(By.XPath("//div[@id='jp-recent-content-jp-']/a"));
        }
    }
    #endregion
    public JourneyPlannerPage NavigateToJourneyPlannerPage(string journeyPlannerPageUrl)
    {
        _driver.Navigate().GoToUrl(journeyPlannerPageUrl);
        return this;
    }

    public string VerifyJourneyPlannerPageTitle()
    {
        String title  = _driver.Title;
        return title;
    }
    
    public string VerifyJourneyPlannerPageValidationErrorMessageForFromField()
    {
        String errorForFromField  = _wait.Until(x => JourneyPlannerValidationErrorMessageForEmptyFromField).Text;
        return errorForFromField;
    }
    
    public string VerifyJourneyPlannerPageValidationErrorMessageForToField()
    {
        String errorForToField  = _wait.Until(x => JourneyPlannerValidationErrorMessageForEmptyToField).Text;
        return errorForToField;
    }

    public JourneyPlannerPage AcceptCookies()
    {
        if (AcceptCookiesButton.Displayed)
        {
            AcceptCookiesButton.Click();
        }
        return this;
    }

    public string VerifyJourneyPlannerPageHeader()
    {
        string header = _wait.Until(x => JourneyPlannerHeader).Text;
        return header;
    }
    
    public string GetRecentSearchJourneys()
    {
        string recentJourneys = _wait.Until(x => RecentJourneys).Text;
        return recentJourneys;
    }
    
    public JourneyPlannerPage EnterFromLocation(string fromLocation)
    {
        _wait.Until(x => FromLocationField).Clear();
        FromLocationField.SendKeys(fromLocation);
        return this;
    }
    
    public string GetFromLocation()
    {
        string fromLocation = _wait.Until(x => FromLocationField).GetAttribute("value");
        return fromLocation;
    }
    
    public JourneyPlannerPage EnterDestination(string destination)
    {

        _wait.Until(x => ToLocationField).Clear();
        ToLocationField.SendKeys(destination);
        return this;
    }
    
    public string GetDestination()
    {
        string destination = _wait.Until(x => ToLocationField).GetAttribute("value");
        return destination;
    }
    
    public JourneyPlannerPage ClickOnJourneyPlannerButton()
    {
        _wait.Until(x => JourneyPlannerButton).Click();
        return this;
    }
    
    public JourneyPlannerPage ClickOnRecentTabButton()
    {
        _wait.Until(x => RecentTab).Click();
        return this;
    }
}