Feature: Purchase Order Retrieval

Background:
    Given I have access to the Purchase Order API

Scenario Outline: Retrieve purchase orders for a valid project
    When I send a GET request to /api/PurchaseOrder/project/<entityNo>
    Then the API response should be 200
    And the response should contain a list of purchase orders
Examples:
    | entityNo |
    | 12345    |
    | 67890    |

Scenario Outline: Retrieve purchase orders for a non-existent project
    When I send a GET request to /api/PurchaseOrder/project/<entityNo>
    Then the API response should be 404
Examples:
    | entityNo |
    | 00000    |
    | 99999    |

Scenario Outline: Retrieve purchase orders with invalid project number
    When I send a GET request to /api/PurchaseOrder/project/<entityNo>
    Then the API response should be 400
Examples:
    | entityNo |
    | abcde    |
    | !@#$%    |

Scenario Outline: Retrieve purchase orders with special characters in project number
    When I send a GET request to /api/PurchaseOrder/project/<entityNo>
    Then the API response should be 400
Examples:
    | entityNo |
    | 123*45   |
    | 67&890   |

Scenario Outline: Retrieve purchase orders with empty project number
    When I send a GET request to /api/PurchaseOrder/project/<entityNo>
    Then the API response should be 400
Examples:
    | entityNo |
    |          |