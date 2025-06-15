Feature: Project Bid Expenses Retrieval

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve bid expenses for a project
    When I send a GET request to /api/projects/<entityNo>/bid-expenses
    Then the API response should be <StatusCode>
    And the response should contain a list of bid expenses
Examples:
    | entityNo | StatusCode |
    | PROJ123  | 200        |
    | PROJ999  | 404        |
    |          | 400        |

Scenario Outline: Retrieve bid expenses with invalid entity number
    When I send a GET request to /api/projects/<entityNo>/bid-expenses
    Then the API response should be <StatusCode>
Examples:
    | entityNo | StatusCode |
    | INVALID  | 400        |
    | 123      | 400        |

Scenario Outline: Retrieve bid expenses for a project with no expenses
    When I send a GET request to /api/projects/<entityNo>/bid-expenses
    Then the API response should be <StatusCode>
    And the response should be an empty list
Examples:
    | entityNo | StatusCode |
    | PROJ456  | 200        |