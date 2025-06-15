Feature: Project Data Points - Job Types

Background:
    Given the Project Data Points API is running

Scenario Outline: Retrieve job types with valid and invalid scenarios
    When I send a GET request to /api/ProjectDataPoints/job-types
    Then the API response should be <StatusCode>
    And the response should contain a list of job types
    Examples:
    | StatusCode |
    | 200        |
    | 500        |