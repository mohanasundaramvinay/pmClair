Feature: File Explorer Contact Category Cloud Mappings

Background:
    Given I have access to the File Explorer API

Scenario: Retrieve contact category cloud mappings successfully
    When I send a GET request to /api/FileExplorer/contactCategoryCloudMappings
    Then the API response should be 200
    And the response should contain a list of contact category cloud mappings

Scenario: Handle server error when retrieving contact category cloud mappings
    When I send a GET request to /api/FileExplorer/contactCategoryCloudMappings
    Then the API response should be 500
    And the response should contain an error message

Scenario: Validate response structure for contact category cloud mappings
    When I send a GET request to /api/FileExplorer/contactCategoryCloudMappings
    Then the API response should be 200
    And each mapping should have a valid identifier
    And each mapping should have a valid name

Scenario Outline: Test with different server states
    Given the server is in "<ServerState>" state
    When I send a GET request to /api/FileExplorer/contactCategoryCloudMappings
    Then the API response should be "<StatusCode>"
Examples:
    | ServerState | StatusCode |
    | normal      | 200        |
    | overloaded  | 500        |
    | maintenance | 503        |