Feature: Vendor API - Get Known Vendors

Background:
    Given the Vendor API is running

Scenario Outline: Retrieve known vendors for a valid part number
    When I send a GET request to /api/vendor/known-vendors/<PartNo>
    Then the API response should be 200
    And the response should contain a list of vendors
Examples:
    | PartNo |
    | 12345  |
    | 67890  |

Scenario Outline: Retrieve known vendors with an invalid part number
    When I send a GET request to /api/vendor/known-vendors/<PartNo>
    Then the API response should be 400
Examples:
    | PartNo |
    |        |
    | null   |

Scenario Outline: Retrieve known vendors for a non-existent part number
    When I send a GET request to /api/vendor/known-vendors/<PartNo>
    Then the API response should be 200
    And the response should be an empty list
Examples:
    | PartNo |
    | 99999  |

Scenario Outline: Retrieve known vendors with special characters in part number
    When I send a GET request to /api/vendor/known-vendors/<PartNo>
    Then the API response should be 400
Examples:
    | PartNo |
    | @#$%   |
    | !*()   |

Scenario Outline: Retrieve known vendors with a very long part number
    When I send a GET request to /api/vendor/known-vendors/<PartNo>
    Then the API response should be 400
Examples:
    | PartNo |
    | 1234567890123456789012345678901234567890 |