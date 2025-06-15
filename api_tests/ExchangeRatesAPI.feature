Feature: Exchange Rates API

Background:
    Given the Exchange Rates API is running

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

Scenario Outline: Validate exchange rate data structure
    When I send a GET request to /api/lookup/exchange-rates
    Then each exchange rate should have a CurrencyCode, ExchangeRate, and LastUpdated
Examples:
    | StatusCode |
    | 200        |