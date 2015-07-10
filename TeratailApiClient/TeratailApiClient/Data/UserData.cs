using System;
using System.Collections.Generic;

namespace TeratailApiClient.Data
{
    /// <summary>
    /// ユーザ詳細
    /// </summary>
    public class UserDetail
    {
        /// <summary>
        /// ユーザ情報
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// メタ情報
        /// </summary>
        public Meta Meta { get; set; }
    }

    /// <summary>
    /// ユーザ一覧
    /// </summary>
    public class UserList
    {
        /// <summary>
        /// ユーザ一覧
        /// </summary>
        public List<UserBase> Users { get; set; }

        /// <summary>
        /// メタ情報
        /// </summary>
        public MetaPage Meta { get; set; }
    }

    /// <summary>
    /// ユーザ基本情報
    /// </summary>
    public class UserBase
    {
        /// <summary>
        /// ユーザー名
        /// </summary>
        public string DisplayName { get; set; }
        
        /// <summary>
        /// アイコンのURL
        /// </summary>
        public string Photo { get; set; }
        
        /// <summary>
        /// ユーザーの獲得スコア
        /// </summary>
        public int Score { get; set; }
    }

    /// <summary>
    /// ユーザ情報
    /// </summary>
    public class User : UserBase
    {
        /// <summary>
        /// 会員登録日
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// ユーザー情報最終変更日
        /// </summary>
        public DateTime Modified { get; set; }

        /// <summary>
        /// 所属
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 居住地（都道府県）
        /// </summary>
        public string Prefecture { get; set; }

        /// <summary>
        /// 自己紹介
        /// </summary>
        public string SelfInfo { get; set; }

        /// <summary>
        /// サイト・ブログ
        /// </summary>
        public string Blog { get; set; }

        /// <summary>
        /// スコアランキング
        /// </summary>
        public ScoreRanking ScoreRanking { get; set; }

        /// <summary>
        /// タグ一覧
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// プロフィールに結びついているSNS一覧
        /// </summary>
        public Dictionary<string, string> Sns { get; set; }

        /// <summary>
        /// 獲得バッジ一覧
        /// </summary>
        public Dictionary<string, Badge> Badges { get; set; }
    }

}
