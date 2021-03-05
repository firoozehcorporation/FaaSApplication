using FiroozehGameServiceFaaS.Models;
using Newtonsoft.Json;

namespace FaaSApplication.Models.Hello
{
    public class Request : FaaSRequest
    {
        [JsonProperty("name")] public string Name;
    }
}