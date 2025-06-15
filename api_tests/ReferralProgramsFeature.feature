Feature: Referral Programs API

Background:
    Given I have access to the referral programs API

Scenario Outline: Retrieve all referral programs
    When I send a GET request to /api/ProjectDataPoints/referral-programs
    Then the API response should be a list of referral programs with status code <StatusCode>
Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Retrieve referral programs with server error
    When I send a GET request to /api/ProjectDataPoints/referral-programs
    Then the API response should be an error message with status code <StatusCode>
Examples:
    | StatusCode |
    | 500        |

Scenario Outline: Retrieve referral programs with empty response
    When I send a GET request to /api/ProjectDataPoints/referral-programs
    Then the API response should be an empty list with status code <StatusCode>
Examples:
    | StatusCode |
    | 200        |