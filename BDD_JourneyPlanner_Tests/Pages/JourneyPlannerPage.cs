using BDD_JourneyPlanner_Tests.Utilities;

namespace BDD_JourneyPlanner_Tests.Pages;

public class JourneyPlannerPage : HelperClass
{
    
    public JourneyPlannerPage NavigateToJourneyPlannerPage(string journeyPlannerPageUrl)
    {
        NavigateToUrl(journeyPlannerPageUrl);
        return this;
    }

    public JourneyPlannerPage VerifyJourneyPlannerPage()
    {
        return this;
    }

    public JourneyPlannerPage EnterFromLocation(string fromLocation)
    {
        EnterById("", fromLocation);
        return this;
    }
    
    public JourneyPlannerPage EnterDestination(string destination)
    {

        EnterById("", destination);
        return this;
    }
}