Feature: Purchase Order Creation

Background:
    Given I have access to the Purchase Order API

Scenario Outline: Create a new purchase order
    When I send a POST request to /api/PurchaseOrder with the following details: "<EntityNo>", "<PODescription>"
    Then the API response should be: "<StatusCode>"
Examples:
    | EntityNo | PODescription                  | StatusCode |
    | 12345    | Purchase order for office supplies | 201        |
    | 12345    |                                  | 400        |
    |          | Purchase order for office supplies | 400        |
    | 12345    | Purchase order with a very long description exceeding typical limits to test edge case handling | 400        |

Scenario Outline: Create a purchase order with invalid data
    When I send a POST request to /api/PurchaseOrder with the following details: "<EntityNo>", "<PODescription>"
    Then the API response should be: "<StatusCode>"
Examples:
    | EntityNo | PODescription | StatusCode |
    | abcde    | Valid description | 400        |
    | 12345    | <script>alert('xss')</script> | 400        |
    | 12345    | DROP TABLE PurchaseOrders; | 400        |