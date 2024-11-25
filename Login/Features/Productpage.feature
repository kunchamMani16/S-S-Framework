@ProductPage
Feature: Product page

Working on product page

Background: 
Given I need to Logged in and see the Product page

@Dropdown
Scenario: Verify dropdown in product page 
	When I select the option "Name (A to Z)" from the dropdown
	Then The option "Name (A to Z)" should be selected
