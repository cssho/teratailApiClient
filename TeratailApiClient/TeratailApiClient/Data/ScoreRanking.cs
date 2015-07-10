
namespace TeratailApiClient.Data
{
    /// <summary>
    /// ランキング
    /// </summary>
    public class ScoreRanking
    {
        /// <summary>
        /// 総合ランキング
        /// </summary>
        public PeriodScore Total { get; set; }

        /// <summary>
        /// 週間ランキング
        /// </summary>
        public PeriodScore Weekly { get; set; }
    }

    /// <summary>
    /// 期間ランキング
    /// </summary>
    public class PeriodScore
    {
        /// <summary>
        /// ランキング順位
        /// </summary>
        public int Rank { get; set; }
        
        /// <summary>
        /// ランキング最高順位
        /// </summary>
        public int MaxRanking { get; set; }
        
        /// <summary>
        /// 獲得スコア
        /// </summary>
        public int Score { get; set; }
    }

}
