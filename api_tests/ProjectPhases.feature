Feature: Project Phases Retrieval

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve phases for a valid project
    When I send a GET request to /api/projects/<entityNo>/phases
    Then the API response should be 200
    And the response should contain a list of phases
Examples:
    | entityNo |
    | 12345    |
    | 67890    |

Scenario Outline: Retrieve phases for a non-existent project
    When I send a GET request to /api/projects/<entityNo>/phases
    Then the API response should be 404
Examples:
    | entityNo |
    | 00000    |
    | 99999    |

Scenario Outline: Retrieve phases with invalid project identifier
    When I send a GET request to /api/projects/<entityNo>/phases
    Then the API response should be 400
Examples:
    | entityNo |
    | abcde    |
    | !@#$%    |

Scenario Outline: Retrieve phases with missing project identifier
    When I send a GET request to /api/projects//phases
    Then the API response should be 404

Scenario Outline: Retrieve phases with special characters in project identifier
    When I send a GET request to /api/projects/<entityNo>/phases
    Then the API response should be 400
Examples:
    | entityNo |
    | <script> |
    | %20%20   |