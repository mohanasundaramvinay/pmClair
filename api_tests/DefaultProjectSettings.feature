Feature: Default Project Settings Retrieval

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve default project settings for a specific user
    When I send a GET request to /api/ProjectDataPoints/default-project-settings with username "<Username>"
    Then the API response should be <StatusCode> with the default project settings
Examples:
    | Username   | StatusCode |
    | john.doe   | 200        |
    | jane.smith | 200        |

Scenario Outline: Retrieve default project settings without specifying a username
    When I send a GET request to /api/ProjectDataPoints/default-project-settings
    Then the API response should be <StatusCode> with the default project settings for the current user
Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Retrieve default project settings with an invalid username
    When I send a GET request to /api/ProjectDataPoints/default-project-settings with username "<Username>"
    Then the API response should be <StatusCode> with an error message
Examples:
    | Username   | StatusCode |
    | invalidUser| 404        |

Scenario Outline: Retrieve default project settings with a null username
    When I send a GET request to /api/ProjectDataPoints/default-project-settings with username "<Username>"
    Then the API response should be <StatusCode> with an error message
Examples:
    | Username | StatusCode |
    | null     | 400        |