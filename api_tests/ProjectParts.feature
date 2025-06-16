Feature: Project Parts Retrieval

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve parts for a project
    When I send a GET request to /api/projects/<entityNo>/parts
    Then the API response should be <StatusCode>
    And the response should contain a list of parts
Examples:
    | entityNo | StatusCode |
    | PROJ123  | 200        |
    | PROJ999  | 404        |

Scenario Outline: Retrieve parts with invalid entity number
    When I send a GET request to /api/projects/<entityNo>/parts
    Then the API response should be <StatusCode>
Examples:
    | entityNo | StatusCode |
    | INVALID  | 400        |

Scenario Outline: Retrieve parts with special characters in entity number
    When I send a GET request to /api/projects/<entityNo>/parts
    Then the API response should be <StatusCode>
Examples:
    | entityNo | StatusCode |
    | PROJ@123 | 400        |

Scenario Outline: Retrieve parts with empty entity number
    When I send a GET request to /api/projects/<entityNo>/parts
    Then the API response should be <StatusCode>
Examples:
    | entityNo | StatusCode |
    |          | 400        |