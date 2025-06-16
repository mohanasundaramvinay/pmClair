Feature: User Menu Inclusions

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve user menu inclusions
    When I send a GET request to /api/ProjectDataPoints/user-menu-inclusions
    Then the API response should be a list of menu inclusions with status code <StatusCode>
Examples:
    | StatusCode |
    | 200        |
    | 500        |