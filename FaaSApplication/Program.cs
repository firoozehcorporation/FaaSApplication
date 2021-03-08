using System;
using System.Threading.Tasks;
using FiroozehGameServiceFaaS;
using FluentScheduler;

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
            
            JobManager.AddJob(TestScheduleFunction, s => s.ToRunEvery(10).Seconds());
            
            GameServiceFaaS.Run();
        }


        private static void TestScheduleFunction()
        {
            Console.WriteLine("Called After 10 secs");
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
