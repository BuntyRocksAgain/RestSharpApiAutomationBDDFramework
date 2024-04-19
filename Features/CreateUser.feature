Feature: Create a New User

Create a new user

//@Order1
Scenario: Create a new user with valid inputs
	Given user with name "Raj"
	When user with job "leader"
	When user send request to createuser by sending URL as "https://reqres.in/" and "Payload"
	Then validate user is created
