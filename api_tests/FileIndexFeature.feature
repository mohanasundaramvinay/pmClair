Feature: File Index Retrieval

Background:
    Given I have access to the File Explorer API

Scenario Outline: Retrieve file index details for a valid GUID
    When I send a GET request to /api/FileExplorer/fileIndex/<Guid>
    Then the API response should be 200
    And the response should contain a list of file index details
Examples:
    | Guid                                   |
    | 123e4567-e89b-12d3-a456-426614174000   |
    | 123e4567-e89b-12d3-a456-426614174001   |

Scenario Outline: Retrieve file index details for an invalid GUID
    When I send a GET request to /api/FileExplorer/fileIndex/<Guid>
    Then the API response should be 404
Examples:
    | Guid                                   |
    | 00000000-0000-0000-0000-000000000000   |
    | ffffffff-ffff-ffff-ffff-ffffffffffff   |

Scenario Outline: Retrieve file index details with server error
    When I send a GET request to /api/FileExplorer/fileIndex/<Guid>
    Then the API response should be 500
Examples:
    | Guid                                   |
    | 123e4567-e89b-12d3-a456-426614174002   |

Scenario Outline: Retrieve file index details with malformed GUID
    When I send a GET request to /api/FileExplorer/fileIndex/<Guid>
    Then the API response should be 400
Examples:
    | Guid         |
    | invalid-guid |
    | 1234         |