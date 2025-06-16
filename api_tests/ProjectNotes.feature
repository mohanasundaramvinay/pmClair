Feature: Project Notes Retrieval

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve notes for a project
    When I send a GET request to /api/projects/<entityNo>/notes
    Then the API response should be <StatusCode>
    And the response should contain a list of notes
Examples:
    | entityNo | StatusCode |
    | 101      | 200        |
    | 999      | 404        |

Scenario Outline: Retrieve notes with invalid project ID
    When I send a GET request to /api/projects/<entityNo>/notes
    Then the API response should be <StatusCode>
Examples:
    | entityNo | StatusCode |
    | abc      | 400        |
    | ''       | 400        |

Scenario Outline: Retrieve notes for a project with no notes
    When I send a GET request to /api/projects/<entityNo>/notes
    Then the API response should be <StatusCode>
    And the response should be an empty list
Examples:
    | entityNo | StatusCode |
    | 102      | 200        |