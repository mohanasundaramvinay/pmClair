Feature: File Explorer Attachment Types

Background:
    Given the File Explorer API is running

Scenario Outline: Retrieve attachment types for a valid category
    When I send a GET request to /api/FileExplorer/attachmentTypes/<attachmentCategory>
    Then the API response should be 200 OK
    And the response should contain a list of attachment types
Examples:
    | attachmentCategory |
    | Documents          |
    | Images             |
    | Videos             |

Scenario Outline: Retrieve attachment types for an invalid category
    When I send a GET request to /api/FileExplorer/attachmentTypes/<attachmentCategory>
    Then the API response should be 404 Not Found
Examples:
    | attachmentCategory |
    | NonExistent        |
    | Unknown            |

Scenario Outline: Retrieve attachment types with special characters in category
    When I send a GET request to /api/FileExplorer/attachmentTypes/<attachmentCategory>
    Then the API response should be 400 Bad Request
Examples:
    | attachmentCategory |
    | @@@@               |
    | $$$$               |

Scenario Outline: Retrieve attachment types with empty category
    When I send a GET request to /api/FileExplorer/attachmentTypes/<attachmentCategory>
    Then the API response should be 400 Bad Request
Examples:
    | attachmentCategory |
    |                    |