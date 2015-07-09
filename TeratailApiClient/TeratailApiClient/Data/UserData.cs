using System;
using System.Collections.Generic;

namespace TeratailApiClient.Data
{
    /// <summary>
    /// ユーザ詳細
    /// </summary>
    public class UserDetail
    {
        public User User { get; set; }
        public Meta Meta { get; set; }
    }

    /// <summary>
    /// ユーザ一覧
    /// </summary>
    public class UserList
    {
        public List<UserBase> Users { get; set; }
        public MetaPage Meta { get; set; }
    }

    /// <summary>
    /// ユーザ基本情報
    /// </summary>
    public class UserBase
    {
        public string DisplayName { get; set; }
        public string Photo { get; set; }
        public int Score { get; set; }
    }

    /// <summary>
    /// ユーザ情報
    /// </summary>
    public class User : UserBase
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Department { get; set; }
        public string Prefecture { get; set; }
        public string SelfInfo { get; set; }
        public string Blog { get; set; }
        public ScoreRanking ScoreRanking { get; set; }
        public List<string> Tags { get; set; }
        public Dictionary<string, string> Sns { get; set; }
        public Dictionary<string, Badge> Badges { get; set; }
    }

}
