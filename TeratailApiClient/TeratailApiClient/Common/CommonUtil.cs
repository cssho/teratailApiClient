using System;
using System.Collections.Specialized;
using System.Net;

namespace TeratailApiClient.Common
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
        internal static T GetQuery<T>(Uri uri, string token, int? limit = null, int? page = null) where T : class
        {
            var param = new NameValueCollection();
            if (limit.HasValue)
                param.Add("limit", limit.Value.ToString());
            if (page.HasValue)
                param.Add("page", page.Value.ToString());

            using (var client = new WebClient())
            {
                if (!string.IsNullOrEmpty(token))
                    client.Headers.Add("Authorization", "Bearer " + token);
                client.QueryString = param;

                var result = client.DownloadString(Uri.EscapeUriString(uri.ToString()));
                return JsonUtil.JsonDeserialize<T>(result);
            }
        }
    }
}
