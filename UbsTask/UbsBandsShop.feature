Feature: UbsBandsShop

Scenario Outline: Adding bands to the cart

Given I am on TogetherBand page
When I buy <bandSize> No Poverty band
Then I can see shopping cart opened
And there is <bandSize> No Poverty band added to the cart

Examples:
 | bandSize |
 | classic  |
 | mini     |

Scenario Outline: Bands price calculation

Given I am on TogetherBand page
And I set <currency> currency
And I buy classic No Poverty band
And I can see total price is <firstValue>
When I add one more band in the Cart
Then I can see total price is updated to <secondValue>

Examples:
 | currency | firstValue | secondValue |
 | USD      | $45        | $90         |
 | EUR      | €40        | €80         |

Scenario: Removing all items from cart

Given I am on TogetherBand page
And I buy classic No Poverty band
And there is classic No Poverty band added to the cart
When I click remove all optiion
Then I can see cart is empty


