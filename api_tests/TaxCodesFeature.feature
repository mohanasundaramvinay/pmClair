Feature: Tax Codes Retrieval

Background:
    Given the API is running

Scenario Outline: Retrieve all tax codes
    When I send a GET request to /api/ProjectDataPoints/tax-codes
    Then the API response should be <StatusCode>
    And the response should contain a list of tax codes
    Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving tax codes
    When I send a GET request to /api/ProjectDataPoints/tax-codes
    Then the API response should be <StatusCode>
    And the response should contain an error message
    Examples:
    | StatusCode |
    | 500        |

Scenario Outline: Validate tax code fields
    When I send a GET request to /api/ProjectDataPoints/tax-codes
    Then the API response should be 200
    And each tax code should have a <Field>
    Examples:
    | Field          |
    | Id             |
    | Code           |
    | Description    |
    | Rate           |
    | IsActive       |
    | ApplicableRegions |

Scenario Outline: Validate tax code rate values
    When I send a GET request to /api/ProjectDataPoints/tax-codes
    Then the API response should be 200
    And each tax code rate should be a valid <RateType>
    Examples:
    | RateType |
    | decimal  |

Scenario Outline: Validate tax code active status
    When I send a GET request to /api/ProjectDataPoints/tax-codes
    Then the API response should be 200
    And each tax code active status should be a boolean
    Examples:
    | StatusType |
    | boolean    |