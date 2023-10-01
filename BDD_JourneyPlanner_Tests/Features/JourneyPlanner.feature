Feature: TFL Journey Planner Tests

Background: 
	Given the user land on the journey planner page
		
Scenario: Successfully plan a journey with valid journey details
	Given the user provide valid starting location
	And the user provide valid destination
	When the user click on plan my journey button
	Then the user should be redirected to journey result page
	And the user see the journey details on the search result
	
Scenario Outline: Failed to plan a journey with invalid journey details
	Given the user provide invalid starting location <from>
	And the user provide invalid destination <to>
	When the user click on plan my journey button
	Then the user should be redirected to journey result page
	And the user should see <invalid message>
	Examples: 
	| from   | to         | invalid message                                                             |
	| 11     | 11         | Journey planner could not find any results to your search. Please try again |
	| 545678 | 7634567890 | Sorry, we can't find a journey matching your criteria                       |	
	
Scenario: Failed to plan a journey with Empty journey details
	When the user decided to click plan my journey button without providing journey details
	Then the user should get the validation error message 
			
Scenario: Successfully edit a journey
	Given the user plan a journey with valid journey details
	When the user decided to edit the journey details
	And the user click on update journey button to update the journey details
	Then the user should be redirected to journey result page
	And the user see the journey details on the search result
	
Scenario: Successfully view the recent journeys
	Given the user decided to view the recent journey details
	When the user click on the recent button to view recent journeys
	Then the user should be able to see all the recent journeys
	
	

	
	
	
