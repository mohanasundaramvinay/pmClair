Feature: File Sharing Remove All

Background:
    Given I have access to the File Sharing API

Scenario Outline: Remove access for all members with valid parameters
    When I send a POST request to /api/FileSharing/remove-all with entityNo "<EntityNo>" and template "<Template>"
    Then the API response should be: "<StatusCode>"
Examples:
    | EntityNo | Template | StatusCode |
    | 12345    | TemplateA | 200        |
    | 67890    | TemplateB | 200        |

Scenario Outline: Remove access for all members with missing entityNo
    When I send a POST request to /api/FileSharing/remove-all with entityNo "<EntityNo>" and template "<Template>"
    Then the API response should be: "<StatusCode>"
Examples:
    | EntityNo | Template | StatusCode |
    |          | TemplateA | 400        |

Scenario Outline: Remove access for all members with missing template
    When I send a POST request to /api/FileSharing/remove-all with entityNo "<EntityNo>" and template "<Template>"
    Then the API response should be: "<StatusCode>"
Examples:
    | EntityNo | Template | StatusCode |
    | 12345    |          | 400        |

Scenario Outline: Remove access for all members with invalid entityNo
    When I send a POST request to /api/FileSharing/remove-all with entityNo "<EntityNo>" and template "<Template>"
    Then the API response should be: "<StatusCode>"
Examples:
    | EntityNo | Template | StatusCode |
    | invalid  | TemplateA | 400        |

Scenario Outline: Remove access for all members with invalid template
    When I send a POST request to /api/FileSharing/remove-all with entityNo "<EntityNo>" and template "<Template>"
    Then the API response should be: "<StatusCode>"
Examples:
    | EntityNo | Template | StatusCode |
    | 12345    | invalid  | 400        |

Scenario Outline: Remove access for all members with SQL injection attempt
    When I send a POST request to /api/FileSharing/remove-all with entityNo "<EntityNo>" and template "<Template>"
    Then the API response should be: "<StatusCode>"
Examples:
    | EntityNo | Template | StatusCode |
    | 12345    | ' OR '1'='1 | 400        |