using System;
using TeratailApiClient.Async;
using TeratailApiClient.Data;
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

            // 10件ずつGitHubタグの付いた質問をリストアップ
            int page = 1;
            int limit = 10;
            var meta = ListUpTag(tera, page, limit);
            while (meta.TotalPage > page)
            {
                Console.WriteLine("====================");
                page++;
                meta = ListUpTag(tera, page, limit);
            }
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
