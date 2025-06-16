Feature: Create Folder In Selected Location

Background:
    Given I have access to the FileSharing API

Scenario Outline: Create a new folder in a selected location
    When I send a POST request to /api/FileSharing/create-folder-in-selected with the following details: "<NewFolderName>", "<CurrentGlobalOpsFolder>", "<AttachmentCategory>", "<EntityNo>", "<SelectedNodePath>", "<DropboxEnabled>", "<IsLoadingTree>"
    Then the API response should be: "<Success>", "<Message>", "<FolderPath>"
Examples:
    | NewFolderName     | CurrentGlobalOpsFolder       | AttachmentCategory | EntityNo | SelectedNodePath                        | DropboxEnabled | IsLoadingTree | Success | Message                                                   | FolderPath                                      |
    | NewProjectFolder  | /global/operations/folder    | ProjectDocuments   | 12345   | /global/operations/folder/selectedNode  | true           | false         | true    | Folder created successfully in selected location          | /global/operations/folder/NewProjectFolder      |
    |                  | /global/operations/folder    | ProjectDocuments   | 12345   | /global/operations/folder/selectedNode  | true           | false         | false   | Folder name is required                                   | null                                            |
    | NewProjectFolder  |                              | ProjectDocuments   | 12345   | /global/operations/folder/selectedNode  | true           | false         | false   | Current global operations folder path is required         | null                                            |
    | NewProjectFolder  | /global/operations/folder    |                    | 12345   | /global/operations/folder/selectedNode  | true           | false         | false   | Attachment category is required                           | null                                            |
    | NewProjectFolder  | /global/operations/folder    | ProjectDocuments   |        | /global/operations/folder/selectedNode  | true           | false         | false   | Entity number is required                                 | null                                            |
    | NewProjectFolder  | /global/operations/folder    | ProjectDocuments   | 12345   | /global/operations/folder/selectedNode  | true           | true          | false   | Failed to create folder in selected location. Please check the logs for more details. | null                                            |