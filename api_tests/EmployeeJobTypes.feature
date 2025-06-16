Feature: Employee Job Types Retrieval

Background:
    Given the ProjectDataPoints API is running

Scenario Outline: Retrieve employee job types
    When I send a GET request to /api/ProjectDataPoints/employee-job-types
    Then the API response should be <StatusCode>
    And the response should contain a list of employee job types

Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Retrieve employee job types with invalid endpoint
    When I send a GET request to /api/ProjectDataPoints/invalid-endpoint
    Then the API response should be <StatusCode>

Examples:
    | StatusCode |
    | 404        |

Scenario Outline: Retrieve employee job types with server error
    When I simulate a server error for /api/ProjectDataPoints/employee-job-types
    Then the API response should be <StatusCode>

Examples:
    | StatusCode |
    | 500        |