using System.Text.Json;
using RestSharp;
using RestSharp.Serializers.Xml;

namespace PurgoMalumTests.utils;

public class Utils
{
    public static Task<T> GetResponseBasedOnContentTypeAsync<T>(string contentType, RestResponse response)
    {
        if (!contentType.Equals("xml"))
            return Task.FromResult(JsonSerializer.Deserialize<T>(response.Content!)!);

        var deserializer = new XmlDeserializer();
        return Task.FromResult(deserializer.Deserialize<T>(response)!);
    }
}