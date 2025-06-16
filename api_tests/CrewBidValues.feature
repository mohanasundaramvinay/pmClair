Feature: Crew Bid Values Retrieval

Background:
    Given the API is running and accessible

Scenario Outline: Retrieve crew bid values
    When I send a GET request to /api/ProjectDataPoints/crew-bid-values
    Then the API response should be <StatusCode>
    And the response should contain a list of crew bid values
    And each crew bid value should have fields: EmployeeId, JobType, BidRate, EffectiveDate, IsActive

Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving crew bid values
    When I send a GET request to /api/ProjectDataPoints/crew-bid-values
    Then the API response should be <StatusCode>
    And the response should contain an error message

Examples:
    | StatusCode |
    | 500        |

Scenario Outline: Validate response structure for crew bid values
    When I send a GET request to /api/ProjectDataPoints/crew-bid-values
    Then the API response should be <StatusCode>
    And the response should be a JSON array
    And each item in the array should have the correct data types

Examples:
    | StatusCode |
    | 200        |