using System.Net;
using PurgoMalumTests.API;
using PurgoMalumTests.DTO;
using PurgoMalumTests.utils;
using RestSharp;
using Xunit;

namespace PurgoMalumTests.Steps;

[Binding]
public class ProfanityFilterSteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly IPurgoMalumApi _purgoMalumApi;
    private readonly Utils _utils;

    public ProfanityFilterSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _purgoMalumApi = new PurgoMalumApi(scenarioContext);
        _utils = new Utils();
    }

    [When(@"I make a '(.*)' request with text as '(.*)'")]
    public void WhenIMakeTheRequestWithAboveData(string contentType, string input)
    {
        var response = _purgoMalumApi.GetResponseAsync(contentType, input).Result;
        _scenarioContext.Add("response", response);
    }

    [Then(@"the response should be '(.*)' as '(.*)'")]
    public void ThenTheResultTextShouldBeFiltered(string contentType, string expected)
    {
        var response = _scenarioContext.Get<RestResponse>("response");
        var profanityResponse = Utils.GetResponseBasedOnContentTypeAsync<ProfanityResponse>(contentType, response);
        Assert.Equal(expected, profanityResponse.Result.Result);
    }

    [When(@"I make a '(.*)' request with the text as '(.*)' and the replacement as '(.*)'")]
    public void WhenIMakeARequestWithTheTitleAsAndTheDescriptionAs(string contentType, string text, string replacement)
    {
        var response = _purgoMalumApi.GetResponseAsync(contentType, text, replacement).Result;
        _scenarioContext.Add("response", response);
    }

    [Then(@"the request should respond with '(.*)' error as '(.*)'")]
    public void ThenTheRequestShouldRespondWithErrorAs(string contentType, string expectedError)
    {
        var response = _scenarioContext.Get<RestResponse>("response");
        var actualError = Utils.GetResponseBasedOnContentTypeAsync<ErrorResponse>(contentType, response);
        Assert.Equal(expectedError, actualError.Result.Error);
    }

    [When(@"I make a ""(.*)"" request with text as ""(.*)"" and add ""(.*)"" by replacing chars as ""(.*)""")]
    public void WhenIMakeARequestWithTextAsAndAddByReplacingCharsAs(string contentType, string text, string add,
        string replacement)
    {
        var response = _purgoMalumApi.GetResponseAsync(contentType, text, add, replacement).Result;
        _scenarioContext.Add("response", response);
    }

    [When(@"I verify the status code should be '(.*)'")]
    public void WhenIVerifyTheStatusCodeShouldBe(string statusCode)
    {
        var response = _scenarioContext.Get<RestResponse>("response");
        switch (statusCode)
        {
            case "200": Assert.True(response.StatusCode == HttpStatusCode.OK);
                break;
            
            case "400": Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
                break;
        }

    }
}