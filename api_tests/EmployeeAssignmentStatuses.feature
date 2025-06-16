Feature: Employee Assignment Statuses

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve employee assignment statuses
    When I send a GET request to /api/ProjectDataPoints/employee-assignment-statuses
    Then the API response should be <StatusCode>
    And the response should contain a list of employee assignment statuses

Examples:
    | StatusCode |
    | 200        |
    | 500        |