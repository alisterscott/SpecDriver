Feature: Etsy Advanced Search Functionality
	In order to show the advanced search functionality
	As a user
	I want to search for an item in a sub category

Scenario Outline: Advanced Search for items in various categories that exist and don't exist
	Given I am searching on Etsy.com
	When I specify the <Sub Category> sub category
	And I search for <Search Term>
	Then I should see <Search Results> search results for <Search Term>
Examples:
	| Sub Category | Search Term  | Search Results |
	| Knitting     | 'hat'        | some           |
	| Jewelry      | 'necklace'   | some           |
	| Jewelry      | 'specdriver' | no             |

Scenario: Misspelling a word corrects search automatically
	Given I am searching on Etsy.com
	When I specify the Knitting sub category
	And I search for 'scalf'
	Then I should see some search results for 'scarf'
	And I should see that the search was for 'scarf' instead of 'scalf'