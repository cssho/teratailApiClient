using System;
using System.Collections.Generic;

namespace TeratailApiClient.Data
{
    /// <summary>
    /// 質問一覧
    /// </summary>
    public class QuestionList
    {
        /// <summary>
        /// 質問リスト
        /// </summary>
        public List<QuestionSimple> Questions { get; set; }

        /// <summary>
        /// メタ情報
        /// </summary>
        public MetaPage Meta { get; set; }
    }

    /// <summary>
    /// 質問詳細・回答
    /// </summary>
    public class QuestionDetail
    {
        /// <summary>
        /// 質問詳細
        /// </summary>
        public Question Question { get; set; }

        /// <summary>
        /// メタ情報
        /// </summary>
        public Meta Meta { get; set; }
    }

    /// <summary>
    /// 質問詳細情報
    /// </summary>
    public class Question : QuestionSimple
    {
        /// <summary>
        /// 回答一覧
        /// </summary>
        public List<Reply> Replies { get; set; }
    }

    /// <summary>
    /// 質問情報
    /// </summary>
    public class QuestionBase
    {
        /// <summary>
        /// 質問ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 質問のタイトル
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 質問の投稿日
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// 質問の最終更新日
        /// </summary>
        public DateTime Modified { get; set; }
        
        /// <summary>
        /// 回答数
        /// </summary>
        public int CountReply { get; set; }
        
        /// <summary>
        /// クリップ数
        /// </summary>
        public int CountClip { get; set; }
        
        /// <summary>
        /// PV数
        /// </summary>
        public int CountPv { get; set; }
        
        /// <summary>
        /// 初心者マーク付きかどうか
        /// </summary>
        public bool IsBeginner { get; set; }
        
        /// <summary>
        /// ベストアンサーが付いているかどうか
        /// </summary>
        public bool IsAccepted { get; set; }
        
        /// <summary>
        /// 質問についたタグ一覧
        /// </summary>
        public List<string> Tags { get; set; }
        
        /// <summary>
        /// 質問投稿ユーザーオブジェクト
        /// </summary>
        public UserBase User { get; set; }
    }

    /// <summary>
    /// 質問情報本文あり
    /// </summary>
    public class QuestionSimple : QuestionBase
    {
        /// <summary>
        /// 質問の本文（Markdown記法）
        /// </summary>
        public string Body { get; set; }
        
        /// <summary>
        /// 質問の本文（HTML記法）
        /// </summary>
        public string BodyStr { get; set; }
    }
}
