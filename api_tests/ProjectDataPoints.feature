Feature: Project Data Points Retrieval

Background:
    Given I have access to the Project Data Points API

Scenario Outline: Retrieve all project data without project number
    When I send a GET request to /api/ProjectDataPoints/all-data
    Then the API response should have status code <StatusCode>
    And the response should contain a list of companies
    And the response should contain a list of project statuses
    And the response should contain a list of warehouses
    And the response should contain a list of rate types
    And the response should contain a list of contact categories
Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Retrieve all project data with a valid project number
    When I send a GET request to /api/ProjectDataPoints/all-data?projectNumber=<ProjectNumber>
    Then the API response should have status code <StatusCode>
    And the response should contain a list of companies
    And the response should contain a list of project statuses
    And the response should contain a list of warehouses
    And the response should contain a list of rate types
    And the response should contain a list of contact categories
Examples:
    | ProjectNumber | StatusCode |
    | PROJ123       | 200        |

Scenario Outline: Retrieve all project data with an invalid project number
    When I send a GET request to /api/ProjectDataPoints/all-data?projectNumber=<ProjectNumber>
    Then the API response should have status code <StatusCode>
Examples:
    | ProjectNumber | StatusCode |
    | INVALID123    | 404        |

Scenario Outline: Retrieve all project data with special characters in project number
    When I send a GET request to /api/ProjectDataPoints/all-data?projectNumber=<ProjectNumber>
    Then the API response should have status code <StatusCode>
Examples:
    | ProjectNumber | StatusCode |
    | !@#$%^&*()    | 400        |

Scenario Outline: Retrieve all project data with a very long project number
    When I send a GET request to /api/ProjectDataPoints/all-data?projectNumber=<ProjectNumber>
    Then the API response should have status code <StatusCode>
Examples:
    | ProjectNumber | StatusCode |
    | 
    | 200        |