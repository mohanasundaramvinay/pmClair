Feature: Project Production Schedules Retrieval

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve production schedules for a valid project
    When I send a GET request to /api/projects/<entityNo>/production-schedules
    Then the API response should be 200
    And the response should contain a list of production schedules
Examples:
    | entityNo |
    | 12345    |
    | 67890    |

Scenario Outline: Retrieve production schedules for a non-existent project
    When I send a GET request to /api/projects/<entityNo>/production-schedules
    Then the API response should be 404
Examples:
    | entityNo |
    | 00000    |
    | 99999    |

Scenario Outline: Retrieve production schedules with invalid entity number
    When I send a GET request to /api/projects/<entityNo>/production-schedules
    Then the API response should be 400
Examples:
    | entityNo |
    | abcde    |
    | !@#$%    |

Scenario Outline: Retrieve production schedules with missing entity number
    When I send a GET request to /api/projects//production-schedules
    Then the API response should be 400

Scenario Outline: Retrieve production schedules with special characters in entity number
    When I send a GET request to /api/projects/<entityNo>/production-schedules
    Then the API response should be 400
Examples:
    | entityNo |
    | 123@#    |
    | 456*()   |