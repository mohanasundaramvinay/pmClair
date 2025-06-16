Feature: Commodities API

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve all commodities
    When I send a GET request to /api/ProjectDataPoints/commodities
    Then the API response should be <StatusCode> and contain a list of commodities

Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving commodities
    When I send a GET request to /api/ProjectDataPoints/commodities
    Then the API response should be <StatusCode> with an error message

Examples:
    | StatusCode |
    | 500        |

Scenario Outline: Validate commodity fields
    When I send a GET request to /api/ProjectDataPoints/commodities
    Then each commodity should have a CommodityCode, Description, Category, and IsActive

Examples:
    | StatusCode |
    | 200        |