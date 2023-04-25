Feature: ReportPortalLogIn
	Simple calculator for adding two numbers

@mytag
Scenario Outline: Complete Log In to Report Portal Web App
	Given I navigate to Web Report Portal 
	And The Login page is display
	When I intruduce the "<username>" and "<password>" to get login
	Then I will navigate to Report Portal landing page 

	Examples: 
	| username                        | password       |
	| marinba1990                     | Password123    |