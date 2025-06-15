Feature: Equipment Subhire Statuses Retrieval

Background:
    Given the API is running and accessible

Scenario Outline: Retrieve equipment subhire statuses
    When I send a GET request to /api/ProjectDataPoints/equipment-subhire-statuses
    Then the API response should be <StatusCode>
    And the response should contain a list of equipment subhire statuses
Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving equipment subhire statuses
    When I send a GET request to /api/ProjectDataPoints/equipment-subhire-statuses
    Then the API response should be <StatusCode>
Examples:
    | StatusCode |
    | 500        |

Scenario Outline: Validate response structure for equipment subhire statuses
    When I send a GET request to /api/ProjectDataPoints/equipment-subhire-statuses
    Then the response should contain fields <Fields>
Examples:
    | Fields                                      |
    | StatusCode, Description, ColorCode, SortOrder, IsCompleted, IsCancelled, IsPending |