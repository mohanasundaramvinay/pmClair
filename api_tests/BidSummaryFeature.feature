Feature: Bid Summary Retrieval

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve bid summary for a valid project
    When I send a GET request to /api/projects/<entityNo>/bid-summary
    Then the API response should be 200
    And the response should contain a list of bid summaries
Examples:
    | entityNo |
    | 12345    |
    | 67890    |

Scenario Outline: Retrieve bid summary for a non-existent project
    When I send a GET request to /api/projects/<entityNo>/bid-summary
    Then the API response should be 404
Examples:
    | entityNo |
    | 00000    |
    | 99999    |

Scenario Outline: Retrieve bid summary with invalid entity number format
    When I send a GET request to /api/projects/<entityNo>/bid-summary
    Then the API response should be 400
Examples:
    | entityNo |
    | abcde    |
    | 12@34    |

Scenario Outline: Retrieve bid summary with special characters in entity number
    When I send a GET request to /api/projects/<entityNo>/bid-summary
    Then the API response should be 400
Examples:
    | entityNo |
    | !@#$%    |
    | 123*456  |

Scenario Outline: Retrieve bid summary with excessively long entity number
    When I send a GET request to /api/projects/<entityNo>/bid-summary
    Then the API response should be 400
Examples:
    | entityNo |
    | 12345678901234567890 |
    | 98765432109876543210 |