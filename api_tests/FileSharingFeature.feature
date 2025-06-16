Feature: File Sharing API

Background:
    Given I have access to the File Sharing API

Scenario Outline: Share folders with multiple members
    When I send a POST request to /api/FileSharing/share-all with the following share request details:
        | Email             | EntityNo | CloudFolderTemplate | AttachmentCategory | UserFolderPath          | Note                      |
        | <Email>           | <EntityNo> | <CloudFolderTemplate> | <AttachmentCategory> | <UserFolderPath> | <Note> |
    Then the API response should be: <StatusCode>
Examples:
    | Email             | EntityNo | CloudFolderTemplate | AttachmentCategory | UserFolderPath          | Note                      | StatusCode |
    | user1@example.com | 12345    | TemplateA          | Category1          | /path/to/user1/folder   | Sharing folder with user1 | 200        |
    | user2@example.com | 67890    | TemplateB          | Category2          | /path/to/user2/folder   | Sharing folder with user2 | 200        |
    | ""               | 12345    | TemplateA          | Category1          | /path/to/user1/folder   | Sharing folder with user1 | 400        |
    | user3@example.com | ""     | TemplateC          | Category3          | /path/to/user3/folder   | Sharing folder with user3 | 400        |
    | user4@example.com | 54321    | ""               | Category4          | /path/to/user4/folder   | Sharing folder with user4 | 400        |
    | user5@example.com | 98765    | TemplateD          | ""               | /path/to/user5/folder   | Sharing folder with user5 | 400        |
    | user6@example.com | 11223    | TemplateE          | Category5          | ""                    | Sharing folder with user6 | 400        |
    | user7@example.com | 33445    | TemplateF          | Category6          | /path/to/user7/folder   | ""                       | 200        |