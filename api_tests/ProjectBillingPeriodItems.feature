Feature: Project Billing Period Items Retrieval

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve billing period items for a project
    When I send a GET request to /api/projects/<entityNo>/billing-period-items
    Then the API response should be <StatusCode>
    And the response should contain a list of billing period items
Examples:
    | entityNo | StatusCode |
    | 12345    | 200        |
    | 67890    | 200        |
    | 00000    | 404        |

Scenario Outline: Retrieve billing period items with invalid entity number
    When I send a GET request to /api/projects/<entityNo>/billing-period-items
    Then the API response should be <StatusCode>
Examples:
    | entityNo | StatusCode |
    | abcde    | 400        |
    | !@#$%    | 400        |

Scenario Outline: Retrieve billing period items for a project with no items
    When I send a GET request to /api/projects/<entityNo>/billing-period-items
    Then the API response should be <StatusCode>
    And the response should be an empty list
Examples:
    | entityNo | StatusCode |
    | 54321    | 200        |