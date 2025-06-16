Feature: Project Price Levels Retrieval

Background:
    Given the Project Data Points API is running

Scenario Outline: Retrieve project price levels
    When I send a GET request to /api/ProjectDataPoints/project-price-levels
    Then the API response should be <StatusCode>
    And the response should contain a list of project price levels
    Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Retrieve project price levels with invalid endpoint
    When I send a GET request to /api/ProjectDataPoints/invalid-endpoint
    Then the API response should be <StatusCode>
    Examples:
    | StatusCode |
    | 404        |

Scenario Outline: Retrieve project price levels with server error
    When I simulate a server error for /api/ProjectDataPoints/project-price-levels
    Then the API response should be <StatusCode>
    Examples:
    | StatusCode |
    | 500        |