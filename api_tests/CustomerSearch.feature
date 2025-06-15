Feature: Customer Search API

Background:
    Given the API is running and accessible

Scenario Outline: Search for customers by name or customer number
    When I send a GET request to /api/ProjectDataPoints/customers/search with searchTerm "<searchTerm>"
    Then the API response should be <StatusCode>
    And the response should contain <ExpectedResult>

Examples:
    | searchTerm | StatusCode | ExpectedResult |
    | JohnDoe    | 200        | "CustomerName": "John Doe" |
    | Acme       | 200        | "CustomerName": "Acme Corporation" |
    | NonExistent| 200        | [] |
    |            | 400        | "Search term is required" |