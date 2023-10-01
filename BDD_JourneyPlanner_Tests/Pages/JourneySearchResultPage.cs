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
            return _driver.FindElement(By.XPath("//li[contains(text(), 'Sorry')]"));
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
    
    public Boolean IsJourneyResultPageHeaderPresent()
    {
        Boolean tabHeader = _wait.Until(x => JourneyResultPageHeader).Enabled;
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
    
}