Feature: Pollstar Artist Retrieval

Background:
    Given I have access to the Pollstar artist API

Scenario Outline: Retrieve a specific Pollstar artist by ID
    When I send a GET request to /api/ProjectDataPoints/pollstar-artists/<ArtistId>
    Then the API response should be <StatusCode>
    And the response should contain the artist details if <StatusCode> is 200
Examples:
    | ArtistId | StatusCode |
    | 123      | 200        |
    | 999      | 404        |
    | abc      | 400        |
    | -1       | 400        |
    | 0        | 404        |
    | 2147483647 | 404      |
    | null     | 400        |