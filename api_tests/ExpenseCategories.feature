Feature: Expense Categories Retrieval

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve all expense categories
    When I send a GET request to /api/ProjectDataPoints/expense-categories
    Then the API response should be <StatusCode> and contain a list of expense categories

Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving expense categories
    When I send a GET request to /api/ProjectDataPoints/expense-categories
    Then the API response should be <StatusCode> and contain an error message

Examples:
    | StatusCode |
    | 500        |