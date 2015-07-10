using System;
using System.Collections.Generic;

namespace TeratailApiClient.Data
{
    /// <summary>
    /// タグ一覧
    /// </summary>
    public class TagList
    {
        /// <summary>
        /// メタ情報
        /// </summary>
        public MetaPage Meta { get; set; }
        
        /// <summary>
        /// タグ一覧
        /// </summary>
        public List<Tag> Tags { get; set; }
    }

    /// <summary>
    /// タグ情報
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// タグ名
        /// </summary>
        public string TagName { get; set; }
        
        /// <summary>
        /// タグの説明文
        /// </summary>
        public string Explain { get; set; }
        
        /// <summary>
        /// タグ登録日
        /// </summary>
        public DateTime Created { get; set; }
    }

    /// <summary>
    /// タグ指定質問一覧
    /// </summary>
    public class TagQuestionList
    {
        /// <summary>
        /// メタ情報
        /// </summary>
        public MetaPage Meta { get; set; }
        
        /// <summary>
        /// 指定タグ
        /// </summary>
        public Tag Tag { get; set; }
        
        /// <summary>
        /// 質問一覧
        /// </summary>
        public List<QuestionBase> Questions { get; set; }
    }
}
