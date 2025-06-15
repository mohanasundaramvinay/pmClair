Feature: Pollstar Artists Retrieval

Background:
    Given the Pollstar Artists API is available

Scenario Outline: Retrieve all Pollstar artists
    When I send a GET request to /api/ProjectDataPoints/pollstar-artists
    Then the API response should be <StatusCode>
    And the response should contain a list of artists
Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Retrieve Pollstar artists with invalid endpoint
    When I send a GET request to /api/ProjectDataPoints/pollstar-artist
    Then the API response should be <StatusCode>
Examples:
    | StatusCode |
    | 404        |

Scenario Outline: Retrieve Pollstar artists with server error
    When I simulate a server error for GET /api/ProjectDataPoints/pollstar-artists
    Then the API response should be <StatusCode>
Examples:
    | StatusCode |
    | 500        |

Scenario Outline: Retrieve Pollstar artists with unauthorized access
    Given I am not authorized
    When I send a GET request to /api/ProjectDataPoints/pollstar-artists
    Then the API response should be <StatusCode>
Examples:
    | StatusCode |
    | 401        |

Scenario Outline: Retrieve Pollstar artists with empty response
    When I send a GET request to /api/ProjectDataPoints/pollstar-artists
    Then the API response should be <StatusCode>
    And the response should be an empty list
Examples:
    | StatusCode |
    | 200        |