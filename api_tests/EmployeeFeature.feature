Feature: Employee Retrieval

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve all employees
    When I send a GET request to /api/ProjectDataPoints/employees
    Then the API response should be <StatusCode>
    And the response should contain a list of employees
    Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Retrieve employees with invalid endpoint
    When I send a GET request to /api/ProjectDataPoints/invalid-endpoint
    Then the API response should be <StatusCode>
    Examples:
    | StatusCode |
    | 404        |

Scenario Outline: Retrieve employees with server error
    When I simulate a server error for GET /api/ProjectDataPoints/employees
    Then the API response should be <StatusCode>
    Examples:
    | StatusCode |
    | 500        |