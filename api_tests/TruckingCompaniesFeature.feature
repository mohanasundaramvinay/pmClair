Feature: Trucking Companies API

Background:
    Given I have access to the Trucking Companies API

Scenario Outline: Retrieve all trucking companies
    When I send a GET request to /api/ProjectDataPoints/trucking-companies
    Then the API response should be a list of trucking companies with status code <StatusCode>
Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving trucking companies
    When I send a GET request to /api/ProjectDataPoints/trucking-companies
    Then the API response should be an error message with status code <StatusCode>
Examples:
    | StatusCode |
    | 500        |

Scenario Outline: Validate trucking company data structure
    When I send a GET request to /api/ProjectDataPoints/trucking-companies
    Then each trucking company should have fields: <Fields>
Examples:
    | Fields                                      |
    | CompanyName, CompanyNumber, Address, ContactInformation, ActiveStatus |