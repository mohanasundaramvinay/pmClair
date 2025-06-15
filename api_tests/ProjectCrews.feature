Feature: Project Crews Retrieval

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve crews for a valid project
    When I send a GET request to /api/projects/<entityNo>/crews
    Then the API response should be 200
    And the response should contain a list of crews
Examples:
    | entityNo |
    | 12345    |
    | 67890    |

Scenario Outline: Retrieve crews for a non-existent project
    When I send a GET request to /api/projects/<entityNo>/crews
    Then the API response should be 404
Examples:
    | entityNo |
    | 00000    |
    | 99999    |

Scenario Outline: Retrieve crews with invalid entity number format
    When I send a GET request to /api/projects/<entityNo>/crews
    Then the API response should be 400
Examples:
    | entityNo |
    | abcde    |
    | !@#$%    |

Scenario Outline: Retrieve crews with missing entity number
    When I send a GET request to /api/projects//crews
    Then the API response should be 404

Scenario Outline: Retrieve crews with special characters in entity number
    When I send a GET request to /api/projects/<entityNo>/crews
    Then the API response should be 400
Examples:
    | entityNo |
    | 123@45   |
    | 678*90   |