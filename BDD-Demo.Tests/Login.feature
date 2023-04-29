Feature: Login
    Ensures that access to internal areas is only provided for authenticated users
    
Scenario: Invalid login credentials prevent access to internal areas
    Given the user has opened the login page
    When the user enters invalid login credentials
    When the user clicks on the login button
    Then an error message is shown
    Then the user stays on the login page
    
Scenario: Valid login credentials allow access to internal areas
    Given the user has opened the login page
    When the user enters valid login credentials
    When the user clicks on the login button
    Then the user is redirected to an internal page

Scenario Outline: Invalid login
    Given the user has opened the login page
    When the user enters the password <password>
    When the user enters the user <user>
    When the user clicks on the login button
    Then an error message is shown
    Then the user stays on the login page

    Examples:
    | user  | password |
    | abc   | 123      |
    | admin | testtest |
       