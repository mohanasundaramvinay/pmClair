Feature: Retrieve Customers

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve all customers
    When I send a GET request to /api/ProjectDataPoints/customers
    Then the API response should be <StatusCode>
    And the response should contain a list of customers

Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Retrieve customers with invalid endpoint
    When I send a GET request to /api/ProjectDataPoints/invalid-customers
    Then the API response should be <StatusCode>

Examples:
    | StatusCode |
    | 404        |

Scenario Outline: Retrieve customers with server error
    When I simulate a server error for GET /api/ProjectDataPoints/customers
    Then the API response should be <StatusCode>

Examples:
    | StatusCode |
    | 500        |