Feature: Crew Bill Rates Visibility

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve crew bill rates visibility settings
    When I send a GET request to /api/ProjectDataPoints/crew-bill-rates-visibility
    Then the API response should be <StatusCode>
    And the response should contain visibility settings for the user role <UserRole>

Examples:
    | StatusCode | UserRole  |
    | 200        | Manager   |
    | 200        | Employee  |
    | 500        | Admin     |