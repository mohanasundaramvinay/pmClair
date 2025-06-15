Feature: Project Favorites Retrieval

Background:
    Given I have access to the Project API

Scenario: Retrieve favorite projects successfully
    When I send a GET request to /api/Project/favorites
    Then the API response should be a list of favorite projects
    And the response status code should be 200

Scenario: Handle server error when retrieving favorite projects
    When I send a GET request to /api/Project/favorites
    Then the API response should be an error message
    And the response status code should be 500

Scenario Outline: Validate response structure for favorite projects
    When I send a GET request to /api/Project/favorites
    Then the API response should contain projects with fields: <Fields>
Examples:
    | Fields                                      |
    | Id, Name, Description, StartDate, EndDate, Status, Owner |

Scenario: Retrieve favorite projects with no projects available
    When I send a GET request to /api/Project/favorites
    Then the API response should be an empty list
    And the response status code should be 200