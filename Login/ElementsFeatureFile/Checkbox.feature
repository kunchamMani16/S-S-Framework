Feature: Checkbox


  As a user
  I want to be able to interact with checkboxes
  So that I can select or deselect options as needed

  # Scenario to check if a checkbox can be selected
  Scenario: Selecting a checkbox
    Given I am on the checkbox test page
    When I select the checkbox  "Home"
    Then the checkbox with "Home" should be selected

  # Scenario to check if a checkbox can be deselected
  Scenario: Deselecting a checkbox
    Given I am on the checkbox test page
    When I deselect the checkbox with "Home"
    Then the checkbox with "Home" should not be selected

  # Scenario to verify the state of a checkbox
  Scenario: Verify checkbox is not selected
    Given I am on the checkbox test page
    When I check the state of the checkbox
    Then the checkbox with "Home" should not be selected

  # Scenario to verify the state of a checkbox
  Scenario: Verify checkbox is selected
    Given I am on the checkbox test page
    When I select the checkbox  "Home"
    And I check the state of the checkbox
    Then the checkbox with "Home" should be selected
