Feature: Rate Types Retrieval

Background:
    Given the API is running

Scenario Outline: Retrieve all rate types
    When I send a GET request to /api/ProjectDataPoints/rate-types
    Then the API response should be <StatusCode>
    And the response should contain a list of rate types
    And each rate type should have the fields: RateTypeCode, Description, SortOrder, DaysPerUnit, IsDaily, IsWeekly, IsMonthly

Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving rate types
    When I send a GET request to /api/ProjectDataPoints/rate-types
    Then the API response should be <StatusCode>
    And the response should contain an error message

Examples:
    | StatusCode |
    | 500        |

Scenario Outline: Validate rate type fields
    When I send a GET request to /api/ProjectDataPoints/rate-types
    Then the API response should be 200
    And each rate type should have valid values for RateTypeCode, Description, SortOrder, DaysPerUnit, IsDaily, IsWeekly, IsMonthly

Examples:
    | RateTypeCode | Description | SortOrder | DaysPerUnit | IsDaily | IsWeekly | IsMonthly |
    | D            | Daily Rate  | 1         | 1.0         | true    | false    | false     |
    | W            | Weekly Rate | 2         | 7.0         | false   | true     | false     |
    | M            | Monthly Rate| 3         | 30.0        | false   | false    | true      |