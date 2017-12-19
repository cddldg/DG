using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DG.Web.WX.Models;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities.Request;
using System.IO;
using DG.Web.WX.Service;
using Senparc.Weixin.MP.MvcExtension;


namespace DG.Web.WX.Controllers
{
    public class HomeController : Controller
    {


        /// <summary>
        /// 微信后台验证地址（使用Get），微信后台的“接口配置信息”的Url填写如：http://weixin.senparc.com/weixin
        /// </summary>
        [HttpGet]
        public IActionResult Index(string signature, string timestamp, string nonce, string echostr)
        {
            if (CheckSignature.Check(signature, timestamp, nonce, Senparc.Weixin.Config.DefaultSenparcWeixinSetting.Token))
            {
                return Content(echostr); //返回随机字符串则表示验证通过
            }
            else
            {
                return Content("微信");
            }
        }
       

        /// <summary>
        /// 用户发送消息后，微信平台自动Post一个请求到这里，并等待响应XML。
        /// PS：此方法为简化方法，效果与OldPost一致。
        /// v0.8之后的版本可以结合Senparc.Weixin.MP.MvcExtension扩展包，使用WeixinResult，见MiniPost方法。
        /// </summary>
        [HttpPost]
        public ActionResult Index(PostModel postModel)
        {
            if (!CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, Senparc.Weixin.Config.DefaultSenparcWeixinSetting.Token))
            {
                return Content("参数错误！");
            }

            postModel.Token = Senparc.Weixin.Config.DefaultSenparcWeixinSetting.Token;//根据自己后台的设置保持一致
            postModel.EncodingAESKey = Senparc.Weixin.Config.DefaultSenparcWeixinSetting.EncodingAESKey;//根据自己后台的设置保持一致
            postModel.AppId = Senparc.Weixin.Config.DefaultSenparcWeixinSetting.WeixinAppId;//根据自己后台的设置保持一致

            //自定义MessageHandler，对微信请求的详细判断操作都在这里面。
            //获取request的响应  
            var memoryStream = new MemoryStream();
            Request.Body.CopyTo(memoryStream);
            var messageHandler = new CustomMessageHandler(memoryStream, postModel);//接收消息

            messageHandler.Execute();//执行微信处理过程
            //return new WeixinResult(messageHandler);
            return new FixWeixinBugWeixinResult(messageHandler);//返回结果

        }




        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
