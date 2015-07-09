using Newtonsoft.Json;

namespace TeratailApiClient.Common
{
    static class JsonUtil
    {
        /// <summary>
        /// Serialize設定
        /// </summary>
        private static readonly JsonSerializerSettings jSetting;

        /// <summary>
        /// 静的コンストラクタ
        /// </summary>
        static JsonUtil()
        {
            jSetting = new JsonSerializerSettings() { ContractResolver = new SnakeCaseContractResolver() };
        }

        /// <summary>
        /// JSONデシリアライズ
        /// </summary>
        /// <typeparam name="T">結果を格納する型</typeparam>
        /// <param name="json">JSON文字列</param>
        /// <returns>デシリアライズ結果</returns>
        internal static T JsonDeserialize<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json, jSetting);
        }
    }
}
