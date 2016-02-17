
namespace TeratailApiClient.Data
{
    /// <summary>
    /// メタ情報
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// 通信の状態
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// ページネーション対応メタ情報
    /// </summary>
    public class MetaPage : Meta
    {
        /// <summary>
        /// 全ページ数
        /// </summary>
        public int TotalPage { get; set; }

        /// <summary>
        /// ページ番号
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 1ページあたりの表示件数
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// このエンドポイントから取得可能な全てのデータの件数
        /// </summary>
        public int HitNum { get; set; }

    }
}
