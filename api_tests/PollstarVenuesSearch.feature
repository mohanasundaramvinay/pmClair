Feature: Pollstar Venues Search

Background:
    Given the Pollstar Venues API is running

Scenario Outline: Search for Pollstar venues with valid search term
    When I send a GET request to /api/ProjectDataPoints/pollstar-venues/search with searchTerm "<searchTerm>"
    Then the API response should be <StatusCode>
    And the response should contain venues matching the search term "<searchTerm>"
Examples:
    | searchTerm              | StatusCode |
    | Madison Square Garden   | 200        |
    | Sydney Opera House      | 200        |

Scenario Outline: Search for Pollstar venues with empty search term
    When I send a GET request to /api/ProjectDataPoints/pollstar-venues/search with searchTerm "<searchTerm>"
    Then the API response should be <StatusCode>
Examples:
    | searchTerm | StatusCode |
    | ""        | 400        |

Scenario Outline: Search for Pollstar venues with special characters
    When I send a GET request to /api/ProjectDataPoints/pollstar-venues/search with searchTerm "<searchTerm>"
    Then the API response should be <StatusCode>
Examples:
    | searchTerm | StatusCode |
    | @#$%^&*    | 200        |

Scenario Outline: Search for Pollstar venues with very long search term
    When I send a GET request to /api/ProjectDataPoints/pollstar-venues/search with searchTerm "<searchTerm>"
    Then the API response should be <StatusCode>
Examples:
    | searchTerm | StatusCode |
    | LoremipsumdolorsitametconsecteturadipiscingelitSeddoeiusmodtemporincididuntutlaboreetdoloremagnaaliqua | 200 |