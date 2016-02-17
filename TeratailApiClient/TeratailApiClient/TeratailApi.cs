using System;
using System.Text.RegularExpressions;
using TeratailApiClient.Common;
using TeratailApiClient.Core;
using TeratailApiClient.Data;

namespace TeratailApiClient
{
    /// <summary>
    /// teratail API Client
    /// </summary>
    public class TeratailApi : ApiBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TeratailApi() : base() { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="token">アクセストークン</param>
        public TeratailApi(string token) : base(token) { }

        /// <summary>
        /// 質問の一覧を返します。
        /// </summary>
        /// <param name="limit">1ページあたりの表示件数</param>
        /// <param name="page">ページ番号</param>
        /// <returns>質問の一覧</returns>
        public QuestionList GetQuestionList(int? limit = null, int? page = null)
        {
            return Util.GetQuery<QuestionList>(new Uri(baseUri, questionPath), AccessToken, limit, page);
        }

        /// <summary>
        /// questionIdで指定された質問を返します。
        /// </summary>
        /// <param name="questionId">正の整数で表される質問ID</param>
        /// <returns>質問詳細とその回答</returns>
        public QuestionDetail GetQuestionDetail(int questionId)
        {
            return Util.GetQuery<QuestionDetail>(
                new Uri(baseUri, string.Join(@"/", questionPath, questionId)), AccessToken);
        }

        /// <summary>
        /// 登録されている全ユーザーの情報を、登録日の降順で返します。
        /// </summary>
        /// <returns>全ユーザーの情報</returns>
        public UserList GetUserList(int? limit = null, int? page = null)
        {
            return Util.GetQuery<UserList>(
                new Uri(baseUri, string.Join(@"/", userPath)), AccessToken, limit, page);
        }
        /// <summary>
        /// 文字列queryを含むdisplay_nameを持つユーザー一覧を返します。
        /// display_nameに使用できる文字は半角英数及び-、_、.なので、 queryにこれら以外の文字が含まれているとBad Requesetが返ります。
        /// またdisplay_nameの最大は15文字なので、queryがこれを超えているとBad Requestが返ります。
        /// </summary>
        /// <param name="query">teratailユーザー名検索クエリ</param>
        /// <returns>文字列queryを含むdisplay_nameを持つユーザー一覧</returns>
        public UserList GetUserList(string query, int? limit = null, int? page = null)
        {
            if (Regex.IsMatch(query, @"^[0-9a-zA-Z\-\_\.]*$"))
                throw new ArgumentException("queryに使用できる文字は半角英数及び「-」、「_」、「.」です。");

            if (query.Length > 15)
                throw new ArgumentException("queryは15文字以下で指定してください。");

            return Util.GetQuery<UserList>(
                new Uri(baseUri, string.Join(@"/", userPath, searchPath)), AccessToken, limit, page, query);
        }

        /// <summary>
        /// displayNameで指定したユーザーの情報を返します。
        /// </summary>
        /// <param name="displayName">teratailユーザー名</param>
        /// <returns>ユーザーの情報</returns>
        public UserDetail GetUserDetail(string displayName)
        {
            return Util.GetQuery<UserDetail>(
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
            return Util.GetQuery<QuestionList>(
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
            return Util.GetQuery<TagList>(
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
            return Util.GetQuery<QuestionList>(
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
            return Util.GetQuery<ReplyList>(
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
            return Util.GetQuery<UserList>(
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
            return Util.GetQuery<UserList>(
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
            return Util.GetQuery<TagList>(
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
            return Util.GetQuery<TagQuestionList>(
                new Uri(baseUri, string.Join(@"/", tagPath, Uri.EscapeDataString(tagName), questionPath)), AccessToken, limit, page);
        }
    }
}
