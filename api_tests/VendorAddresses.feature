Feature: Vendor Addresses Retrieval

Background:
    Given I have access to the vendor API

Scenario Outline: Retrieve vendor addresses with valid vendor number
    When I send a GET request to /api/vendor/addresses/<VendNo>
    Then the API response should be 200
    And the response should contain a list of vendor addresses
Examples:
    | VendNo |
    | 12345  |
    | 67890  |

Scenario Outline: Retrieve vendor addresses with invalid vendor number
    When I send a GET request to /api/vendor/addresses/<VendNo>
    Then the API response should be 400
Examples:
    | VendNo |
    | ''     |
    | null   |

Scenario Outline: Retrieve vendor addresses with non-existent vendor number
    When I send a GET request to /api/vendor/addresses/<VendNo>
    Then the API response should be 200
    And the response should be an empty list
Examples:
    | VendNo |
    | 99999  |

Scenario Outline: Retrieve vendor addresses with special characters in vendor number
    When I send a GET request to /api/vendor/addresses/<VendNo>
    Then the API response should be 400
Examples:
    | VendNo |
    | '@#$%' |
    | 'abc123' |