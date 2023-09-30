Feature: TFL Journey Planner Tests

Background: 
	Given the user land on the journey planner page
	
Scenario: Successfully plan a journey with valid journey details
	Given the user provide valid starting location
	And the user provide valid destination
	When the user click on plan my journey button
	Then the user should be redirected to journey result page
	And the user should see the search result
	
@Ignore
Scenario: Failed to plan a journey with invalid journey details
	Given the user provide invalid starting location
	And the user provide invalid destination
	When the user click on plan my journey button
	Then the user should be redirected to journey result page
	And the user should see "Journey planner could not find any result to your search. Please try again"
	
@Ignore	
Scenario: Failed to plan a journey with Empty journey details
	Given the user decided not to enter starting location
	And the user decided not to enter destination
	When the user click on plan my journey button
	Then the user should see validation error message
	And the user should not redirected to journey result page
	
	
	

	
	
	
