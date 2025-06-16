Feature: Contact Categories Retrieval

Background:
    Given the API is running

Scenario Outline: Retrieve all contact categories
    When I send a GET request to /api/ProjectDataPoints/contact-categories
    Then the API response should be <StatusCode>
    And the response should contain a list of contact categories
Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Retrieve contact categories with server error
    When I send a GET request to /api/ProjectDataPoints/contact-categories
    Then the API response should be <StatusCode>
Examples:
    | StatusCode |
    | 500        |