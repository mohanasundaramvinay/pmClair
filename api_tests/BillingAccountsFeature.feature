Feature: Billing Accounts Retrieval

Background:
    Given I have access to the ProjectDataPoints API

Scenario: Retrieve all billing accounts successfully
    When I send a GET request to /api/ProjectDataPoints/billing-accounts
    Then the API response should be 200
    And the response should contain a list of billing accounts

Scenario: Handle server error when retrieving billing accounts
    When I send a GET request to /api/ProjectDataPoints/billing-accounts
    Then the API response should be 500
    And the response should contain an error message

Scenario Outline: Validate billing account fields
    When I send a GET request to /api/ProjectDataPoints/billing-accounts
    Then the API response should be 200
    And the response should contain a billing account with AccountNumber "<AccountNumber>"
    And the response should contain a billing account with AccountName "<AccountName>"
    And the response should contain a billing account with CompanyName "<CompanyName>"
    And the response should contain a billing account with IsActive "<IsActive>"
Examples:
    | AccountNumber | AccountName            | CompanyName       | IsActive |
    | ACC123        | Main Billing Account   | Acme Corporation  | true     |
    | ACC456        | Secondary Billing Account | Beta Industries | false    |