@ignore
Feature: Etsy Cart Functionality
	In order to show the basic cart functionality
	As a user
	I want to add and remove items from the cart

Scenario: Item can be added to then removed from cart
	Given I am on the Etsy cart page
	And that the cart is empty
	When an item is added to the cart
    Then the cart contains that item
	When I remove the item from the cart
	Then the cart is empty