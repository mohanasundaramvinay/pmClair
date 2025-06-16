Feature: Pollstar Artists Search

Background:
    Given I have access to the Pollstar artists API

Scenario Outline: Search for Pollstar artists by name
    When I send a GET request to /api/ProjectDataPoints/pollstar-artists/search with searchTerm "<SearchTerm>"
    Then the API response should be <StatusCode>
    And the response should contain <ExpectedCount> artists
Examples:
    | SearchTerm | StatusCode | ExpectedCount |
    | ""        | 400        | 0             |
    | "Unknown"| 200        | 0             |
    | "The"    | 200        | 2             |
    | "Beyoncé"| 200        | 1             |

Scenario Outline: Search for Pollstar artists with special characters
    When I send a GET request to /api/ProjectDataPoints/pollstar-artists/search with searchTerm "<SearchTerm>"
    Then the API response should be <StatusCode>
    And the response should contain <ExpectedCount> artists
Examples:
    | SearchTerm | StatusCode | ExpectedCount |
    | "Beyoncé"| 200        | 1             |
    | "@rtist" | 200        | 0             |
    | "#1"     | 200        | 0             |

Scenario Outline: Search for Pollstar artists with numeric values
    When I send a GET request to /api/ProjectDataPoints/pollstar-artists/search with searchTerm "<SearchTerm>"
    Then the API response should be <StatusCode>
    And the response should contain <ExpectedCount> artists
Examples:
    | SearchTerm | StatusCode | ExpectedCount |
    | "123"    | 200        | 0             |
    | "2024"   | 200        | 0             |