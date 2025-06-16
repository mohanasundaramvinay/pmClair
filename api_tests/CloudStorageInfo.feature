Feature: Cloud Storage Info Retrieval

Background:
    Given the File Explorer API is running

Scenario Outline: Retrieve cloud storage information
    When I send a GET request to /api/FileExplorer/cloudStorageInfo
    Then the API response should have status code <StatusCode>
    And the response should contain the provider name <ProviderName>
    And the response should indicate authentication status as <IsAuthenticated>
    And the response should show available space as <AvailableSpace>
    And the response should show used space as <UsedSpace>
    And the response metadata should have creation date <CreationDate>
    And the response metadata should have last modified date <LastModifiedDate>

Examples:
    | StatusCode | ProviderName | IsAuthenticated | AvailableSpace | UsedSpace | CreationDate          | LastModifiedDate       |
    | 200        | Dropbox      | true            | 1000000000     | 500000000 | 2023-01-01T12:00:00Z  | 2023-10-01T12:00:00Z   |
    | 500        |              |                 |                |           |                       |                        |