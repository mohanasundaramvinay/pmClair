Feature: Project Purchases Retrieval

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve purchases for a valid project
    When I send a GET request to /api/projects/<entityNo>/purchases
    Then the API response should be 200
    And the response should contain a list of purchases
Examples:
    | entityNo  |
    | PROJ123   |
    | PROJ456   |

Scenario Outline: Retrieve purchases for an invalid project
    When I send a GET request to /api/projects/<entityNo>/purchases
    Then the API response should be 404
Examples:
    | entityNo  |
    | INVALID   |
    | UNKNOWN   |

Scenario Outline: Retrieve purchases with special characters in project ID
    When I send a GET request to /api/projects/<entityNo>/purchases
    Then the API response should be 400
Examples:
    | entityNo  |
    | PROJ@123  |
    | PROJ#456  |

Scenario Outline: Retrieve purchases with a very long project ID
    When I send a GET request to /api/projects/<entityNo>/purchases
    Then the API response should be 400
Examples:
    | entityNo  |
    | PROJ1234567890123456789012345678901234567890 |

Scenario Outline: Retrieve purchases with a numeric project ID
    When I send a GET request to /api/projects/<entityNo>/purchases
    Then the API response should be 400
Examples:
    | entityNo  |
    | 123456    |

Scenario Outline: Retrieve purchases with an empty project ID
    When I send a GET request to /api/projects/<entityNo>/purchases
    Then the API response should be 400
Examples:
    | entityNo  |
    |           |