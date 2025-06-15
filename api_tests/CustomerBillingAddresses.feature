Feature: Customer Billing Addresses Retrieval

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve billing addresses for a customer
    When I send a GET request to /api/ProjectDataPoints/customers/<CustomerNo>/billing-addresses
    Then the API response should be <StatusCode>
    And the response should contain <ExpectedResult>

Examples:
    | CustomerNo | StatusCode | ExpectedResult |
    | CUST123    | 200        | "List of billing addresses" |
    | CUST999    | 404        | "No billing addresses found for customer CUST999" |
    |            | 400        | "Customer number cannot be empty" |
    | CUST456    | 500        | "Internal server error" |