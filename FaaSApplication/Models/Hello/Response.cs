using FiroozehGameServiceFaaS.Models;
using Newtonsoft.Json;

namespace FaaSApplication.Models.Hello
{
    public class Response : FaaSResponse
    {
        [JsonProperty("output")] public string Output;
    }
}