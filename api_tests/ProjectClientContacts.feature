Feature: Project Client Contacts Retrieval

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve client contacts for a project
    When I send a GET request to /api/projects/<entityNo>/client-contacts
    Then the API response should be <StatusCode>
    And the response should contain a list of client contacts
Examples:
    | entityNo | StatusCode |
    | PROJ123  | 200        |
    | PROJ999  | 404        |

Scenario Outline: Retrieve client contacts with invalid project ID
    When I send a GET request to /api/projects/<entityNo>/client-contacts
    Then the API response should be <StatusCode>
Examples:
    | entityNo | StatusCode |
    | INVALID  | 400        |
    |          | 400        |

Scenario Outline: Retrieve client contacts for a project with no contacts
    When I send a GET request to /api/projects/<entityNo>/client-contacts
    Then the API response should be <StatusCode>
    And the response should be an empty list
Examples:
    | entityNo | StatusCode |
    | PROJ456  | 200        |