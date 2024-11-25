Feature: RadioButton

 As a user
  I want to be able to interact with RadioButton
 

@RadioButtonCheck
Scenario: Selecting a radio button option
    Given I am on the "<page>" page
    When I select the "<option>" radio button
    Then the "<option>" radio button should be selected

    Examples:
      | page   | option  |
      | Gender | male    |
      | Gender | female  |
      
