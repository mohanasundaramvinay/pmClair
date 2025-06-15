Feature: Project Part Bids Retrieval

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve part bids for a project
    When I send a GET request to /api/projects/<entityNo>/part-bids
    Then the API response should be <StatusCode>
    And the response should contain a list of part bids
Examples:
    | entityNo  | StatusCode |
    | PROJ123   | 200        |
    | PROJ999   | 404        |
    | INVALID   | 400        |

Scenario Outline: Retrieve part bids with special characters in entityNo
    When I send a GET request to /api/projects/<entityNo>/part-bids
    Then the API response should be <StatusCode>
Examples:
    | entityNo  | StatusCode |
    | PROJ@123  | 400        |
    | PROJ#123  | 400        |

Scenario Outline: Retrieve part bids with SQL injection attempt
    When I send a GET request to /api/projects/<entityNo>/part-bids
    Then the API response should be <StatusCode>
Examples:
    | entityNo          | StatusCode |
    | ' OR '1'='1' --   | 400        |
    | ' OR 'x'='x' --   | 400        |

Scenario Outline: Retrieve part bids with excessively long entityNo
    When I send a GET request to /api/projects/<entityNo>/part-bids
    Then the API response should be <StatusCode>
Examples:
    | entityNo                                                                 | StatusCode |
    | PROJ1234567890123456789012345678901234567890123456789012345678901234567890 | 400        |