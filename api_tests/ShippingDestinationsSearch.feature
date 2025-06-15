Feature: Shipping Destinations Search

Background:
    Given the API is running

Scenario Outline: Search for shipping destinations with valid search term
    When I send a GET request to /api/ProjectDataPoints/shipping-destinations/search with searchTerm "<searchTerm>"
    Then the API response should be 200
    And the response should contain destinations matching "<searchTerm>"
Examples:
    | searchTerm |
    | New York   |
    | Los Angeles|

Scenario Outline: Search for shipping destinations with empty search term
    When I send a GET request to /api/ProjectDataPoints/shipping-destinations/search with searchTerm "<searchTerm>"
    Then the API response should be 400
Examples:
    | searchTerm |
    | ""        |

Scenario Outline: Search for shipping destinations with special characters
    When I send a GET request to /api/ProjectDataPoints/shipping-destinations/search with searchTerm "<searchTerm>"
    Then the API response should be 200
    And the response should handle special characters
Examples:
    | searchTerm |
    | @#$%^&*()  |

Scenario Outline: Search for shipping destinations with non-existent location
    When I send a GET request to /api/ProjectDataPoints/shipping-destinations/search with searchTerm "<searchTerm>"
    Then the API response should be 200
    And the response should be empty
Examples:
    | searchTerm |
    | Atlantis   |

Scenario Outline: Search for shipping destinations with numeric search term
    When I send a GET request to /api/ProjectDataPoints/shipping-destinations/search with searchTerm "<searchTerm>"
    Then the API response should be 200
    And the response should handle numeric search terms
Examples:
    | searchTerm |
    | 123456     |