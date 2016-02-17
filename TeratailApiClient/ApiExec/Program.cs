using System;
using TeratailApiClientAsync;
using TeratailApiClientAsync.Common;
using TeratailApiClientAsync.Data;
namespace ApiExec
{
    class Program
    {
        private static readonly string tagGitHub = "GitHub";

        static void Main(string[] args)
        {
            // アクセストークンを指定する場合
            // TeratailApi tera = new TeratailApi("hogeAccessToken");

            // アクセストークンを指定しない場合
            TeratailApi tera = new TeratailApi();

            var result = tera.GetUserList().Result;
            Console.WriteLine(result.Users[0].DisplayName);
            result = tera.GetUserList("sho_cs").Result;
            Console.WriteLine(result.Users[0].DisplayName);
            Console.ReadKey();
        }

        private static MetaPage ListUpTag(TeratailApi tera, int page, int limit)
        {
            var tagq = tera.GetTagQuestionList(tagGitHub, limit, page).Result;
            tera.GetTagQuestionList(tagGitHub, limit, page).Result.Questions.ForEach(x =>
            {
                Console.WriteLine(x.Title);
                Console.WriteLine(x.User?.DisplayName);
                Console.WriteLine(x.IsPresentation);
            });
            return tagq.Meta;
        }

    }
}
