Feature: Equipment Subhires Retrieval

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve equipment subhires for a valid project
    When I send a GET request to /api/projects/<entityNo>/equipment/subhires
    Then the API response should be 200 OK
    And the response should contain a list of equipment subhires
Examples:
    | entityNo  |
    | PROJ123   |
    | PROJ456   |

Scenario Outline: Retrieve equipment subhires for a non-existent project
    When I send a GET request to /api/projects/<entityNo>/equipment/subhires
    Then the API response should be 404 Not Found
Examples:
    | entityNo  |
    | INVALID   |
    | UNKNOWN   |

Scenario Outline: Retrieve equipment subhires with invalid entity number format
    When I send a GET request to /api/projects/<entityNo>/equipment/subhires
    Then the API response should be 400 Bad Request
Examples:
    | entityNo  |
    | 123       |
    | !@#$      |

Scenario Outline: Retrieve equipment subhires with missing entity number
    When I send a GET request to /api/projects//equipment/subhires
    Then the API response should be 404 Not Found

Scenario Outline: Retrieve equipment subhires with special characters in entity number
    When I send a GET request to /api/projects/<entityNo>/equipment/subhires
    Then the API response should be 400 Bad Request
Examples:
    | entityNo  |
    | PROJ@123  |
    | PROJ#456  |