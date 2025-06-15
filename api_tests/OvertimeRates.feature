Feature: Overtime Rates Retrieval

Background:
    Given the API is running and accessible

Scenario Outline: Retrieve overtime rates
    When I send a GET request to /api/ProjectDataPoints/overtime-rates
    Then the API response should be <StatusCode>
    And the response should contain a list of overtime rates

Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving overtime rates
    When I send a GET request to /api/ProjectDataPoints/overtime-rates
    Then the API response should be <StatusCode>
    And the response should contain an error message

Examples:
    | StatusCode |
    | 500        |

Scenario Outline: Validate response structure for overtime rates
    When I send a GET request to /api/ProjectDataPoints/overtime-rates
    Then the API response should be <StatusCode>
    And each overtime rate should have a RateType, Description, Multiplier, and ActiveStatus

Examples:
    | StatusCode |
    | 200        |