Feature: APITest

As a user i want to verify the service

@GetMethod
Scenario: verify the service Get Method
	Given I call the API 
	Then I should get the response
	 
@PostMethod
Scenario: verify the service of Post Method
	Given I prepare the data to be sent
    When I send a POST request to the API
    Then I should get a successful response
    
 


