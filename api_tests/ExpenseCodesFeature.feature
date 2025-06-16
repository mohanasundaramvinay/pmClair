Feature: Expense Codes Retrieval

Background:
    Given the API is running and accessible

Scenario Outline: Retrieve all expense codes
    When I send a GET request to /api/ProjectDataPoints/expense-codes
    Then the API response should be <StatusCode> with a list of expense codes
Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving expense codes
    When I send a GET request to /api/ProjectDataPoints/expense-codes
    Then the API response should be <StatusCode> with an error message
Examples:
    | StatusCode |
    | 500        |

Scenario Outline: Validate response structure for expense codes
    When I send a GET request to /api/ProjectDataPoints/expense-codes
    Then the response should contain fields <Fields>
Examples:
    | Fields                                      |
    | Code, Description, Category, IsActive       |
    | CreatedDate, ModifiedDate                   |