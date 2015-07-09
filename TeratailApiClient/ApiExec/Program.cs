using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeratailApiClient;
using Newtonsoft.Json;
using TeratailApiClient.Data;
namespace ApiExec
{
    class Program
    {
        static void Main(string[] args)
        {
            // アクセストークンを指定する場合
            // TeratailApi tera = new TeratailApi("hogeAccessToken");

            // アクセストークンを指定しない場合
            TeratailApi tera = new TeratailApi();

            int page = 1;
            int limit = 10;
            var tagq = tera.GetTagQuestionList("GitHub", limit, page);
            tagq.Questions.ForEach(x =>
            {
                Console.WriteLine(x.Title);
            });
            while (tagq.Meta.HasNext)
            {
                Console.WriteLine("====================");
                page++;
                tagq = tera.GetTagQuestionList("GitHub", limit, page);
                tagq.Questions.ForEach(x =>
                {
                    Console.WriteLine(x.Title);
                });
            }
            Console.ReadKey();
        }

    }
}
