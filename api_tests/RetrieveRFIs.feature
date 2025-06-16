Feature: Retrieve RFIs for a Project

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Retrieve RFIs for a valid project
    When I send a GET request to /api/projects/<entityNo>/rfis
    Then the API response should be a list of RFIs with status code <StatusCode>
Examples:
    | entityNo | StatusCode |
    | PROJ123  | 200        |
    | PROJ456  | 200        |

Scenario Outline: Retrieve RFIs for a non-existent project
    When I send a GET request to /api/projects/<entityNo>/rfis
    Then the API response should be an error with status code <StatusCode>
Examples:
    | entityNo | StatusCode |
    | INVALID  | 404        |

Scenario Outline: Retrieve RFIs with invalid entity number format
    When I send a GET request to /api/projects/<entityNo>/rfis
    Then the API response should be an error with status code <StatusCode>
Examples:
    | entityNo | StatusCode |
    | 123      | 400        |
    | !@#$     | 400        |

Scenario Outline: Retrieve RFIs with missing entity number
    When I send a GET request to /api/projects//rfis
    Then the API response should be an error with status code <StatusCode>
Examples:
    | StatusCode |
    | 404        |