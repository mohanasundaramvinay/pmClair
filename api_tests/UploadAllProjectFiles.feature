Feature: Upload All Project Files

Background:
    Given the FileSharing API is running

Scenario Outline: Upload all project files with valid data
    When I send a POST request to /api/FileSharing/upload-all-project-files with the following details:
        | SelectedFolderPath       | Template         | AttachmentCategory | CurrentGlobalOpsFolder | CurrentEntityNo | CurrentPartNo | SelectedFolderAttachmentType |
        | <SelectedFolderPath>     | <Template>       | <AttachmentCategory> | <CurrentGlobalOpsFolder> | <CurrentEntityNo> | <CurrentPartNo> | <SelectedFolderAttachmentType> |
    Then the API response should be:
        | Success | Message                                    | FoldersProcessed | FilesProcessed |
        | <Success> | <Message>                                | <FoldersProcessed> | <FilesProcessed> |

Examples:
    | SelectedFolderPath       | Template         | AttachmentCategory | CurrentGlobalOpsFolder | CurrentEntityNo | CurrentPartNo | SelectedFolderAttachmentType | Success | Message                                    | FoldersProcessed | FilesProcessed |
    | /path/to/selected/folder | ProjectTemplate1 | CategoryA          | /global/operations/folder | Entity123      | Part456      | TypeX                       | true    | All project files uploaded successfully    | 1                | 1             |
    | /invalid/path            | ProjectTemplate1 | CategoryA          | /global/operations/folder | Entity123      | Part456      | TypeX                       | false   | Failed to upload all project files. Please check the logs for more details. | 0                | 0             |

Scenario Outline: Upload all project files with missing fields
    When I send a POST request to /api/FileSharing/upload-all-project-files with the following details:
        | SelectedFolderPath       | Template         | AttachmentCategory | CurrentGlobalOpsFolder | CurrentEntityNo | CurrentPartNo | SelectedFolderAttachmentType |
        | <SelectedFolderPath>     | <Template>       | <AttachmentCategory> | <CurrentGlobalOpsFolder> | <CurrentEntityNo> | <CurrentPartNo> | <SelectedFolderAttachmentType> |
    Then the API response should be:
        | Success | Message                                    | FoldersProcessed | FilesProcessed |
        | <Success> | <Message>                                | <FoldersProcessed> | <FilesProcessed> |

Examples:
    | SelectedFolderPath | Template         | AttachmentCategory | CurrentGlobalOpsFolder | CurrentEntityNo | CurrentPartNo | SelectedFolderAttachmentType | Success | Message                                    | FoldersProcessed | FilesProcessed |
    |                    | ProjectTemplate1 | CategoryA          | /global/operations/folder | Entity123      | Part456      | TypeX                       | false   | Selected folder path is required           | 0                | 0             |
    | /path/to/folder    |                  | CategoryA          | /global/operations/folder | Entity123      | Part456      | TypeX                       | false   | Template is required                       | 0                | 0             |
    | /path/to/folder    | ProjectTemplate1 |                    | /global/operations/folder | Entity123      | Part456      | TypeX                       | false   | Attachment category is required            | 0                | 0             |