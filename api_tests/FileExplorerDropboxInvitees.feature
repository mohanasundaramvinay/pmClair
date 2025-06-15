Feature: File Explorer Dropbox Invitees

Background:
    Given I have access to the File Explorer API

Scenario Outline: Retrieve Dropbox invitees for a valid entity number
    When I send a GET request to /api/FileExplorer/dropboxInvitees/<entityNo>
    Then the API response should be 200
    And the response should contain a list of invitees
Examples:
    | entityNo |
    | 12345    |
    | 67890    |

Scenario Outline: Retrieve Dropbox invitees with an invalid entity number
    When I send a GET request to /api/FileExplorer/dropboxInvitees/<entityNo>
    Then the API response should be 400
Examples:
    | entityNo |
    | invalid  |
    |          |

Scenario Outline: Retrieve Dropbox invitees for a non-existent entity number
    When I send a GET request to /api/FileExplorer/dropboxInvitees/<entityNo>
    Then the API response should be 404
Examples:
    | entityNo |
    | 99999    |

Scenario Outline: Retrieve Dropbox invitees with a very large entity number
    When I send a GET request to /api/FileExplorer/dropboxInvitees/<entityNo>
    Then the API response should be 400
Examples:
    | entityNo |
    | 12345678901234567890 |

Scenario Outline: Retrieve Dropbox invitees with special characters in entity number
    When I send a GET request to /api/FileExplorer/dropboxInvitees/<entityNo>
    Then the API response should be 400
Examples:
    | entityNo |
    | @#$%^&*() |