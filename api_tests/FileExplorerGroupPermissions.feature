Feature: File Explorer Group Permissions

Background:
    Given I have access to the File Explorer API

Scenario Outline: Retrieve group permissions for a valid attachment category
    When I send a GET request to /api/FileExplorer/groupPermissions/<AttachmentCategory>
    Then the API response should be 200
    And the response should contain a list of group permissions
Examples:
    | AttachmentCategory |
    | Documents          |
    | Images             |
    | Videos             |

Scenario Outline: Retrieve group permissions for an invalid attachment category
    When I send a GET request to /api/FileExplorer/groupPermissions/<AttachmentCategory>
    Then the API response should be 404
Examples:
    | AttachmentCategory |
    | NonExistent        |
    | UnknownCategory    |

Scenario Outline: Retrieve group permissions with special characters in category
    When I send a GET request to /api/FileExplorer/groupPermissions/<AttachmentCategory>
    Then the API response should be 404
Examples:
    | AttachmentCategory |
    | @@@@               |
    | $$$$               |

Scenario Outline: Retrieve group permissions with empty category
    When I send a GET request to /api/FileExplorer/groupPermissions/<AttachmentCategory>
    Then the API response should be 404
Examples:
    | AttachmentCategory |
    |                    |