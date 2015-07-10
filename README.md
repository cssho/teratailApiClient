# teratailApiClient
.NET teratail API Client Library

## teratail
[teratail](https://teratail.com/)
> teratailは、日本のエンジニアが集うQ&Aコミュニティサイトです。

## teratail API
[teratail API](https://teratail.com/api)
> teratail APIは、teratailで使われている質問や回答、ユーザー、タグなどの情報を利用するためのWeb APIです。

## Sample
```csharp
using System;
using TeratailApiClient;
using TeratailApiClient.Common;
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

            // 10件ずつGitHubタグの付いた質問をリストアップ
            int page = 1;
            int limit = 10;
            var meta =  ListUpTag(tera, page, limit);
            while (meta.HasNext())
            {
                Console.WriteLine("====================");
                page++;
                meta = ListUpTag(tera, page, limit);
            }
            Console.ReadKey();
        }

        private static MetaPage ListUpTag(TeratailApi tera, int page, int limit)
        {
            var tagq = tera.GetTagQuestionList(tagGitHub, limit, page);
            tera.GetTagQuestionList(tagGitHub, limit, page).Questions.ForEach(x =>
            {
                Console.WriteLine(x.Title);
                Console.WriteLine(x.User.DisplayName);
            });
            return tagq.Meta;
        }

    }
}

```
## TODO
非同期対応