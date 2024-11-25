Feature: Login
Login Verification
Background: 
	Given I am in login page


@Successfull
Scenario: verify Login Successfully
	When I entered username
	And I entered password
	And I Clicked login button
	Then logged in successfully

@unsuccesfull
Scenario: verify wrong Login with paramter
	When I entered username as "another_user"
	And I entered password as "another_pass"
	And I Clicked login button
	Then logged  unsuccessfully


@DataSource:../Testdata/testdata.csv
Scenario: verify data source login
	When I enter username and password from data source csv as "<username>" and "<password>"
	And I Clicked login button
	Then logged in successfully
