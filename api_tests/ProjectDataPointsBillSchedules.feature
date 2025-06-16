Feature: Project Data Points - Bill Schedules

Background:
    Given I have access to the Project Data Points API

Scenario Outline: Retrieve all bill schedules
    When I send a GET request to /api/ProjectDataPoints/bill-schedules
    Then the API response should be <StatusCode>
    And the response should contain a list of bill schedules

Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving bill schedules
    When I send a GET request to /api/ProjectDataPoints/bill-schedules
    Then the API response should be <StatusCode>
    And the response should contain an error message

Examples:
    | StatusCode |
    | 500        |