Feature: Retrieve Recent Projects

Background:
    Given I have access to the Project API

Scenario Outline: Retrieve a specific number of recent projects
    When I send a GET request to /api/Project/recent with numberOfProjects=<NumberOfProjects>
    Then the API response should be a list of <ExpectedCount> projects
    And the response status code should be <StatusCode>
Examples:
    | NumberOfProjects | ExpectedCount | StatusCode |
    | 0               | 0             | 200        |
    | 1               | 1             | 200        |
    | 50              | 50            | 200        |
    | 100             | 100           | 200        |
    | 101             | 100           | 200        |

Scenario Outline: Retrieve recent projects with invalid parameters
    When I send a GET request to /api/Project/recent with numberOfProjects=<NumberOfProjects>
    Then the API response should be a list of <ExpectedCount> projects
    And the response status code should be <StatusCode>
Examples:
    | NumberOfProjects | ExpectedCount | StatusCode |
    | -1              | 0             | 400        |
    | 1000            | 100           | 200        |
    | null            | 100           | 200        |