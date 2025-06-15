Feature: File Indexing

Background:
    Given I have access to the FileSharing API

Scenario Outline: Index a file successfully
    When I send a POST request to /api/FileSharing/index-file with filePath "<filePath>", guid "<guid>", and subFolderPath "<subFolderPath>"
    Then the API response should be a success message "<message>"
Examples:
    | filePath                  | guid                                   | subFolderPath         | message                  |
    | /path/to/file/document1.txt | 123e4567-e89b-12d3-a456-426614174000 | /path/to/subfolder1   | File indexed successfully |
    | /path/to/file/document2.txt | 123e4567-e89b-12d3-a456-426614174001 | /path/to/subfolder2   | File indexed successfully |

Scenario Outline: Fail to index a file due to missing filePath
    When I send a POST request to /api/FileSharing/index-file with filePath "<filePath>", guid "<guid>", and subFolderPath "<subFolderPath>"
    Then the API response should be an error message "<error>"
Examples:
    | filePath | guid                                   | subFolderPath       | error                                      |
    |          | 123e4567-e89b-12d3-a456-426614174000 | /path/to/subfolder1 | An error occurred while indexing the file: filePath is required |

Scenario Outline: Fail to index a file due to invalid guid
    When I send a POST request to /api/FileSharing/index-file with filePath "<filePath>", guid "<guid>", and subFolderPath "<subFolderPath>"
    Then the API response should be an error message "<error>"
Examples:
    | filePath                  | guid | subFolderPath       | error                                      |
    | /path/to/file/document.txt | invalid-guid | /path/to/subfolder | An error occurred while indexing the file: Invalid GUID format |