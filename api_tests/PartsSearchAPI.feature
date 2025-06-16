Feature: Parts Search API

Background:
    Given the API is running

Scenario Outline: Search parts with various criteria
    When I send a POST request to /api/ProjectDataPoints/parts/search with the following data:
        | searchText        | category     | subCategory | hideUnusedParts | onlyMyWarehouses | myPartsOnly | searchForBarcode |
        | <searchText>      | <category>   | <subCategory> | <hideUnusedParts> | <onlyMyWarehouses> | <myPartsOnly> | <searchForBarcode> |
    Then the API response should be <StatusCode>
    And the response should contain <ExpectedPartsCount> parts

Examples:
    | searchText        | category     | subCategory | hideUnusedParts | onlyMyWarehouses | myPartsOnly | searchForBarcode | StatusCode | ExpectedPartsCount |
    | ""               | ""          | ""         | false           | false            | false       | false            | 200        | 100                |
    | "Cable"          | "ELECTRICAL"| "CABLE"    | true            | false            | false       | false            | 200        | 10                 |
    | "Bracket"        | "MECHANICAL"| "BRACKET"  | false           | true             | false       | false            | 200        | 5                  |
    | "NonExistent"    | ""          | ""         | false           | false            | false       | false            | 200        | 0                  |
    | ""               | "ELECTRICAL"| ""         | false           | false            | false       | true             | 200        | 50                 |
    | ""               | ""          | ""         | true            | true             | true        | false            | 200        | 20                 |
    | ""               | ""          | ""         | false           | false            | false       | false            | 500        | 0                  |