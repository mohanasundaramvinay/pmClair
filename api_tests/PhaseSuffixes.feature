Feature: Phase Suffixes Retrieval

Background:
    Given I have access to the Phase API

Scenario: Retrieve suffixes successfully
    When I send a GET request to /api/Phase/suffixes
    Then the API response should be 200
    And the response should contain a list of projects

Scenario: Server error when retrieving suffixes
    When I send a GET request to /api/Phase/suffixes
    Then the API response should be 500
    And the response should contain an error message

Scenario Outline: Validate response structure
    When I send a GET request to /api/Phase/suffixes
    Then the API response should be 200
    And the response should contain projects with fields: <Fields>
Examples:
    | Fields                        |
    | Id, Name, Description         |
    | StartDate, EndDate, Status    |

Scenario: No suffixes available
    When I send a GET request to /api/Phase/suffixes
    Then the API response should be 200
    And the response should be an empty list