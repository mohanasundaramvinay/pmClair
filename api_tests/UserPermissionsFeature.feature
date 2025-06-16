Feature: User Permissions Retrieval

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve user permissions with valid and invalid scenarios
    When I send a GET request to /api/ProjectDataPoints/user-permissions
    Then the API response should be: <StatusCode>
    And the response should contain role: <Role>
    And the response should contain permissions: <Permissions>
    And the response should contain access levels: <AccessLevels>
    And the response should contain division: <Division>

Examples:
    | StatusCode | Role       | Permissions             | AccessLevels       | Division       |
    | 200        | Admin      | ["Read", "Write"]    | ["Level1"]       | North America  |
    | 200        | User       | ["Read"]              | ["Level1", "Level2"] | Europe        |
    | 500        | null       | null                    | null               | null           |