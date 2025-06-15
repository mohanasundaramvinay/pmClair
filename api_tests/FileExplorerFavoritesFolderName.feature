Feature: File Explorer Favorites Folder Name Retrieval

Background:
    Given the File Explorer API is running

Scenario: Retrieve the favorites folder name successfully
    When I send a GET request to /api/FileExplorer/favoritesFolderName
    Then the response status code should be 200
    And the response should contain the favorites folder name

Scenario: Handle server error when retrieving the favorites folder name
    When I send a GET request to /api/FileExplorer/favoritesFolderName
    Then the response status code should be 500
    And the response should contain an error message