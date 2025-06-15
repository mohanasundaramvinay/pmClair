Feature: Create Folder API

Background:
    Given the FileSharing API is running

Scenario Outline: Create a new folder with valid details
    When I send a POST request to /api/FileSharing/create-folder with the following details: "<NewFolderName>", "<AttachmentCategorySubFolderPath>", "<AttachmentCategory>", "<EntityNo>", "<DropboxEnabled>"
    Then the API response should be success with message "Folder created successfully" and folder path "<ExpectedFolderPath>"
Examples:
    | NewFolderName     | AttachmentCategorySubFolderPath | AttachmentCategory | EntityNo | DropboxEnabled | ExpectedFolderPath                  |
    | NewProjectFolder | /base/path/to/folder            | ProjectDocuments  | 12345   | true           | /base/path/to/folder/NewProjectFolder |

Scenario Outline: Create a folder with missing folder name
    When I send a POST request to /api/FileSharing/create-folder with the following details: "<NewFolderName>", "<AttachmentCategorySubFolderPath>", "<AttachmentCategory>", "<EntityNo>", "<DropboxEnabled>"
    Then the API response should be failure with message "Folder name is required"
Examples:
    | NewFolderName | AttachmentCategorySubFolderPath | AttachmentCategory | EntityNo | DropboxEnabled |
    | ""           | /base/path/to/folder            | ProjectDocuments  | 12345   | true           |

Scenario Outline: Create a folder with missing attachment category
    When I send a POST request to /api/FileSharing/create-folder with the following details: "<NewFolderName>", "<AttachmentCategorySubFolderPath>", "<AttachmentCategory>", "<EntityNo>", "<DropboxEnabled>"
    Then the API response should be failure with message "Attachment category is required"
Examples:
    | NewFolderName     | AttachmentCategorySubFolderPath | AttachmentCategory | EntityNo | DropboxEnabled |
    | NewProjectFolder | /base/path/to/folder            | ""               | 12345   | true           |

Scenario Outline: Create a folder with missing entity number
    When I send a POST request to /api/FileSharing/create-folder with the following details: "<NewFolderName>", "<AttachmentCategorySubFolderPath>", "<AttachmentCategory>", "<EntityNo>", "<DropboxEnabled>"
    Then the API response should be failure with message "Entity number is required"
Examples:
    | NewFolderName     | AttachmentCategorySubFolderPath | AttachmentCategory | EntityNo | DropboxEnabled |
    | NewProjectFolder | /base/path/to/folder            | ProjectDocuments  | ""     | true           |

Scenario Outline: Create a folder with Dropbox disabled
    When I send a POST request to /api/FileSharing/create-folder with the following details: "<NewFolderName>", "<AttachmentCategorySubFolderPath>", "<AttachmentCategory>", "<EntityNo>", "<DropboxEnabled>"
    Then the API response should be success with message "Folder created successfully" and folder path "<ExpectedFolderPath>"
Examples:
    | NewFolderName     | AttachmentCategorySubFolderPath | AttachmentCategory | EntityNo | DropboxEnabled | ExpectedFolderPath                  |
    | NewProjectFolder | /base/path/to/folder            | ProjectDocuments  | 12345   | false          | /base/path/to/folder/NewProjectFolder |