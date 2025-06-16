Feature: Project Maintenance - Save Project Phases

Background:
    Given I have access to the Project Maintenance API

Scenario Outline: Submit project phases with valid data
    When I send a POST request to /api/projects/<entityNo>/save with the following project data:
        | projectId | phases | notes | budget | resources |
    Then the API response should be 201 Created

Examples:
    | entityNo | projectId | phases | notes | budget | resources |
    | PROJ123  | PROJ123   | [{"phaseId": "PHASE001", "name": "Design Phase", "startDate": "2024-01-01T00:00:00", "endDate": "2024-03-01T00:00:00", "status": "Completed"}] | "Project is on track" | 1000000 | [{"resourceId": "RES001", "name": "John Doe", "role": "Project Manager"}] |

Scenario Outline: Submit project phases with missing projectId
    When I send a POST request to /api/projects/<entityNo>/save with the following project data:
        | projectId | phases | notes | budget | resources |
    Then the API response should be 400 Bad Request

Examples:
    | entityNo | projectId | phases | notes | budget | resources |
    | PROJ123  |           | [{"phaseId": "PHASE001", "name": "Design Phase", "startDate": "2024-01-01T00:00:00", "endDate": "2024-03-01T00:00:00", "status": "Completed"}] | "Project is on track" | 1000000 | [{"resourceId": "RES001", "name": "John Doe", "role": "Project Manager"}] |

Scenario Outline: Submit project phases with invalid budget
    When I send a POST request to /api/projects/<entityNo>/save with the following project data:
        | projectId | phases | notes | budget | resources |
    Then the API response should be 400 Bad Request

Examples:
    | entityNo | projectId | phases | notes | budget | resources |
    | PROJ123  | PROJ123   | [{"phaseId": "PHASE001", "name": "Design Phase", "startDate": "2024-01-01T00:00:00", "endDate": "2024-03-01T00:00:00", "status": "Completed"}] | "Project is on track" | -1000 | [{"resourceId": "RES001", "name": "John Doe", "role": "Project Manager"}] |

Scenario Outline: Submit project phases with overlapping phase dates
    When I send a POST request to /api/projects/<entityNo>/save with the following project data:
        | projectId | phases | notes | budget | resources |
    Then the API response should be 400 Bad Request

Examples:
    | entityNo | projectId | phases | notes | budget | resources |
    | PROJ123  | PROJ123   | [{"phaseId": "PHASE001", "name": "Design Phase", "startDate": "2024-01-01T00:00:00", "endDate": "2024-03-01T00:00:00", "status": "Completed"}, {"phaseId": "PHASE002", "name": "Development Phase", "startDate": "2024-02-15T00:00:00", "endDate": "2024-06-01T00:00:00", "status": "In Progress"}] | "Project is on track" | 1000000 | [{"resourceId": "RES001", "name": "John Doe", "role": "Project Manager"}] |