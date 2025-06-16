Feature: File Explorer Cloud File Uploads

Background:
    Given I have access to the File Explorer API

Scenario Outline: Retrieve cloud file uploads for a valid project
    When I send a GET request to /api/FileExplorer/cloudFileUploads with attachmentCategory "<AttachmentCategory>", entityNo "<EntityNo>", and partNo "<PartNo>"
    Then the API response should be "<StatusCode>"
Examples:
    | AttachmentCategory | EntityNo | PartNo | StatusCode |
    | Projects           | 12345    |        | 200        |
    | Projects           |          |        | 400        |

Scenario Outline: Retrieve cloud file uploads for a valid part
    When I send a GET request to /api/FileExplorer/cloudFileUploads with attachmentCategory "<AttachmentCategory>", entityNo "<EntityNo>", and partNo "<PartNo>"
    Then the API response should be "<StatusCode>"
Examples:
    | AttachmentCategory | EntityNo | PartNo | StatusCode |
    | Parts              |          | 67890  | 200        |
    | Parts              |          |        | 400        |

Scenario Outline: Retrieve cloud file uploads with invalid attachment category
    When I send a GET request to /api/FileExplorer/cloudFileUploads with attachmentCategory "<AttachmentCategory>", entityNo "<EntityNo>", and partNo "<PartNo>"
    Then the API response should be "<StatusCode>"
Examples:
    | AttachmentCategory | EntityNo | PartNo | StatusCode |
    | InvalidCategory    | 12345    |        | 400        |

Scenario Outline: Retrieve cloud file uploads with missing parameters
    When I send a GET request to /api/FileExplorer/cloudFileUploads with attachmentCategory "<AttachmentCategory>", entityNo "<EntityNo>", and partNo "<PartNo>"
    Then the API response should be "<StatusCode>"
Examples:
    | AttachmentCategory | EntityNo | PartNo | StatusCode |
    | Projects           |          |        | 400        |
    | Parts              |          |        | 400        |