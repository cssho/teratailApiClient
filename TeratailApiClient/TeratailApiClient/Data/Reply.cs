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
        public MetaPage Meta { get; set; }
        public List<Reply> Replies { get; set; }
    }

    /// <summary>
    /// 回答
    /// </summary>
    public class Reply
    {
        public string Body { get; set; }
        public string BodyStr { get; set; }
        public string Created { get; set; }
        public string Modified { get; set; }
        public bool IsBestAnser { get; set; }
        public User User { get; set; }
    }
}
