using BDD_JourneyPlanner_Tests.Pages;

namespace BDD_JourneyPlanner_Tests.Steps;

[Binding]
public sealed class JourneyPlannerStepDefinitions
{
    [Given(@"the user land on the journey planner page")]
    public void GivenTheUserLandOnTheJourneyPlannerPage()
    {
        new JourneyPlannerPage()
            .NavigateToJourneyPlannerPage("https://tfl.gov.uk/plan-a-journey/");
    }

    [Given(@"the user provide valid starting location")]
    public void GivenTheUserProvideValidStartingLocation()
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"the user provide valid destination")]
    public void GivenTheUserProvideValidDestination()
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"the user click on plan my journey button")]
    public void WhenTheUserClickOnPlanMyJourneyButton()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the user should be redirected to journey result page")]
    public void ThenTheUserShouldBeRedirectedToJourneyResultPage()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the user should see the search result")]
    public void ThenTheUserShouldSeeTheSearchResult()
    {
        ScenarioContext.StepIsPending();
    }
}