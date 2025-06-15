Feature: Project Equipments Retrieval

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve equipments for a valid project
    When I send a GET request to /api/projects/<entityNo>/equipments
    Then the API response should be 200
    And the response should contain a list of equipments
Examples:
    | entityNo  |
    | PROJ123   |
    | PROJ456   |

Scenario Outline: Retrieve equipments for an invalid project
    When I send a GET request to /api/projects/<entityNo>/equipments
    Then the API response should be 404
Examples:
    | entityNo  |
    | INVALID01 |
    | INVALID02 |

Scenario Outline: Retrieve equipments with special characters in project ID
    When I send a GET request to /api/projects/<entityNo>/equipments
    Then the API response should be 400
Examples:
    | entityNo  |
    | PROJ@123  |
    | PROJ#456  |

Scenario Outline: Retrieve equipments with empty project ID
    When I send a GET request to /api/projects/<entityNo>/equipments
    Then the API response should be 400
Examples:
    | entityNo |
    | ""      |

Scenario Outline: Retrieve equipments with excessively long project ID
    When I send a GET request to /api/projects/<entityNo>/equipments
    Then the API response should be 400
Examples:
    | entityNo |
    | PROJ1234567890123456789012345678901234567890 |