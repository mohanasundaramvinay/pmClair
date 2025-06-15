Feature: Budget Categories Retrieval

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve all budget categories
    When I send a GET request to /api/ProjectDataPoints/budget-categories
    Then the API response should be <StatusCode>
    And the response should contain a list of budget categories
    Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving budget categories
    When I send a GET request to /api/ProjectDataPoints/budget-categories
    Then the API response should be <StatusCode>
    And the response should contain an error message
    Examples:
    | StatusCode |
    | 500        |

Scenario Outline: Validate response structure for budget categories
    When I send a GET request to /api/ProjectDataPoints/budget-categories
    Then the API response should be <StatusCode>
    And the response should match the expected JSON schema
    Examples:
    | StatusCode |
    | 200        |