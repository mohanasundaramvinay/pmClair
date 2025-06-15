Feature: File Explorer User Folders

Background:
    Given I have access to the File Explorer API

Scenario Outline: Retrieve user folders for a valid entity number
    When I send a GET request to /api/FileExplorer/userFolders/<entityNo>
    Then the API response should be 200
    And the response should contain a list of user folders
Examples:
    | entityNo |
    | 12345    |
    | 67890    |

Scenario Outline: Retrieve user folders with an invalid entity number
    When I send a GET request to /api/FileExplorer/userFolders/<entityNo>
    Then the API response should be 400
Examples:
    | entityNo |
    |          |
    | abcde    |

Scenario Outline: Retrieve user folders for a non-existent entity number
    When I send a GET request to /api/FileExplorer/userFolders/<entityNo>
    Then the API response should be 404
Examples:
    | entityNo |
    | 99999    |

Scenario Outline: Retrieve user folders with special characters in entity number
    When I send a GET request to /api/FileExplorer/userFolders/<entityNo>
    Then the API response should be 400
Examples:
    | entityNo |
    | !@#$%    |

Scenario Outline: Retrieve user folders with a very long entity number
    When I send a GET request to /api/FileExplorer/userFolders/<entityNo>
    Then the API response should be 400
Examples:
    | entityNo |
    | 123456789012345678901234567890 |