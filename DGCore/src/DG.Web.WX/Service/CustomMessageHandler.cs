using System.Collections.Generic;
using System.IO;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.Context;
using System.Web;
using System.Text;
using ACC.Convert;
using System;

namespace DG.Web.WX.Service
{

    public partial class CustomMessageHandler : MessageHandler<MessageContext<IRequestMessageBase, IResponseMessageBase>>
    {
        private string WebRootPath = string.Empty;
        public CustomMessageHandler(Stream inputStream, PostModel postModel, string webRootPath ) : base(inputStream, postModel)
        {
            WebRootPath = webRootPath;
        }

        public CustomMessageHandler(RequestMessageBase requestMessage) : base(requestMessage)
        {
        }

        public override IResponseMessageBase OnEventRequest(IRequestMessageEventBase requestMessage)
        {
            return base.OnEventRequest(requestMessage);
        }

        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "这条消息来自于DefaultResponseMessage";
            return responseMessage;
        }

        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            Senparc.Weixin.WeixinTrace.SendCustomLog("系统日志", requestMessage.ToJson());
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            //responseMessage.Content = "您的OpenID是：" + responseMessage.FromUserName + ".\r\n您发送的文字是：" + requestMessage.Content;
            var name = DateTime.Now.ToString("yyyyMMddHHmmss")+".mp3";
            Tts(requestMessage.Content, name);
            responseMessage.Content = $"<a href='http://wx.dldg.ink/fils/{name}'>{name}</a>\n<a href='http://wsq.qq.com/reflow/244962962'>[发帖反馈意见]</a>";
            Senparc.Weixin.WeixinTrace.SendCustomLog("音乐", responseMessage.ToJson());
            return responseMessage;
        }
        // 合成
        public string Tts(string wd,string name)
        {
            var client = ACC.SDK.Baidu.Api.Speech.Client("Z1ut00CPND75MRjMCTPz52T6", "fA68VIlGMLFcTRqX0GeOn3g5UoQlzBdL");
            // 可选参数
            var option = new Dictionary<string, string>()
                {
                    { "tex", wd},
                    { "tok", client.Access_token},
                    { "cuid", ACC.Common.HttpClientHelper.GetMacByNetworkInterface()},
                    { "ctp","1" },
                    { "lan","zh" },
                    { "spd", "5"}, // 语速
                    { "vol", "7"}, // 音量
                    { "per", "4"}  // 发音人，4：情感度丫丫童声
                };
            
            string path = Path.Combine(WebRootPath, "fils", name);
            var result = ACC.SDK.Baidu.Api.Speech.Text2Audio(path, option);
            return path;

        }

        public override IResponseMessageBase OnImageRequest(RequestMessageImage requestMessage)
        {
            return base.OnImageRequest(requestMessage);
        }
        public override IResponseMessageBase OnLocationRequest(RequestMessageLocation requestMessage)
        {
            return base.OnLocationRequest(requestMessage);
        }
        public override IResponseMessageBase OnVideoRequest(RequestMessageVideo requestMessage)
        {
            return base.OnVideoRequest(requestMessage);
        }

        public override IResponseMessageBase OnVoiceRequest(RequestMessageVoice requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            return responseMessage;
        }
        
        
    }
}
