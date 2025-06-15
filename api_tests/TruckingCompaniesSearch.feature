Feature: Trucking Companies Search

Background:
    Given I have access to the trucking companies API

Scenario Outline: Search for trucking companies by name or number
    When I send a GET request to /api/ProjectDataPoints/trucking-companies/search with searchTerm "<searchTerm>"
    Then the API response should be <StatusCode>
    And the response should contain <ExpectedResult>

Examples:
    | searchTerm         | StatusCode | ExpectedResult |
    | Fast Freight Inc.  | 200        | true           |
    | GT456              | 200        | true           |
    | NonExistentCompany | 200        | false          |
    |                    | 400        | false          |