Feature: Retrieve Proposal Types

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve all proposal types
    When I send a GET request to /api/ProjectDataPoints/proposal-types
    Then the API response should be <StatusCode>
    And the response should contain a list of proposal types
Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving proposal types
    When I send a GET request to /api/ProjectDataPoints/proposal-types
    Then the API response should be <StatusCode>
Examples:
    | StatusCode |
    | 500        |

Scenario Outline: Validate response structure for proposal types
    When I send a GET request to /api/ProjectDataPoints/proposal-types
    Then the API response should be <StatusCode>
    And the response should match the expected structure
Examples:
    | StatusCode |
    | 200        |