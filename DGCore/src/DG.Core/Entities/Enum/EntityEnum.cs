using System;
using System.Collections.Generic;
using System.Text;

namespace DG.Core.Entities.Enum
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum Gender
    {
        女 = 0,
        男 = 1,
        保密 = 2
    }

    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        其他 = 0,
        登录 = 1,
        退出 = 2,
        访问 = 3,
        新增 = 4,
        删除 = 5,
        修改 = 6,
        提交 = 7,
        异常 = 8,
    }

    /// <summary>
    /// 客户端类型
    /// </summary>
    public enum ClientType
    {
        其他 = 0,
        电脑 = 1,
        APP = 2,
        微信 = 3,
        支付宝 = 4,
        手机 = 5,
        PAD = 6,
        手表 = 7,
        电视 = 8
    }

    /// <summary>
    /// 会员等级
    /// </summary>
    public enum LevelType
    {
        普通会员 = 0,
        高级会员 = 1,
        VIP会员 = 2
    }
}
