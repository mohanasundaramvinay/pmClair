Feature: Currencies API

Background:
    Given the API is running

Scenario Outline: Retrieve all currencies
    When I send a GET request to /api/ProjectDataPoints/currencies
    Then the API response should be <StatusCode>
    And the response should contain a list of currencies
    Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Retrieve currencies with invalid endpoint
    When I send a GET request to /api/ProjectDataPoints/currencies-invalid
    Then the API response should be <StatusCode>
    Examples:
    | StatusCode |
    | 404        |

Scenario Outline: Retrieve currencies with server error
    Given the server is down
    When I send a GET request to /api/ProjectDataPoints/currencies
    Then the API response should be <StatusCode>
    Examples:
    | StatusCode |
    | 500        |