Feature: Exchange Rates Retrieval

Background:
    Given the Lookup API is running

Scenario Outline: Retrieve exchange rates successfully
    When I send a GET request to /api/lookup/exchange-rates
    Then the API response should be a list of exchange rates with status code <StatusCode>
Examples:
    | StatusCode |
    | 200        |

Scenario Outline: Handle server error when retrieving exchange rates
    When I send a GET request to /api/lookup/exchange-rates
    Then the API response should be an error with status code <StatusCode>
Examples:
    | StatusCode |
    | 500        |