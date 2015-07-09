using System;
using System.Collections.Generic;

namespace TeratailApiClient.Data
{
    /// <summary>
    /// 質問一覧
    /// </summary>
    public class QuestionList
    {
        public List<QuestionSimple> Questions { get; set; }
        public MetaPage Meta { get; set; }
    }

    /// <summary>
    /// 質問詳細・回答
    /// </summary>
    public class QuestionDetail
    {
        public Question Question { get; set; }
        public Meta Meta { get; set; }
    }

    /// <summary>
    /// 質問詳細情報
    /// </summary>
    public class Question : QuestionSimple
    {
        public List<Reply> Replies { get; set; }
    }

    /// <summary>
    /// 質問情報
    /// </summary>
    public class QuestionBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int CountReply { get; set; }
        public int CountClip { get; set; }
        public int CountPv { get; set; }
        public bool IsBeginner { get; set; }
        public bool IsAccepted { get; set; }
        public List<string> Tags { get; set; }
        public UserBase User { get; set; }
    }

    /// <summary>
    /// 質問情報本文あり
    /// </summary>
    public class QuestionSimple : QuestionBase
    {
        public string Body { get; set; }
        public string BodyStr { get; set; }
    }
}
