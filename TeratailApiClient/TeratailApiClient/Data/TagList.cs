using System;
using System.Collections.Generic;

namespace TeratailApiClient.Data
{
    /// <summary>
    /// タグ一覧
    /// </summary>
    public class TagList
    {
        public MetaPage Meta { get; set; }
        public List<Tag> Tags { get; set; }
    }

    /// <summary>
    /// タグ
    /// </summary>
    public class Tag
    {
        public string TagName { get; set; }
        public string Explain { get; set; }
        public DateTime Created { get; set; }
    }

    /// <summary>
    /// タグ指定質問一覧
    /// </summary>
    public class TagQuestionList
    {
        public MetaPage Meta { get; set; }
        public Tag Tag { get; set; }
        public List<QuestionBase> Questions { get; set; }
    }
}
