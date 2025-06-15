Feature: Account Matrix Retrieval

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve account matrix with valid parameters
    When I send a GET request to /api/ProjectDataPoints/account-matrix
    Then the API response should be <StatusCode>
    And the response should contain a list of account matrix entries
    Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Retrieve account matrix with invalid endpoint
    When I send a GET request to /api/ProjectDataPoints/invalid-endpoint
    Then the API response should be <StatusCode>
    Examples:
    | StatusCode |
    | 404        |

Scenario Outline: Retrieve account matrix with server error
    When I simulate a server error for GET request to /api/ProjectDataPoints/account-matrix
    Then the API response should be <StatusCode>
    Examples:
    | StatusCode |
    | 500        |