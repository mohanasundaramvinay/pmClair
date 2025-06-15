Feature: Project Billing Periods Retrieval

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve billing periods for a project
    When I send a GET request to /api/projects/<entityNo>/billing-periods
    Then the API response should be <StatusCode>
    And the response should contain a list of billing periods
Examples:
    | entityNo | StatusCode |
    | PROJ123  | 200        |
    | PROJ999  | 404        |

Scenario Outline: Retrieve billing periods with invalid project number
    When I send a GET request to /api/projects/<entityNo>/billing-periods
    Then the API response should be <StatusCode>
Examples:
    | entityNo | StatusCode |
    | INVALID  | 400        |
    |          | 400        |

Scenario Outline: Retrieve billing periods with special characters in project number
    When I send a GET request to /api/projects/<entityNo>/billing-periods
    Then the API response should be <StatusCode>
Examples:
    | entityNo | StatusCode |
    | PROJ@123 | 400        |
    | PROJ#123 | 400        |