Feature: Project Client Addresses Retrieval

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve client addresses for a project
    When I send a GET request to /api/projects/<entityNo>/client-addresses
    Then the API response should be <StatusCode>
    And the response should contain a list of client addresses
Examples:
    | entityNo | StatusCode |
    | 12345    | 200        |
    | 67890    | 200        |
    | 00000    | 404        |

Scenario Outline: Retrieve client addresses with invalid entity number
    When I send a GET request to /api/projects/<entityNo>/client-addresses
    Then the API response should be <StatusCode>
Examples:
    | entityNo | StatusCode |
    | abcde    | 400        |
    | !@#$%    | 400        |

Scenario Outline: Retrieve client addresses for a project with no addresses
    When I send a GET request to /api/projects/<entityNo>/client-addresses
    Then the API response should be <StatusCode>
    And the response should be an empty list
Examples:
    | entityNo | StatusCode |
    | 54321    | 200        |