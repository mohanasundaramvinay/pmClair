Feature: Auth Test Endpoint

Background:
    Given I have a valid JWT token

Scenario Outline: Test database connection with valid and invalid tokens
    When I send a GET request to /api/auth/test with token "<Token>"
    Then the API response should be "<StatusCode>" with message "<Message>"
Examples:
    | Token          | StatusCode | Message                                           |
    | valid_token    | 200        | Authorized access and database connection successful! |
    | invalid_token  | 401        | Unauthorized                                      |
    | expired_token  | 401        | Unauthorized                                      |
    | no_token       | 401        | Unauthorized                                      |

Scenario Outline: Test database connection failure
    Given the database is down
    When I send a GET request to /api/auth/test with token "<Token>"
    Then the API response should be "<StatusCode>" with message "<Message>"
Examples:
    | Token       | StatusCode | Message                   |
    | valid_token | 500        | Database connection failed |