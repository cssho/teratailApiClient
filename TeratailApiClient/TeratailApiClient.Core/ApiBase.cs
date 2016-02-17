using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeratailApiClient.Core
{
    public abstract class ApiBase
    {
        /// <summary>
        /// ベースURL
        /// </summary>
        protected static readonly Uri baseUri = new Uri("https://teratail.com/api/v1/");

        // 各エンドポイントパス
        protected static readonly string questionPath = "questions";
        protected static readonly string userPath = "users";
        protected static readonly string clipPath = "clips";
        protected static readonly string tagPath = "tags";
        protected static readonly string replyPath = "replies";
        protected static readonly string followerPath = "followers";
        protected static readonly string followingPath = "followings";
        protected static readonly string searchPath = "search";

        /// <summary>
        /// アクセストークン
        /// https://teratail.com/users/setting/tokens
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ApiBase()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="token">アクセストークン</param>
        public ApiBase(string token)
            : this()
        {
            AccessToken = token;
        }
    }
}
