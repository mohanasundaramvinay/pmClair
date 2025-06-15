Feature: Production Schedule Event Types Retrieval

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve all production schedule event types
    When I send a GET request to /api/ProjectDataPoints/production-schedule-event-types/all
    Then the API response should be <StatusCode>
    And the response should contain a list of production schedule event types
    And each event type should have the fields: EventTypeCode, Description, ColorCode, SortOrder, IsActive

Examples:
    | StatusCode |
    | 200        |