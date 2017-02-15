using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TweetSharp;

namespace DiceRollTweet
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new TwitterService(System.Configuration.ConfigurationManager.AppSettings["consumer"],
                                            System.Configuration.ConfigurationManager.AppSettings["consumerSecret"]);
            service.AuthenticateWith(System.Configuration.ConfigurationManager.AppSettings["token"],
                                            System.Configuration.ConfigurationManager.AppSettings["tokenSecret"]);
            while (true)
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 100);
                string str = String.Format("D4 : {0} \n" +
                                            "D6 : {1} \n" +
                                            "D8 : {2} \n" +
                                            "D12 : {3} \n" +
                                            "D20 : {4} \n",
                                            random.Next(0, 4) + 1,
                                            random.Next(0, 6) + 1,
                                            random.Next(0, 8) + 1,
                                            random.Next(0, 12) + 1,
                                            random.Next(0, 20) + 1);
                Console.WriteLine(str);

                TwitterStatus result = service.SendTweet(new SendTweetOptions
                {
                    Status = str
                });
                Console.WriteLine(DateTime.Now.ToString() + "Tweet sent");
                Thread.Sleep(120000);
            }
        }
    }
}
