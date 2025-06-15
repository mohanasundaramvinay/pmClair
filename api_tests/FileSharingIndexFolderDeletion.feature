Feature: File Sharing Index Folder Deletion

Background:
    Given I have access to the File Sharing API

Scenario Outline: Delete folder from index with valid GUID and subFolderPath
    When I send a DELETE request to /api/FileSharing/index-folder with GUID "<Guid>" and subFolderPath "<SubFolderPath>"
    Then the API response should be: "<StatusCode>"
Examples:
    | Guid                                 | SubFolderPath               | StatusCode |
    | 123e4567-e89b-12d3-a456-426614174000 | projects/2023/important-docs | 200        |
    | 123e4567-e89b-12d3-a456-426614174001 | projects/2023/other-docs    | 200        |

Scenario Outline: Delete folder from index with invalid GUID
    When I send a DELETE request to /api/FileSharing/index-folder with GUID "<Guid>" and subFolderPath "<SubFolderPath>"
    Then the API response should be: "<StatusCode>"
Examples:
    | Guid                                 | SubFolderPath               | StatusCode |
    | invalid-guid                         | projects/2023/important-docs | 400        |

Scenario Outline: Delete folder from index with missing subFolderPath
    When I send a DELETE request to /api/FileSharing/index-folder with GUID "<Guid>" and subFolderPath "<SubFolderPath>"
    Then the API response should be: "<StatusCode>"
Examples:
    | Guid                                 | SubFolderPath | StatusCode |
    | 123e4567-e89b-12d3-a456-426614174000 |               | 400        |

Scenario Outline: Delete folder from index with missing GUID
    When I send a DELETE request to /api/FileSharing/index-folder with GUID "<Guid>" and subFolderPath "<SubFolderPath>"
    Then the API response should be: "<StatusCode>"
Examples:
    | Guid | SubFolderPath               | StatusCode |
    |      | projects/2023/important-docs | 400        |

Scenario Outline: Delete folder from index with non-existent folder
    When I send a DELETE request to /api/FileSharing/index-folder with GUID "<Guid>" and subFolderPath "<SubFolderPath>"
    Then the API response should be: "<StatusCode>"
Examples:
    | Guid                                 | SubFolderPath               | StatusCode |
    | 123e4567-e89b-12d3-a456-426614174000 | projects/2023/non-existent  | 200        |