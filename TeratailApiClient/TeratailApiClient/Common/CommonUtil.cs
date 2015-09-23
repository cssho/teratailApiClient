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
        /// <param name="query">検索文字列</param>
        /// <returns>取得結果</returns>
        internal static T GetQuery<T>(Uri uri, string token, int? limit = null, int? page = null, string query = null) where T : class
        {
            // ページネーション情報を保持している場合、パラメータに設定
            var param = new NameValueCollection();
            if (limit.HasValue)
                param.Add("limit", limit.Value.ToString());
            if (page.HasValue)
                param.Add("page", page.Value.ToString());
            if (query != null)
                param.Add("q", query);

            using (var client = new WebClient())
            {
                // アクセストークンを保持している場合、ヘッダに設定
                if (!string.IsNullOrEmpty(token))
                    client.Headers.Add("Authorization", "Bearer " + token);

                client.QueryString = param;

                var result = client.DownloadString(Uri.EscapeUriString(uri.ToString()));
                return JsonUtil.JsonDeserialize<T>(result);
            }
        }
    }
}
