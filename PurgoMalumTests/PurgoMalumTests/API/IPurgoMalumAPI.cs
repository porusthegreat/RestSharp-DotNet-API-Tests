using PurgoMalumTests.DTO;
using RestSharp;

namespace PurgoMalumTests.API;

public interface IPurgoMalumApi
{
    Task<RestResponse> GetResponseAsync(string contentType, string input);
    Task<RestResponse> GetResponseAsync(string contentType, string input, string fillText);
    Task<RestResponse> GetResponseAsync(string contentType, string input, string add, string fillChar);
}

