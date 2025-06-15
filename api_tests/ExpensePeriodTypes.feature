Feature: Expense Period Types Retrieval

Background:
    Given the API is running and accessible

Scenario Outline: Retrieve expense period types
    When I send a GET request to /api/ProjectDataPoints/expense-period-types
    Then the API response should be <StatusCode>
    And the response should contain a list of expense period types
    Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Retrieve expense period types with invalid endpoint
    When I send a GET request to /api/ProjectDataPoints/invalid-endpoint
    Then the API response should be <StatusCode>
    Examples:
    | StatusCode |
    | 404        |

Scenario Outline: Retrieve expense period types with server error
    Given the server is down
    When I send a GET request to /api/ProjectDataPoints/expense-period-types
    Then the API response should be <StatusCode>
    Examples:
    | StatusCode |
    | 500        |