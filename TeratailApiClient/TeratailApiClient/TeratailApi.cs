using System;
using TeratailApiClient.Common;
using TeratailApiClient.Data;

namespace TeratailApiClient
{
    /// <summary>
    /// teratail API Client
    /// </summary>
    public class TeratailApi
    {
        /// <summary>
        /// ベースURL
        /// </summary>
        private static readonly Uri baseUri = new Uri("https://teratail.com/api/v1/");

        // 各エンドポイントパス
        private static readonly string questionPath = "questions";
        private static readonly string userPath = "users";
        private static readonly string clipPath = "clips";
        private static readonly string tagPath = "tags";
        private static readonly string replyPath = "replies";
        private static readonly string followerPath = "followers";
        private static readonly string followingPath = "followings";

        /// <summary>
        /// アクセストークン
        /// https://teratail.com/users/setting/tokens
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TeratailApi()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="token">アクセストークン</param>
        public TeratailApi(string token)
            : this()
        {
            AccessToken = token;
        }

        /// <summary>
        /// 質問の一覧を返します。
        /// </summary>
        /// <param name="limit">1ページあたりの表示件数</param>
        /// <param name="page">ページ番号</param>
        /// <returns>質問の一覧</returns>
        public QuestionList GetQuestionList(int? limit = null, int? page = null)
        {
            return CommonUtil.GetQuery<QuestionList>(new Uri(baseUri, questionPath), AccessToken, limit, page);
        }

        /// <summary>
        /// questionIdで指定された質問を返します。
        /// </summary>
        /// <param name="questionId">正の整数で表される質問ID</param>
        /// <returns>質問詳細とその回答</returns>
        public QuestionDetail GetQuestionDetail(int questionId)
        {
            return CommonUtil.GetQuery<QuestionDetail>(
                new Uri(baseUri, string.Join(@"/", questionPath, questionId)), AccessToken);
        }

        /// <summary>
        /// displayNameで指定したユーザーの情報を返します。
        /// </summary>
        /// <param name="displayName">teratailユーザー名</param>
        /// <returns>ユーザーの情報</returns>
        public UserDetail GetUserDetail(string displayName)
        {
            return CommonUtil.GetQuery<UserDetail>(
                new Uri(baseUri, string.Join(@"/", userPath, Uri.EscapeDataString(displayName))), AccessToken);
        }

        /// <summary>
        /// displayNameで指定したユーザーがクリップした質問一覧を返します。
        /// </summary>
        /// <param name="displayName">teratailユーザー名</param>
        /// <param name="limit">1ページあたりの表示件数</param>
        /// <param name="page">ページ番号</param>
        /// <returns>クリップした質問一覧</returns>
        public QuestionList GetUserClipList(string displayName, int? limit = null, int? page = null)
        {
            return CommonUtil.GetQuery<QuestionList>(
                new Uri(baseUri, string.Join(@"/", userPath, Uri.EscapeDataString(displayName), clipPath)), AccessToken, limit, page);
        }

        /// <summary>
        /// displayNameで指定したユーザーのMyタグの一覧を返します。
        /// </summary>
        /// <param name="displayName">teratailユーザー名</param>
        /// <param name="limit">1ページあたりの表示件数</param>
        /// <param name="page">ページ番号</param>
        /// <returns>Myタグの一覧</returns>
        public TagList GetUserTagList(string displayName, int? limit = null, int? page = null)
        {
            return CommonUtil.GetQuery<TagList>(
                new Uri(baseUri, string.Join(@"/", userPath, Uri.EscapeDataString(displayName), tagPath)), AccessToken, limit, page);
        }

        /// <summary>
        /// displayNameで指定したユーザーの投稿した質問の一覧を返します。
        /// </summary>
        /// <param name="displayName">teratailユーザー名</param>
        /// <param name="limit">1ページあたりの表示件数</param>
        /// <param name="page">ページ番号</param>
        /// <returns></returns>
        public QuestionList GetUserQuestionList(string displayName, int? limit = null, int? page = null)
        {
            return CommonUtil.GetQuery<QuestionList>(
                new Uri(baseUri, string.Join(@"/", userPath, Uri.EscapeDataString(displayName), questionPath)), AccessToken, limit, page);
        }

        /// <summary>
        /// displayNameで指定したユーザーの回答の一覧を返します。
        /// </summary>
        /// <param name="displayName">teratailユーザー名</param>
        /// <param name="limit">1ページあたりの表示件数</param>
        /// <param name="page">ページ番号</param>
        /// <returns>回答の一覧</returns>
        public ReplyList GetUserReplyList(string displayName, int? limit = null, int? page = null)
        {
            return CommonUtil.GetQuery<ReplyList>(
                new Uri(baseUri, string.Join(@"/", userPath, Uri.EscapeDataString(displayName), replyPath)), AccessToken, limit, page);
        }

        /// <summary>
        /// displayNameで指定したユーザーのフォロワーの一覧を返します。
        /// </summary>
        /// <param name="displayName">teratailユーザー名</param>
        /// <param name="limit">1ページあたりの表示件数</param>
        /// <param name="page">ページ番号</param>
        /// <returns>フォロワーの一覧</returns>
        public UserList GetUserFollowerList(string displayName, int? limit = null, int? page = null)
        {
            return CommonUtil.GetQuery<UserList>(
                new Uri(baseUri, string.Join(@"/", userPath, Uri.EscapeDataString(displayName), followerPath)), AccessToken, limit, page);
        }

        /// <summary>
        /// displayNameで指定したユーザーのフォローしているユーザーの一覧を返します。
        /// </summary>
        /// <param name="displayName">teratailユーザー名</param>
        /// <param name="limit">1ページあたりの表示件数</param>
        /// <param name="page">ページ番号</param>
        /// <returns>フォローしているユーザーの一覧</returns>
        public UserList GetUserFollowingList(string displayName, int? limit = null, int? page = null)
        {
            return CommonUtil.GetQuery<UserList>(
                new Uri(baseUri, string.Join(@"/", userPath, Uri.EscapeDataString(displayName), followingPath)), AccessToken, limit, page);
        }

        /// <summary>
        /// タグの一覧を返します。
        /// </summary>
        /// <param name="limit">1ページあたりの表示件数</param>
        /// <param name="page">ページ番号</param>
        /// <returns>タグの一覧</returns>
        public TagList GetTagList(int? limit = null, int? page = null)
        {
            return CommonUtil.GetQuery<TagList>(
                new Uri(baseUri, tagPath), AccessToken);
        }

        /// <summary>
        /// tagNameで指定したタグを持つ質問一覧を返します。
        /// </summary>
        /// <param name="tagName">タグ名</param>
        /// <param name="limit">1ページあたりの表示件数</param>
        /// <param name="page">ページ番号</param>
        /// <returns>質問一覧</returns>
        public TagQuestionList GetTagQuestionList(string tagName, int? limit = null, int? page = null)
        {
            return CommonUtil.GetQuery<TagQuestionList>(
                new Uri(baseUri, string.Join(@"/", tagPath, Uri.EscapeDataString(tagName), questionPath)), AccessToken, limit, page);
        }
    }
}
