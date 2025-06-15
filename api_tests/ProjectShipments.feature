Feature: Project Shipments Retrieval

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve shipments for a valid project
    When I send a GET request to /api/projects/<entityNo>/shipments
    Then the API response should be a list of shipments with status code <StatusCode>
Examples:
    | entityNo | StatusCode |
    | PROJ001  | 200        |
    | PROJ002  | 200        |

Scenario Outline: Retrieve shipments for a non-existent project
    When I send a GET request to /api/projects/<entityNo>/shipments
    Then the API response should be an error with status code <StatusCode>
Examples:
    | entityNo | StatusCode |
    | INVALID  | 404        |

Scenario Outline: Retrieve shipments with invalid entity number format
    When I send a GET request to /api/projects/<entityNo>/shipments
    Then the API response should be an error with status code <StatusCode>
Examples:
    | entityNo | StatusCode |
    | 12345    | 400        |
    | !@#$%    | 400        |

Scenario Outline: Retrieve shipments for a project with no shipments
    When I send a GET request to /api/projects/<entityNo>/shipments
    Then the API response should be an empty list with status code <StatusCode>
Examples:
    | entityNo | StatusCode |
    | PROJ003  | 200        |

Scenario Outline: Retrieve shipments with special characters in entity number
    When I send a GET request to /api/projects/<entityNo>/shipments
    Then the API response should be an error with status code <StatusCode>
Examples:
    | entityNo | StatusCode |
    | PROJ@123 | 400        |