using System.Collections.Generic;
using FiroozehGameServiceFaaS.Models;
using FiroozehGameServiceFaaS.Models.BasicApi;
using Newtonsoft.Json;

namespace FaaSApplication.Models.GetAllAchievement
{
    public class Response : FaaSResponse
    {
        [JsonProperty("achievements")] public List<Achievement> Achievements;
    }
}