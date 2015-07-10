using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeratailApiClient.Data
{
    /// <summary>
    /// 回答一覧
    /// </summary>
    public class ReplyList
    {
        /// <summary>
        /// メタ情報
        /// </summary>
        public MetaPage Meta { get; set; }

        /// <summary>
        /// 回答一覧
        /// </summary>
        public List<Reply> Replies { get; set; }
    }

    /// <summary>
    /// 回答
    /// </summary>
    public class Reply
    {
        /// <summary>
        /// 回答の本文（Markdown記法）
        /// </summary>
        public string Body { get; set; }
        
        /// <summary>
        /// 回答の本文（HTML記法）
        /// </summary>
        public string BodyStr { get; set; }
        
        /// <summary>
        /// 回答の投稿日
        /// </summary>
        public string Created { get; set; }
        
        /// <summary>
        /// 回答の最終更新日
        /// </summary>
        public string Modified { get; set; }
        
        /// <summary>
        /// ベストアンサーかどうか
        /// </summary>
        public bool IsBestAnser { get; set; }
        
        /// <summary>
        /// 回答投稿ユーザーオブジェクト
        /// </summary>
        public User User { get; set; }
    }
}
