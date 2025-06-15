Feature: Retrieve Part Categories

Background:
    Given the API is running

Scenario Outline: Retrieve all part categories
    When I send a GET request to /api/ProjectDataPoints/parts/categories
    Then the API response should be <StatusCode>
    And the response should contain the following categories:
    | code       | description            |
    | "(All)"   | "(All)"               |
    | "ELECTRICAL" | "Electrical Equipment" |
    | "MECHANICAL" | "Mechanical Equipment" |

Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving part categories
    When I send a GET request to /api/ProjectDataPoints/parts/categories
    Then the API response should be <StatusCode>

Examples:
    | StatusCode |
    | 500        |