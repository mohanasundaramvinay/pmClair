Feature: Project Data Points - Companies Endpoint

Background:
    Given I have access to the Project Data Points API

Scenario Outline: Retrieve all companies
    When I send a GET request to /api/ProjectDataPoints/companies
    Then the API response should be <StatusCode>
    And the response should contain a list of companies
    And each company should have a CompanyCode, CompanyName, DivisionInformation, ActiveStatus, Address, ContactNumber, Email, EstablishedYear, and NumberOfEmployees

Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving companies
    When I send a GET request to /api/ProjectDataPoints/companies
    Then the API response should be <StatusCode>
    And the response should contain an error message

Examples:
    | StatusCode |
    | 500        |