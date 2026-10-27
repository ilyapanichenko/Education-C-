Feature: Login
Testing the Qase login page

Scenario: Login page opens successfully
    Given the browser is open
    When I open the Qase login page
    Then the email field is visible
    And the password field is visible

Scenario: Login with invalid password
    Given the browser is open
    When I open the Qase login page
    And I accept cookies if present
    And I enter my email
    And I enter the password "InvalidPassword123!"
    And I click the login button
    Then I should see the error "These credentials do not match our records."