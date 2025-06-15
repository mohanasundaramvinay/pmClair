Feature: Project Search

Background:
    Given I have access to the Project API

Scenario Outline: Search for projects with a valid search term
    When I send a GET request to /api/Project/search/<searchTerm>
    Then the API response should contain a list of projects
    And the response status code should be 200
Examples:
    | searchTerm |
    | modernize  |
    | alpha      |

Scenario Outline: Search for projects with an empty search term
    When I send a GET request to /api/Project/search/<searchTerm>
    Then the API response should be an empty list
    And the response status code should be 200
Examples:
    | searchTerm |
    |            |

Scenario Outline: Search for projects with a non-existent search term
    When I send a GET request to /api/Project/search/<searchTerm>
    Then the API response should be an empty list
    And the response status code should be 200
Examples:
    | searchTerm |
    | nonexistent |

Scenario Outline: Search for projects with a search term that causes an error
    When I send a GET request to /api/Project/search/<searchTerm>
    Then the API response should contain an error message
    And the response status code should be 400
Examples:
    | searchTerm |
    | error      |