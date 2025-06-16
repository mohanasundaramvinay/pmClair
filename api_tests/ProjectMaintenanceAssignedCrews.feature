Feature: Project Maintenance - Assigned Crews

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve assigned crews for a project
    When I send a GET request to /api/projects/<entityNo>/assigned-crews
    Then the API response should be <StatusCode>
    And the response should contain a list of assigned crews
Examples:
    | entityNo | StatusCode |
    | 12345    | 200        |
    | 67890    | 200        |
    | 00000    | 404        |

Scenario Outline: Retrieve assigned crews with invalid entity number
    When I send a GET request to /api/projects/<entityNo>/assigned-crews
    Then the API response should be <StatusCode>
Examples:
    | entityNo | StatusCode |
    | abcde    | 400        |
    | !@#$%    | 400        |

Scenario Outline: Retrieve assigned crews for a project with no crews
    When I send a GET request to /api/projects/<entityNo>/assigned-crews
    Then the API response should be <StatusCode>
    And the response should be an empty list
Examples:
    | entityNo | StatusCode |
    | 54321    | 200        |

Scenario Outline: Retrieve assigned crews for a non-existent project
    When I send a GET request to /api/projects/<entityNo>/assigned-crews
    Then the API response should be <StatusCode>
Examples:
    | entityNo | StatusCode |
    | 99999    | 404        |