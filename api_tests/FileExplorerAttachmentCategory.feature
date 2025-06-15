Feature: File Explorer Attachment Category

Background:
    Given the File Explorer API is running

Scenario Outline: Retrieve attachment category details
    When I send a GET request to /api/FileExplorer/attachmentCategory/<AttachmentCategory>
    Then the API response status should be <StatusCode>
    And the response should contain the attachment category details
Examples:
    | AttachmentCategory | StatusCode |
    | ValidCategory      | 200        |
    | InvalidCategory    | 404        |
    |                    | 400        |

Scenario Outline: Retrieve attachment category with special characters
    When I send a GET request to /api/FileExplorer/attachmentCategory/<AttachmentCategory>
    Then the API response status should be <StatusCode>
Examples:
    | AttachmentCategory | StatusCode |
    | Special!@#         | 400        |
    | %20Space           | 400        |

Scenario Outline: Retrieve attachment category with long string
    When I send a GET request to /api/FileExplorer/attachmentCategory/<AttachmentCategory>
    Then the API response status should be <StatusCode>
Examples:
    | AttachmentCategory | StatusCode |
    | LongCategoryNameExceedingLimit | 400 |