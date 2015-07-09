using System;

namespace TeratailApiClient.Data
{
    /// <summary>
    /// 獲得バッジ
    /// </summary>
    public class Badge
    {
        /// <summary>
        /// バッジレベル
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 獲得日
        /// </summary>
        public DateTime AquiredDate { get; set; }
    }
}
