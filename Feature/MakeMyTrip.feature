Feature: MakeMyTrip
	Make my trip scenarios


@Sanity
Scenario Outline: 01Login into the Make My Trip application 
	Given Click on the login button in login pop up
	When Enter <username>
	And Click on continue button
	Then Enter <password>
	And Click on login button
Examples: 
 | username                | password  |
 | rakhi.pal54@gmail.com   | Icando@92 |
 | rakhi.pal@accenture.com | Icando@93 | 

@Sanity
Scenario: 02Search for the hotel 
	Given Click on hotel Tab
	When Select the city from drop down
	And Select the Checkin and Checkout date
	Then Click on search button
	Then verify that listing page is showing with hotel list


@Sanity
Scenario: 03Create a hotel booking till payment page
	Given Click on hotel Tab
	Then Click on search button 
	Then verify that listing page is showing with hotel list
    Then Select one hotel from listing page
	And click on book now button
	Then Verify that user is redirected to review booking page
	Then Fill the mandatory guest details
	Then click on pay now button
	

