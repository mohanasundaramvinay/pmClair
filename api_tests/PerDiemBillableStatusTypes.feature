Feature: Per Diem Billable Status Types Retrieval

Background:
    Given the API is running and accessible

Scenario Outline: Retrieve all per diem billable status types
    When I send a GET request to /api/ProjectDataPoints/per-diem-billable-status-types
    Then the API response should be <StatusCode>
    And the response should contain a list of per diem billable status types
Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving per diem billable status types
    Given the server is experiencing issues
    When I send a GET request to /api/ProjectDataPoints/per-diem-billable-status-types
    Then the API response should be <StatusCode>
Examples:
    | StatusCode |
    | 500        |

Scenario Outline: Validate response structure for per diem billable status types
    When I send a GET request to /api/ProjectDataPoints/per-diem-billable-status-types
    Then the response should contain fields <Fields>
Examples:
    | Fields                                                                 |
    | StatusCode, Description, BillingRules, ActiveStatus, EffectiveDate     |
    | ExpirationDate, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate       |
    | AdditionalInfo, StatusCategory                                        |