Feature: Project Statuses Retrieval

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve project statuses
    When I send a GET request to /api/ProjectDataPoints/project-statuses
    Then the API response should be a list of project statuses with status code <StatusCode>

Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Retrieve project statuses with invalid endpoint
    When I send a GET request to /api/ProjectDataPoints/invalid-endpoint
    Then the API response should be a 404 Not Found error

Examples:
    | StatusCode |
    | 404        |

Scenario Outline: Retrieve project statuses with server error simulation
    When I simulate a server error for GET request to /api/ProjectDataPoints/project-statuses
    Then the API response should be a 500 Internal Server Error

Examples:
    | StatusCode |
    | 500        |