Feature: Pollstar Venues Retrieval

Background:
    Given the API is running

Scenario Outline: Retrieve all Pollstar venues
    When I send a GET request to /api/ProjectDataPoints/pollstar-venues
    Then the API response should be <StatusCode>
    And the response should contain a list of venues
    Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Retrieve Pollstar venues with invalid endpoint
    When I send a GET request to /api/ProjectDataPoints/invalid-endpoint
    Then the API response should be <StatusCode>
    Examples:
    | StatusCode |
    | 404        |

Scenario Outline: Retrieve Pollstar venues with server error
    Given the server is down
    When I send a GET request to /api/ProjectDataPoints/pollstar-venues
    Then the API response should be <StatusCode>
    Examples:
    | StatusCode |
    | 500        |