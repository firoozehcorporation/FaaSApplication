using System.Threading.Tasks;
using FiroozehGameServiceFaaS;

namespace FaaSApplication
{
    internal static class Program
    {
        public static void Main()
        {
            GameServiceFaaS.ConfigureFaaS($"faaS_Token");

            GameServiceFaaS.RegisterFunction<Models.Hello.Request
                , Models.Hello.Response>(SayHello);
            
            GameServiceFaaS.RegisterFunction<Models.GetAllAchievement.Request
                , Models.GetAllAchievement.Response>(GetAllAchievements);

            GameServiceFaaS.Run(false);
        }
        
        
        private static async Task<Models.Hello.Response> SayHello(Models.Hello.Request request)
        {
            return new Models.Hello.Response
            {
                Output = "Hello " + request.Name
            };
        }
        
        private static async Task<Models.GetAllAchievement.Response> GetAllAchievements(Models.GetAllAchievement.Request request)
        {
            var achievements = await GameServiceFaaS.Achievement.GetAchievements();
          
            return new Models.GetAllAchievement.Response
            {
                Achievements = achievements
            };
        }
    }
}
