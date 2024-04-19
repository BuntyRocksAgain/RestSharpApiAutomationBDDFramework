Feature: Validate Data GetRequest

Verfy the Get Request API

@tag1
Scenario: Get Request Testing
	Given the user send the request with URL as "https://reqres.in/"
	Then the user should see the success statuscode
