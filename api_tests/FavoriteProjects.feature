Feature: Favorite Projects Retrieval

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve favorite projects for a user
    When I send a GET request to /api/ProjectDataPoints/favorite-projects
    Then the API response should be a list of favorite projects with status code <StatusCode>
Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Retrieve favorite projects with no favorites
    Given the user has no favorite projects
    When I send a GET request to /api/ProjectDataPoints/favorite-projects
    Then the API response should be an empty list with status code <StatusCode>
Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Retrieve favorite projects with server error
    Given the server is down
    When I send a GET request to /api/ProjectDataPoints/favorite-projects
    Then the API response should be an error message with status code <StatusCode>
Examples:
    | StatusCode |
    | 500        |