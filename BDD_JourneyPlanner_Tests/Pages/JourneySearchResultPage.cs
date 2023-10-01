using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BDD_JourneyPlanner_Tests.Pages;

public class JourneySearchResultPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    public JourneySearchResultPage(IWebDriver driver)
    {
        this._driver = driver;
        this._wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
    }

    #region JourneyPlannerSearchResultPageProperties

    IWebElement JourneyResultPageTabHeader
    {
        get
        {
            return _driver.FindElement(By.ClassName("last-breadcrumb"));
        }
    }
    
    IWebElement JourneyResultPageHeader
    {
        get
        {
            return _driver.FindElement(By.ClassName("jp-results-headline"));
        }
    }
    IWebElement JourneyResultPageValidationErrorForInvalidJourneyDetails
    {
        get
        {
            return _driver.FindElement(By.XPath("//ul[@class='field-validation-errors']/li"));
        }
    }
    IWebElement EditJourneyLink
    {
        get
        {
            return _driver.FindElement(By.XPath("//span[contains(text(), 'Edit journey')]"));
        }
    }
    IWebElement PlanJourneyTab
    {
        get
        {
            return _driver.FindElement(By.XPath("//div[@class='breadcrumb-container']/ol/li[2]"));
        }
    }
    IWebElement UpdateJourneyButton
    {
        get
        {
            return _driver.FindElement(By.Id("plan-journey-button"));
        }
    }
    IWebElement Destination
    {
        get
        {
            return _driver.FindElement(By.Id("InputTo"));
        }
    }
    IWebElement FromLocationFromResultPage
    {
        get
        {
            return _driver.FindElement(By.XPath("(//span[contains(text(), 'From:')]/following::strong)[1]"));
        }
    }
    IWebElement DestinationFromResultPage
    {
        get
        {
            return _driver.FindElement(By.XPath("(//span[contains(text(), 'To:')]/following::strong)[1]"));
        }
    }

    IWebElement ClearDestinationField
    {
        get
        {
            return _driver.FindElement(By.XPath("//a[contains(text(), 'Clear To location')]"));
        }
    }
    IWebElement LaterJourneyLink
    {
        get
        {
            return _driver.FindElement(By.XPath("//a[contains(text(), 'Discover quieter times to travel')]"));
        }
    }
    #endregion

    public string VerifyJourneyResultPageTabHeader()
    {
        string tabHeader = _wait.Until(x => JourneyResultPageTabHeader).Text;
        return tabHeader;
    }
    
    public Boolean IsJourneyResultPageTabHeaderDisplayed()
    {
        Boolean tabHeader = _wait.Until(x => JourneyResultPageTabHeader).Displayed;
        return tabHeader;
    }
    
    public string VerifyJourneyResultPageHeader()
    {
        string header = _wait.Until(x => JourneyResultPageHeader).Text;
        return header;
    }
    
    public bool IsJourneyResultPageHeaderPresent()
    {
        bool tabHeader = _wait.Until(x => JourneyResultPageHeader).Displayed;
        return tabHeader;
    }
    
    public string VerifyJourneyResultPageFieldValidationError()
    {
        string errorMessage = _wait.Until(x => JourneyResultPageValidationErrorForInvalidJourneyDetails).Text;
        return errorMessage;
    }

    public JourneySearchResultPage ClickOnEditJourneyButton()
    {
        _wait.Until(x => EditJourneyLink).Click();
        return this;
    }
    
    public JourneySearchResultPage ClickOnPlanJourneyTab()
    {
        _wait.Until(x => PlanJourneyTab).Click();
        return this;
    }
    
    public JourneySearchResultPage ClickOnUpdateJourneyButton()
    {
        _wait.Until(x => UpdateJourneyButton).Click();
        return this;
    }
    
    public JourneySearchResultPage EnterDestination(string destination)
    {
        _wait.Until(x => Destination).Clear();
        Destination.SendKeys(destination);
        return this;
    }
    public JourneySearchResultPage UpdateDestination(string destination)
    {
        _wait.Until(x => ClearDestinationField).Click();
        Destination.SendKeys(destination);
        return this;
    }
    
    public string GetFromLocation()
    {
        string fromLocation = _wait.Until(x => FromLocationFromResultPage).Text;
        return fromLocation;
    }
    
    public string GetToLocation()
    {
        string destination = _wait.Until(x => DestinationFromResultPage).Text;
        return destination;
    }
    
    public bool VerifyLaterJourneyButtonDisplayed()
    {
        bool laterJourneyButton = _wait.Until(x => LaterJourneyLink).Displayed;
        return laterJourneyButton;
    }
    
}