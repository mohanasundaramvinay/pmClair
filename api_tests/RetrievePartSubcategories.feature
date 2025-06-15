Feature: Retrieve Part Subcategories

Background:
    Given I have access to the ProjectDataPoints API

Scenario Outline: Retrieve subcategories for a valid category code
    When I send a GET request to /api/ProjectDataPoints/parts/subcategories/<CategoryCode>
    Then the API response should be 200
    And the response should contain a list of subcategories
Examples:
    | CategoryCode  |
    | ELECTRICAL    |
    | MECHANICAL    |

Scenario Outline: Retrieve subcategories for an invalid category code
    When I send a GET request to /api/ProjectDataPoints/parts/subcategories/<CategoryCode>
    Then the API response should be 400
Examples:
    | CategoryCode  |
    | INVALID_CODE  |

Scenario Outline: Retrieve subcategories with an empty category code
    When I send a GET request to /api/ProjectDataPoints/parts/subcategories/<CategoryCode>
    Then the API response should be 400
Examples:
    | CategoryCode  |
    |               |

Scenario Outline: Retrieve subcategories for a category code with special characters
    When I send a GET request to /api/ProjectDataPoints/parts/subcategories/<CategoryCode>
    Then the API response should be 400
Examples:
    | CategoryCode  |
    | @#$%^&*       |

Scenario Outline: Retrieve subcategories for a category code with SQL injection attempt
    When I send a GET request to /api/ProjectDataPoints/parts/subcategories/<CategoryCode>
    Then the API response should be 400
Examples:
    | CategoryCode  |
    | ' OR '1'='1   |