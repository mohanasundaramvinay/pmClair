Feature: Refresh Purchase Orders

Background:
    Given I have access to the Purchase Order API

Scenario Outline: Refresh purchase orders for a valid project
    When I send a GET request to /api/PurchaseOrder/refresh/<entityNo>
    Then the API response should be 200
    And the response should include a success message with the count of purchase orders
    And the response should include a data array of purchase orders
    And the response should include a refresh timestamp
Examples:
    | entityNo |
    | 12345    |
    | 67890    |

Scenario Outline: Refresh purchase orders for a non-existent project
    When I send a GET request to /api/PurchaseOrder/refresh/<entityNo>
    Then the API response should be 404
Examples:
    | entityNo |
    | 00000    |

Scenario Outline: Refresh purchase orders with invalid entity number format
    When I send a GET request to /api/PurchaseOrder/refresh/<entityNo>
    Then the API response should be 400
Examples:
    | entityNo |
    | abcde    |
    | 12@34    |

Scenario Outline: Refresh purchase orders when service is unavailable
    When I send a GET request to /api/PurchaseOrder/refresh/<entityNo>
    Then the API response should be 500
Examples:
    | entityNo |
    | 12345    |