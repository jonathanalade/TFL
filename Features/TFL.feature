Feature: TFL


@mytag
Scenario Outline: Valid Journey
	Given the user navigates to the TFL website
	And the user enters a valid <from> station
	And enters a valid <to> station
	When the user clicks Plan my Journey
	Then the user should see the journey information containing <from>, <to>
	
	Examples: 
	| from                             | to                               |
	| Knightsbridge Underground Station| Sudbury Hill Underground Station |

	@InvalidJourney
Scenario Outline: Invalid Journey
	Given the user navigates to the TFL website
	And the user enters a valid <from> station
	And enters a invalid <to> station
	When the user clicks Plan my Journey
	Then the user should see the journey information containing <from>, <to> 
	
	Examples: 
	| from                             | to                               |
	| Knightsbridge Underground Station | qwertyuiop |
	
	
	

	@EditJourney
Scenario Outline: Edit Journey
	Given the user navigates to the TFL website
	And the user enters a valid <from> station
	And enters a valid <to> station
	When the user clicks Plan my Journey
	And the user edits the journey in the <edit_from> field 
	Then the user updates the journey
	
	Examples: 
	| from                              | to                               | edit_from                       |
	| Knightsbridge Underground Station | Sudbury Hill Underground Station | Hammersmith Station, London, UK |

@NoLocations
Scenario: No Locations Entered 
	Given the user navigates to the TFL website
	When the user clicks Plan my Journey
	Then the user should see two warning signs on the page which says the fields are required
	

	@Recent
Scenario Outline: Recents 
	Given the user navigates to the TFL website
	And the user enters a valid <from> station
	And enters a valid <to> station
	When the user clicks Plan my Journey
	Then the user should see the journey information containing <from>, <to>
	And the user navigates back to the HomePage
	And the user clicks on the Recents Tab, to view the previous journeys
	
	Examples: 
	| from                             | to                               |
	| Knightsbridge Underground Station| Sudbury Hill Underground Station |