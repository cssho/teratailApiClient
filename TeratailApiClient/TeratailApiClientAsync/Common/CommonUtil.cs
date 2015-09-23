using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace TeratailApiClientAsync.Common
{
    /// <summary>
    /// 共通クラス
    /// </summary>
    internal static class CommonUtil
    {
        /// <summary>
        /// データ取得
        /// </summary>
        /// <typeparam name="T">取得する型</typeparam>
        /// <param name="uri">URL</param>
        /// <param name="token">アクセストークン</param>
        /// <param name="limit">1ページあたりの表示件数</param>
        /// <param name="page">ページ番号</param>
        /// <param name="query">検索文字列</param>
        /// <returns>取得結果</returns>
        internal static async Task<T> GetQuery<T>(Uri uri, string token, int? limit = null, int? page = null, string query = null) where T : class
        {
            using (var client = new HttpClient())
            {
                // アクセストークンを保持している場合、ヘッダに設定
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var builder = CreateUri(uri, limit, page, query);

                var result = await client.GetStringAsync(builder.ToString());

                return JsonUtil.JsonDeserialize<T>(result);
            }
        }

        /// <summary>
        /// URLとパラメータを組み合わせアクセス先を生成
        /// </summary>
        /// <param name="uri">URL</param>
        /// <param name="limit">1ページあたりの表示件数</param>
        /// <param name="page">ページ番号</param>
        /// <param name="query">検索文字列</param>
        /// <returns>アクセス先</returns>
        private static UriBuilder CreateUri(Uri uri, int? limit, int? page, string searchQuery)
        {
            var builder = new UriBuilder(uri);
            var query = HttpUtility.ParseQueryString(builder.Query);

            if (limit.HasValue)
                query["limit"] = limit.Value.ToString();
            if (page.HasValue)
                query["page"] = page.Value.ToString();
            if (searchQuery != null)
                query["q"] = searchQuery;

            builder.Query = query.ToString();
            return builder;
        }
    }
}
