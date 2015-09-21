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
        /// <returns>取得結果</returns>
        internal static async Task<T> GetQuery<T>(Uri uri, string token, int? limit = null, int? page = null) where T : class
        {
            // ページネーション情報を保持している場合、パラメータに設定
            var param = new NameValueCollection();
            if (limit.HasValue)
                param.Add("limit", limit.Value.ToString());
            if (page.HasValue)
                param.Add("page", page.Value.ToString());

            using (var client = new HttpClient())
            {
                // アクセストークンを保持している場合、ヘッダに設定
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var builder = CreateUri(uri, limit, page);

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
        /// <returns>アクセス先</returns>
        private static UriBuilder CreateUri(Uri uri, int? limit, int? page)
        {
            var builder = new UriBuilder(uri);
            var query = HttpUtility.ParseQueryString(builder.Query);
            if (limit.HasValue)
                query["limit"] = limit.Value.ToString();
            if (page.HasValue)
                query["page"] = page.Value.ToString();

            builder.Query = query.ToString();
            return builder;
        }
    }
}
