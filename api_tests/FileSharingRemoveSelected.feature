Feature: File Sharing - Remove Selected Member Access

Background:
    Given I have access to the File Sharing API

Scenario Outline: Remove access for a specific member
    When I send a POST request to /api/FileSharing/remove-selected with email "<Email>", entityNo "<EntityNo>", and template "<Template>"
    Then the API response should be: "<StatusCode>"
Examples:
    | Email                  | EntityNo | Template          | StatusCode |
    | valid@example.com      | 12345    | ValidTemplate     | 200        |
    | invalid@example.com    | 12345    | ValidTemplate     | 400        |
    | valid@example.com      | 00000    | InvalidTemplate   | 400        |
    | valid@example.com      | 12345    |                   | 400        |
    |                        | 12345    | ValidTemplate     | 400        |
    | valid@example.com      |         | ValidTemplate     | 400        |
    | valid@example.com      | 12345    | ValidTemplate     | 500        |