Feature: Project Client Shipping Addresses Retrieval

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve client shipping addresses for a project
    When I send a GET request to /api/projects/<entityNo>/client-shipping-addresses
    Then the API response should be <StatusCode>
    And the response should contain a list of client shipping addresses
Examples:
    | entityNo | StatusCode |
    | PROJ123  | 200        |
    | PROJ999  | 404        |
    | PROJ456  | 200        |
    | PROJ000  | 404        |

Scenario Outline: Retrieve client shipping addresses with invalid entity number
    When I send a GET request to /api/projects/<entityNo>/client-shipping-addresses
    Then the API response should be <StatusCode>
Examples:
    | entityNo | StatusCode |
    | INVALID  | 400        |
    | 123      | 400        |
    | ''       | 400        |

Scenario Outline: Retrieve client shipping addresses with special characters in entity number
    When I send a GET request to /api/projects/<entityNo>/client-shipping-addresses
    Then the API response should be <StatusCode>
Examples:
    | entityNo | StatusCode |
    | PROJ@123 | 400        |
    | PROJ#456 | 400        |
    | PROJ$789 | 400        |