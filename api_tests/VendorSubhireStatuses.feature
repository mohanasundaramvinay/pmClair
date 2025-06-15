Feature: Vendor Subhire Statuses Retrieval

Background:
    Given the Vendor API is running

Scenario Outline: Retrieve subhire statuses
    When I send a GET request to /api/vendor/subhire-statuses
    Then the API response should be <StatusCode>
    And the response should contain a list of subhire statuses

Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving subhire statuses
    Given the Vendor API is running with a simulated server error
    When I send a GET request to /api/vendor/subhire-statuses
    Then the API response should be <StatusCode>

Examples:
    | StatusCode |
    | 500        |