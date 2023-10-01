using BDD_JourneyPlanner_Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BDD_JourneyPlanner_Tests.Steps;

[Binding]
public sealed class JourneyPlannerStepDefinitions
{
    private IWebDriver _driver;
    private JourneyPlannerPage journeyPlannerPage;
    private JourneySearchResultPage journeySearchResultPage;
    

    public JourneyPlannerStepDefinitions(IWebDriver driver)
    {
        
        this._driver = driver;
        journeyPlannerPage = new JourneyPlannerPage(_driver);
        journeySearchResultPage = new JourneySearchResultPage(_driver);

    }
    [Given(@"the user land on the journey planner page")]
    public void GivenTheUserLandOnTheJourneyPlannerPage()
    {
        
        journeyPlannerPage.NavigateToJourneyPlannerPage("https://tfl.gov.uk/plan-a-journey/");
        journeyPlannerPage.AcceptCookies();
        Assert.AreEqual("Plan a journey - Transport for London", journeyPlannerPage.VerifyJourneyPlannerPageTitle());
        Assert.AreEqual("Plan a journey", journeyPlannerPage.VerifyJourneyPlannerPageHeader());
    }

    [Given(@"the user provide valid starting location")]
    public void GivenTheUserProvideValidStartingLocation()
    {
        journeyPlannerPage.FromLocation = "City of London, London Bridge";
        journeyPlannerPage.EnterFromLocation("City of London, London Bridge");
    }

    [Given(@"the user provide valid destination")]
    public void GivenTheUserProvideValidDestination()
    {
        journeyPlannerPage.Destination = "Leeds Rail Station";
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
        
        Assert.AreEqual("Journey results", journeySearchResultPage.VerifyJourneyResultPageTabHeader());
        Assert.AreEqual("Journey results", journeySearchResultPage.VerifyJourneyResultPageHeader());
    }

    [Then(@"the user see the journey details on the search result")]
    public void ThenTheUserSeeTheJourneyDetailsOnTheSearchResult()
    {
        
        Assert.AreEqual("Journey results", journeySearchResultPage.VerifyJourneyResultPageTabHeader());
        Assert.AreEqual("Journey results", journeySearchResultPage.VerifyJourneyResultPageHeader());
        
        Assert.AreEqual(journeyPlannerPage.FromLocation, journeySearchResultPage.GetFromLocation());
        Assert.AreEqual(journeyPlannerPage.Destination, journeySearchResultPage.GetToLocation());
    }

    [Given(@"the user provide invalid starting location")]
    public void GivenTheUserProvideInvalidStartingLocation()
    {
        
        journeyPlannerPage.EnterFromLocation("545678");
    }

    [Given(@"the user provide invalid destination")]
    public void GivenTheUserProvideInvalidDestination()
    {
        
        journeyPlannerPage.EnterDestination("7634567890");
    }

    [Then(@"the user should see ""(.*)""")]
    public void ThenTheUserShouldSee(string validationMessage)
    {
        
        Assert.AreEqual(validationMessage, journeySearchResultPage.VerifyJourneyResultPageFieldValidationError());
    }

    [When(@"the user decided to click plan my journey button without providing journey details")]
    public void WhenTheUserDecidedToClickPlanMyJourneyButtonWithoutProvidingJourneyDetails()
    {
        journeyPlannerPage.ClickOnJourneyPlannerButton();
    }

    [Then(@"the user should get the validation error message")]
    public void ThenTheUserShouldGetValidationErrorMessage()
    {
        
        Assert.AreEqual("The From field is required.", journeyPlannerPage.VerifyJourneyPlannerPageValidationErrorMessageForFromField());
        Assert.AreEqual("The To field is required.", journeyPlannerPage.VerifyJourneyPlannerPageValidationErrorMessageForToField());
    }

    [Then(@"the user should not redirected to journey result page")]
    public void ThenTheUserShouldNotRedirectedToJourneyResultPage()
    {
        
        Assert.IsFalse(journeySearchResultPage.IsJourneyResultPageHeaderPresent(), "Element should not be visible");
    }

    [Given(@"the user plan a journey with valid journey details")]
    public void GivenTheUserPlanAJourneyWithValidJourneyDetails()
    {

        journeyPlannerPage.FromLocation = "City of London, London Bridge";
        journeyPlannerPage.EnterFromLocation("City of London, London Bridge");
        journeyPlannerPage.EnterDestination("Leeds Rail Station");
        journeyPlannerPage.ClickOnJourneyPlannerButton();
    }

    [When(@"the user decided to edit the journey details")]
    public void WhenTheUserDecidedToEditTheJourneyDetails()
    {
        
        journeySearchResultPage.ClickOnEditJourneyButton();
    }

    [When(@"the user click on update journey button to update the journey details")]
    public void WhenTheUserClickOnUpdateJourneyButtonToUpdateTheJourneyDetails()
    {

        journeyPlannerPage.Destination = "Croydon (London), West Croydon Station";
        journeySearchResultPage.UpdateDestination(journeyPlannerPage.Destination);
        journeySearchResultPage.ClickOnUpdateJourneyButton();
    }

    [Given(@"the user decided to view the recent journey details")]
    public void GivenTheUserDecidedToViewTheRecentJourneyDetails()
    {
        journeyPlannerPage.FromLocation = journeyPlannerPage.GetFromLocation();
        journeyPlannerPage.EnterFromLocation("City of London, London Bridge");
        journeyPlannerPage.EnterDestination("Leeds Rail Station");
        journeyPlannerPage.Destination = journeyPlannerPage.GetDestination();
        journeyPlannerPage.ClickOnJourneyPlannerButton();
        Assert.AreEqual("Journey results", journeySearchResultPage.VerifyJourneyResultPageTabHeader());
        Assert.AreEqual("Journey results", journeySearchResultPage.VerifyJourneyResultPageHeader());
        Assert.AreEqual(journeyPlannerPage.FromLocation, journeySearchResultPage.GetFromLocation());
        Assert.AreEqual(journeyPlannerPage.Destination, journeySearchResultPage.GetToLocation());
        Assert.IsTrue(journeySearchResultPage.VerifyLaterJourneyButtonDisplayed(), "Element should be visible");
        journeySearchResultPage.ClickOnPlanJourneyTab();
    }

    [When(@"the user click on the recent button to view recent journeys")]
    public void WhenTheUserClickOnTheRecentButtonToViewRecentJourneys()
    {
        
        journeyPlannerPage.ClickOnRecentTabButton();
    }

    [Then(@"the user should be able to see all the recent journeys")]
    public void ThenTheUserShouldBeAbleToSeeAllTheRecentJourneys()
    {
        
        // Assert.That(journeyPlannerPage.FromLocation, Does.Contain(journeyPlannerPage.GetRecentSearchJourneys()));
        Assert.That(journeyPlannerPage.Destination, Does.Contain(journeyPlannerPage.GetRecentSearchJourneys()));
    }

    [Given(@"the user provide invalid starting location (.*)")]
    public void GivenTheUserProvideInvalidStartingLocation(string fromLocation)
    {
        journeyPlannerPage.EnterFromLocation(fromLocation);
    }

    [Given(@"the user provide invalid destination (.*)")]
    public void GivenTheUserProvideInvalidDestination(string destination)
    {
        journeyPlannerPage.EnterDestination(destination);
    }

    [Then(@"the user should see (.*)")]
    public void ThenTheUserShouldSeeValidationErrorMessage(string validationMessage)
    {
        
        Assert.AreEqual(validationMessage, journeySearchResultPage.VerifyJourneyResultPageFieldValidationError());
    }
}