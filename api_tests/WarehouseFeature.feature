Feature: Warehouse Data Retrieval

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve all warehouses
    When I send a GET request to /api/ProjectDataPoints/warehouses
    Then the API response should be a list of warehouses with status code <StatusCode>
Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Retrieve warehouses with invalid endpoint
    When I send a GET request to /api/ProjectDataPoints/invalid-warehouses
    Then the API response should be a 404 status code
Examples:
    | StatusCode |
    | 404        |

Scenario Outline: Retrieve warehouses with server error
    When I simulate a server error for GET request to /api/ProjectDataPoints/warehouses
    Then the API response should be a 500 status code
Examples:
    | StatusCode |
    | 500        |