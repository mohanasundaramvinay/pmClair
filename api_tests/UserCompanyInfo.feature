Feature: User Company Info Retrieval

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve user company info
    When I send a GET request to /api/ProjectDataPoints/user-company-info
    Then the API response should be: <StatusCode>
    And the response should contain company information
Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Retrieve user company info with invalid token
    Given I have an invalid authentication token
    When I send a GET request to /api/ProjectDataPoints/user-company-info
    Then the API response should be: <StatusCode>
Examples:
    | StatusCode |
    | 401        |

Scenario Outline: Retrieve user company info with server error
    Given the server is down
    When I send a GET request to /api/ProjectDataPoints/user-company-info
    Then the API response should be: <StatusCode>
Examples:
    | StatusCode |
    | 500        |