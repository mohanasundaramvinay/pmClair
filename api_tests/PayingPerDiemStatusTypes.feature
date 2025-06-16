Feature: Paying Per Diem Status Types

Background:
    Given the API is running

Scenario Outline: Retrieve all paying per diem status types
    When I send a GET request to /api/ProjectDataPoints/paying-per-diem-status-types
    Then the API response should be <StatusCode>
    And the response should contain a list of per diem status types

Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving per diem status types
    When I send a GET request to /api/ProjectDataPoints/paying-per-diem-status-types
    Then the API response should be <StatusCode>
    And the response should contain an error message

Examples:
    | StatusCode |
    | 500        |