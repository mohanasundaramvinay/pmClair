Feature: File Explorer Root Attachment Types

Background:
    Given the File Explorer API is running

Scenario: Retrieve root attachment types successfully
    When I send a GET request to /api/FileExplorer/rootAttachmentTypes
    Then the API response should be 200
    And the response should contain a list of root attachment types

Scenario: Handle server error when retrieving root attachment types
    When I send a GET request to /api/FileExplorer/rootAttachmentTypes
    Then the API response should be 500
    And the response should contain an error message

Scenario Outline: Validate response structure for root attachment types
    When I send a GET request to /api/FileExplorer/rootAttachmentTypes
    Then the API response should be 200
    And the response should contain a list of root attachment types with fields <Field1>, <Field2>, <Field3>
Examples:
    | Field1 | Field2 | Field3     |
    | id     | name   | description|