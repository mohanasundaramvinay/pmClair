Feature: Shipping Destinations Retrieval

Background:
    Given I have access to the ProjectDataPoints API

Scenario: Retrieve all shipping destinations successfully
    When I send a GET request to /api/ProjectDataPoints/shipping-destinations
    Then the API response should be 200
    And the response should contain a list of shipping destinations

Scenario: Handle server error when retrieving shipping destinations
    When I send a GET request to /api/ProjectDataPoints/shipping-destinations
    Then the API response should be 500
    And the response should contain an error message

Scenario Outline: Retrieve shipping destinations with varying server load
    When I send a GET request to /api/ProjectDataPoints/shipping-destinations
    Then the API response should be <StatusCode>
    And the response time should be less than <MaxResponseTime> milliseconds
Examples:
    | StatusCode | MaxResponseTime |
    | 200        | 1000            |
    | 200        | 2000            |
    | 500        | 5000            |