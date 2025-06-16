Feature: Calculate Part Bottlenecks

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Calculate bottlenecks for valid part numbers
    Given the following part numbers: <PartNumbers>
    When I send a POST request to /api/ProjectDataPoints/parts/calculate-bottlenecks with the part numbers and from date <FromDate>
    Then the API response should be <StatusCode>
    And the response should contain bottleneck calculations for each part
Examples:
    | PartNumbers               | FromDate           | StatusCode |
    | ["PART001", "PART002"] | 2024-01-01T00:00:00 | 200        |
    | ["PART003"]             | 2024-01-01T00:00:00 | 200        |

Scenario Outline: Calculate bottlenecks with empty part numbers
    Given the following part numbers: <PartNumbers>
    When I send a POST request to /api/ProjectDataPoints/parts/calculate-bottlenecks with the part numbers and from date <FromDate>
    Then the API response should be <StatusCode>
    And the response should contain an error message <ErrorMessage>
Examples:
    | PartNumbers | FromDate           | StatusCode | ErrorMessage                      |
    | []          | 2024-01-01T00:00:00 | 400        | "Part numbers list cannot be null or empty" |

Scenario Outline: Calculate bottlenecks with null request
    Given a null request
    When I send a POST request to /api/ProjectDataPoints/parts/calculate-bottlenecks
    Then the API response should be <StatusCode>
    And the response should contain an error message <ErrorMessage>
Examples:
    | StatusCode | ErrorMessage                      |
    | 400        | "Request cannot be null"        |

Scenario Outline: Calculate bottlenecks with invalid date format
    Given the following part numbers: <PartNumbers>
    When I send a POST request to /api/ProjectDataPoints/parts/calculate-bottlenecks with the part numbers and from date <FromDate>
    Then the API response should be <StatusCode>
    And the response should contain an error message <ErrorMessage>
Examples:
    | PartNumbers               | FromDate           | StatusCode | ErrorMessage                      |
    | ["PART001", "PART002"] | invalid-date       | 400        | "Invalid date format"           |