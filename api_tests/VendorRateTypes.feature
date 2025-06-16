Feature: Vendor Rate Types Retrieval

Background:
    Given the Vendor API is running

Scenario Outline: Retrieve rate types successfully
    When I send a GET request to /api/vendor/rate-types
    Then the API response should be 200
    And the response should contain a list of rate types

Scenario Outline: Handle server error when retrieving rate types
    Given the server is experiencing issues
    When I send a GET request to /api/vendor/rate-types
    Then the API response should be 500
    And the response should contain an error message

Scenario Outline: Validate response structure for rate types
    When I send a GET request to /api/vendor/rate-types
    Then the API response should be 200
    And each rate type should have an Id, Name, and Description

Examples:
    | Scenario |
    | Success  |
    | Error    |