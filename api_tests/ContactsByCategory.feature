Feature: Contacts by Category

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve contacts by category ID
    When I send a GET request to /api/ProjectDataPoints/contacts/by-category/<CategoryId>
    Then the API response should be <StatusCode>
    And the response should contain <ExpectedContacts> contacts

Examples:
    | CategoryId | StatusCode | ExpectedContacts |
    | 1          | 200        | 2                |
    | 999        | 404        | 0                |
    | -1         | 400        | 0                |
    | 0          | 400        | 0                |
    | 2147483647 | 404        | 0                |
    | null       | 400        | 0                |