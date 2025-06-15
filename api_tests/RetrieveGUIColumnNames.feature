Feature: Retrieve GUI Column Names

Background:
    Given the API is running

Scenario Outline: Retrieve GUI Column Names with valid request
    When I send a GET request to /api/ProjectDataPoints/gui-column-names
    Then the API response should be 200
    And the response should contain a list of GUI column names

Scenario Outline: Retrieve GUI Column Names with invalid endpoint
    When I send a GET request to /api/ProjectDataPoints/invalid-endpoint
    Then the API response should be 404

Scenario Outline: Retrieve GUI Column Names with server error simulation
    Given the server is configured to simulate an error
    When I send a GET request to /api/ProjectDataPoints/gui-column-names
    Then the API response should be 500

Scenario Outline: Retrieve GUI Column Names with empty response
    Given the database is empty
    When I send a GET request to /api/ProjectDataPoints/gui-column-names
    Then the API response should be 200
    And the response should be an empty list

Scenario Outline: Retrieve GUI Column Names with large dataset
    Given the database contains a large number of GUI column names
    When I send a GET request to /api/ProjectDataPoints/gui-column-names
    Then the API response should be 200
    And the response should contain a large list of GUI column names

Scenario Outline: Retrieve GUI Column Names with slow response
    Given the server is configured to respond slowly
    When I send a GET request to /api/ProjectDataPoints/gui-column-names
    Then the API response should be 200
    And the response time should be greater than expected

Examples:
    | ScenarioDescription |
    | Valid request       |
    | Invalid endpoint    |
    | Server error        |
    | Empty response      |
    | Large dataset       |
    | Slow response       |