Feature: Get Next Available Project Number

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve the next available project number
    When I send a GET request to /api/projects/next
    Then the API response should be a valid integer
    And the status code should be <StatusCode>

Examples:
    | StatusCode |
    | 200        |
    | 500        |