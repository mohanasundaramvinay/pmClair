Feature: Vendor Known Check

Background:
    Given I have access to the vendor API

Scenario Outline: Check if a vendor is known
    When I send a GET request to /api/vendor/known-vendors/check with partNo="<PartNo>", vendNo="<VendNo>", siteNo="<SiteNo>"
    Then the API response should be: <IsKnown>
Examples:
    | PartNo | VendNo | SiteNo | IsKnown |
    | 12345  | 67890  | 001    | true    |
    | 12345  | 67891  | 001    | false   |
    | 00000  | 00000  | 000    | false   |
    | 99999  | 99999  | 999    | false   |
    | 12345  | 67890  | 002    | false   |
    | 54321  | 09876  | 001    | false   |
    | 12345  | 67890  | 001    | true    |
    | 11111  | 22222  | 333    | false   |
    | 12345  | 67890  | 003    | false   |
    | 12345  | 67892  | 001    | false   |
    | 12345  | 67890  | 004    | false   |
    | 12345  | 67893  | 001    | false   |