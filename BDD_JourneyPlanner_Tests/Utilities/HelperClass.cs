using OpenQA.Selenium;

namespace BDD_JourneyPlanner_Tests.Utilities;

public class HelperClass
{
    private IWebDriver _driver;
    
    public HelperClass(){}

    public HelperClass(IWebDriver driver)
    {
        this._driver = driver;
    }

    public void NavigateToUrl(string url)
    {
        _driver.Navigate().GoToUrl(url);
    }

    public void VerifyPageTitle()
    {
        
    }

    public void EnterById(string locator, string value)
    {
        _driver.FindElement(By.Id(locator)).SendKeys(value);
    }

    public void ClickBtId(string locator)
    {
        _driver.FindElement(By.Id(locator)).Click();
    }
    
    
    
}