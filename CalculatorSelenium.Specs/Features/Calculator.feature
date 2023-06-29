@Calculator
Feature: QA Automation Engineer test task

Scenario: Create contact
	Given I login
	When I navigate to sales and marketing
	When I create a contact
	Then Validate that the client is created


Scenario: Run Report
	Given I login
	When I navigate to reports and settings
	When I find the project profitability report
	Then Run the report and verify some of the results were returned

	
Scenario: Remove events from activity log
	Given I login
	When I navigate to reports and settings
	When I select the first three items in the table
	Then I can delete these items
