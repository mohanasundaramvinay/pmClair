Feature: Project Folder GUID Retrieval

Background:
    Given I have access to the FileSharing API

Scenario Outline: Retrieve project folder GUID with valid entity number
    When I send a GET request to /api/FileSharing/project-folder-guid with entityNo "<EntityNo>"
    Then the API response should be 200 with GUID "<ExpectedGuid>" and message "<ExpectedMessage>"
Examples:
    | EntityNo | ExpectedGuid                          | ExpectedMessage            |
    | 12345   | 123e4567-e89b-12d3-a456-426614174000 | GUID retrieved successfully |

Scenario Outline: Retrieve project folder GUID with missing entity number
    When I send a GET request to /api/FileSharing/project-folder-guid without entityNo
    Then the API response should be 400 with message "Entity number is required"
Examples:
    | EntityNo |
    |          |

Scenario Outline: Retrieve project folder GUID with invalid entity number
    When I send a GET request to /api/FileSharing/project-folder-guid with entityNo "<EntityNo>"
    Then the API response should be 200 with GUID null and message "No GUID could be created for the given entity number"
Examples:
    | EntityNo |
    | invalid  |

Scenario Outline: Internal server error during GUID retrieval
    When I send a GET request to /api/FileSharing/project-folder-guid with entityNo "<EntityNo>"
    Then the API response should be 500 with message "An error occurred while getting or creating project folder GUID: <ErrorDetails>"
Examples:
    | EntityNo | ErrorDetails |
    | 99999    | Database error |