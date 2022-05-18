Feature: ShoppingCart

As a Customer
I should be able to collect products in a shopping cart
So that I can order several products at once



Scenario: I would try to add a product into shopping cart
	Given my shopping cart is empty
	When I add a product with name '<productName>' to cart
	Then my cart should contain 1 copy of '<productName>'
	
	Examples: 
	| productName   |
	| Shoniz Talayi |
	| Bykit         |


	Scenario Outline: I would try to add a duplicate product to my cart

	Given my shopping cart contains 1 copy of '<productName>' with '<beforeQuantity>' quantity
	When I add a '<productName>' to my cart
	Then my cart should contain 1 copy of '<productName>'
	But the quantity of '<productName>' should be '<afterQuantity>'

	Examples: 
	| productName   | beforeQuantity | afterQuantity |
	| Shoniz Talayi | 1              | 2             |
	| Bykit         | 3              | 4             |