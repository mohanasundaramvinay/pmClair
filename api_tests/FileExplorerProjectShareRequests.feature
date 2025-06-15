Feature: File Explorer Project Share Requests

Background:
    Given I have access to the File Explorer API

Scenario Outline: Retrieve project share requests for a valid entity
    When I send a GET request to /api/FileExplorer/projectShareRequests/<entityNo>
    Then the API response should be 200
    And the response should contain a list of project share requests

Examples:
    | entityNo |
    | 12345    |
    | 67890    |

Scenario Outline: Retrieve project share requests for an invalid entity
    When I send a GET request to /api/FileExplorer/projectShareRequests/<entityNo>
    Then the API response should be 400
    And the response should contain an error message

Examples:
    | entityNo |
    |          |
    | abcde    |

Scenario Outline: Retrieve project share requests for a non-existent entity
    When I send a GET request to /api/FileExplorer/projectShareRequests/<entityNo>
    Then the API response should be 404
    And the response should contain an error message

Examples:
    | entityNo |
    | 99999    |

Scenario Outline: Retrieve project share requests with server error
    When I send a GET request to /api/FileExplorer/projectShareRequests/<entityNo>
    Then the API response should be 500
    And the response should contain an error message

Examples:
    | entityNo |
    | 54321    |