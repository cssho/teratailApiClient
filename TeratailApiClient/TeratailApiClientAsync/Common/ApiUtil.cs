using TeratailApiClientAsync.Data;
namespace TeratailApiClientAsync.Common
{
    /// <summary>
    /// APIユーティリティ
    /// </summary>
    public static class ApiUtil
    {
        /// <summary>
        /// ページネーションに対応したエンドポイントにおいて次ページが存在するかしないか
        /// </summary>
        /// <param name="page">ページネーション対応メタ情報</param>
        /// <returns>次ページが存在するなら真</returns>
        public static bool HasNext(this MetaPage page)
        {
            return page.TotalPage > page.Page;
        }

        /// <summary>
        /// ページネーションに対応したエンドポイントにおいて前ページが存在するかしないか
        /// </summary>
        /// <param name="page">ページネーション対応メタ情報</param>
        /// <returns>前ページが存在するなら真</returns>
        public static bool HasPrev(this MetaPage page)
        {
            return 1 < page.Page;
        }
    }
}
