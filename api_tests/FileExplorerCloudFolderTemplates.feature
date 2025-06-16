Feature: File Explorer Cloud Folder Templates

Background:
    Given the File Explorer API is running

Scenario Outline: Retrieve cloud folder templates
    When I send a GET request to /api/FileExplorer/cloudFolderTemplates
    Then the API response should be a list of cloud folder templates with status code <StatusCode>
Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving cloud folder templates
    When I send a GET request to /api/FileExplorer/cloudFolderTemplates
    Then the API response should be an error message with status code <StatusCode>
Examples:
    | StatusCode |
    | 500        |