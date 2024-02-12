# Rest API Test Automation using .Net 8, RestSharp and Cucumber

## Steps to run Tests
* Clone the repo
* Change directory `cd RestSharp-DotNet-API-Tests/PurgoMalumTests`
* Run `dotnet test`

## Tech Stack
* .Net 8(C#), RestSharp, SpecFlow.Xunit

## Tests
* Added Tests for /xml and /json API endpoints
* The scenarios designed could be used to create more functional test cases by parameterizing them without additional code

## Improvements to be made
* To be able to Run the tests for various environments by setting env variables
* Add DI for API Clients for increased maintainability and readability of the test suite
