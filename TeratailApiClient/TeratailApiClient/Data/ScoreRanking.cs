
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
        public int Rank { get; set; }
        public int MaxRanking { get; set; }
        public int Score { get; set; }
    }

}
