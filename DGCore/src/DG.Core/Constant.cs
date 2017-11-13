using System;
using System.Collections.Generic;
using System.Text;

namespace DG.Core
{
    public struct Constant
    {
        public struct ConstNames
        {
            public const string Token = "_SessionToken";
            public const string Users = "_SessionUsersOutput";
        }
        /// <summary>
        /// 错误代码
        /// 错误代码格式--前缀+xxxx
        /// </summary>
        public struct ErrorCode
        {
            #region 系统异常代码--前缀S

            /// <summary>
            /// 系统异常
            /// </summary>
            public const string Exception = "S0001";

            /// <summary>
            /// 用户未登录
            /// </summary>
            public const string AuthorizeError = "S0002";

            /// <summary>
            /// Token过期
            /// </summary>
            public const string TokenOutTime = "S0003";

            /// <summary>
            /// 功能未实现
            /// </summary>
            public const string NotImplemented = "S0004";

            /// <summary>
            /// 空数据
            /// </summary>
            public const string EmptyData = "S0005";

            #endregion

            #region 公共错误代码--前缀C

            /// <summary>
            /// 参数为空
            /// </summary>
            public const string EmptyParameter = "C0001";

            #endregion
        }
    }
}
