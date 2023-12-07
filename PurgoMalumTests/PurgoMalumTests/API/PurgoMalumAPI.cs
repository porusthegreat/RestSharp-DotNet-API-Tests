using RestSharp;

namespace PurgoMalumTests.API;

public class PurgoMalumApi : IPurgoMalumApi, IDisposable
{
    private readonly RestClient _client;

    public PurgoMalumApi(ScenarioContext scenarioContext)
    {
        var options = new RestClientOptions()
        {
            BaseUrl = new Uri("https://www.purgomalum.com/service")
        };
        
        _client = new RestClient(options);
    }

    public async Task<RestResponse> GetResponseAsync(string contentType, string input)
    {
        var request = new RestRequest("/" + contentType)
            .AddParameter("text", input);
        
        return await _client.GetAsync(request);
    }
    
    public async Task<RestResponse> GetResponseAsync(string contentType, string input, string fillText)
    {

        var args = new
        {
            text = input,
            fill_text = fillText
        };
        
        var request = new RestRequest("/" + contentType)
            .AddObject(args);
        
        return await _client.GetAsync(request);
    }

    public async Task<RestResponse> GetResponseAsync(string contentType, string input, string additionalWords, string fillChar)
    {
        var args = new
        {
            text = input,
            fill_char = fillChar,
            add = additionalWords
        };
        
        var request = new RestRequest("/" + contentType)
            .AddObject(args);
        
        return await _client.GetAsync(request);
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}