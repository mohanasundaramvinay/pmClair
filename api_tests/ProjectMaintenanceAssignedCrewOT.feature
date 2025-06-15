Feature: Project Maintenance - Assigned Crew OT

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve assigned crew overtime data for a project
    When I send a GET request to /api/projects/<EntityNo>/assigned-crew/ot
    Then the API response should be <StatusCode>
    And the response should contain a list of assigned crew overtime data
Examples:
    | EntityNo  | StatusCode |
    | PROJ123   | 200        |
    | PROJ999   | 404        |
    |           | 400        |
    | PROJ123   | 500        |