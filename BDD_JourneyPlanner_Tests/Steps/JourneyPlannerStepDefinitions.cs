using BDD_JourneyPlanner_Tests.Pages;
using OpenQA.Selenium;

namespace BDD_JourneyPlanner_Tests.Steps;

[Binding]
public sealed class JourneyPlannerStepDefinitions
{
    private IWebDriver _driver;
    private JourneyPlannerPage journeyPlannerPage;
    private JourneySerachResultPage journeySerachResultPage;
    

    public JourneyPlannerStepDefinitions(IWebDriver driver)
    {
        this._driver = driver;
        journeyPlannerPage = new JourneyPlannerPage(_driver);
        // journeySerachResultPage = new JourneySerachResultPage(_driver);

    }
    [Given(@"the user land on the journey planner page")]
    public void GivenTheUserLandOnTheJourneyPlannerPage()
    {
        journeyPlannerPage.NavigateToJourneyPlannerPage("https://tfl.gov.uk/plan-a-journey/");
        journeyPlannerPage.AcceptCookies();
    }

    [Given(@"the user provide valid starting location")]
    public void GivenTheUserProvideValidStartingLocation()
    {
        journeyPlannerPage.EnterFromLocation("City of London, London Bridge");
    }

    [Given(@"the user provide valid destination")]
    public void GivenTheUserProvideValidDestination()
    {
        journeyPlannerPage.EnterDestination("Leeds Rail Station");
    }

    [When(@"the user click on plan my journey button")]
    public void WhenTheUserClickOnPlanMyJourneyButton()
    {
        journeyPlannerPage.ClickOnJourneyPlannerButton();
    }

    [Then(@"the user should be redirected to journey result page")]
    public void ThenTheUserShouldBeRedirectedToJourneyResultPage()
    {
        
    }

    [Then(@"the user should see the search result")]
    public void ThenTheUserShouldSeeTheSearchResult()
    {
        
    }

    [Given(@"the user provide invalid starting location")]
    public void GivenTheUserProvideInvalidStartingLocation()
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"the user provide invalid destination")]
    public void GivenTheUserProvideInvalidDestination()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the user should see ""(.*)""")]
    public void ThenTheUserShouldSee(string p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"the user decided not to enter starting location")]
    public void GivenTheUserDecidedNotToEnterStartingLocation()
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"the user decided not to enter destination")]
    public void GivenTheUserDecidedNotToEnterDestination()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the user should see validation error message")]
    public void ThenTheUserShouldSeeValidationErrorMessage()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the user should not redirected to journey result page")]
    public void ThenTheUserShouldNotRedirectedToJourneyResultPage()
    {
        ScenarioContext.StepIsPending();
    }
}