Feature: Hotel search

Scenario Outline: Search for a hotel and verify rating
    Given the user is on the Booking search page
    When the user searches for "<hotel>"
    Then the hotel "<hotel>" should be displayed
    And the hotel rating should be "<rating>"

Examples:
    | hotel                    | rating |
    | Marriott Marquis Houston | 8.5    |
    | Hilton Strasbourg        | 7.9    |
    | Hotel Suisse             | 8.3    |