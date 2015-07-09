
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
        public int TotalPage { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
        public int HitNum { get; set; }
        public bool HasNext { get { return TotalPage > Page; } }
    }
}
