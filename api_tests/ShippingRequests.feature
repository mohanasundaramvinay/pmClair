Feature: Shipping Requests Retrieval

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve shipping requests for a valid project number
    When I send a GET request to /api/ProjectDataPoints/shipping-requests/<ProjectNumber>
    Then the API response should be <StatusCode>
    And the response should contain a list of shipping requests
Examples:
    | ProjectNumber | StatusCode |
    | PROJ123       | 200        |
    | PROJ456       | 200        |

Scenario Outline: Retrieve shipping requests for an invalid project number
    When I send a GET request to /api/ProjectDataPoints/shipping-requests/<ProjectNumber>
    Then the API response should be <StatusCode>
Examples:
    | ProjectNumber | StatusCode |
    | INVALID123    | 404        |
    | UNKNOWN456    | 404        |

Scenario Outline: Retrieve shipping requests with special characters in project number
    When I send a GET request to /api/ProjectDataPoints/shipping-requests/<ProjectNumber>
    Then the API response should be <StatusCode>
Examples:
    | ProjectNumber | StatusCode |
    | PROJ!@#       | 400        |
    | PROJ$%^       | 400        |

Scenario Outline: Retrieve shipping requests with empty project number
    When I send a GET request to /api/ProjectDataPoints/shipping-requests/<ProjectNumber>
    Then the API response should be <StatusCode>
Examples:
    | ProjectNumber | StatusCode |
    | ""           | 400        |

Scenario Outline: Retrieve shipping requests for a project number with excessive length
    When I send a GET request to /api/ProjectDataPoints/shipping-requests/<ProjectNumber>
    Then the API response should be <StatusCode>
Examples:
    | ProjectNumber | StatusCode |
    | PROJ12345678901234567890 | 400 |