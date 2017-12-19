using System.Collections.Generic;
using System.IO;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.Context;
using System.Web;

namespace DG.Web.WX.Service
{

    public partial class CustomMessageHandler : MessageHandler<MessageContext<IRequestMessageBase, IResponseMessageBase>>
    {
        public CustomMessageHandler(Stream inputStream, PostModel postModel) : base(inputStream, postModel)
        {
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
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "您的OpenID是：" + responseMessage.FromUserName + ".\r\n您发送的文字是：" + requestMessage.Content;


            //var client = ACC.SDK.Baidu.Api.Speech.Client("Z1ut00CPND75MRjMCTPz52T6", "fA68VIlGMLFcTRqX0GeOn3g5UoQlzBdL");
            //// 可选参数
            //var option = new Dictionary<string, string>()
            //    {
            //        { "tex", HttpUtility.UrlEncode(requestMessage.Content)},
            //        { "tok",client.Access_token},
            //        { "cuid", ACC.Common.HttpClientHelper.GetMacByNetworkInterface()},
            //        { "ctp","1" },
            //        { "lan","zh" },
            //        { "spd", "4"}, // 语速
            //        { "vol", "7"}, // 音量
            //        { "per", "3"}  // 发音人，4：情感度丫丫童声
            //    };
            //var result = ACC.SDK.Baidu.Api.Speech.Text2Audio(option);
            return responseMessage;
        }
        // 合成
        public void Tts()
        {
            var client = ACC.SDK.Baidu.Api.Speech.Client("Z1ut00CPND75MRjMCTPz52T6", "fA68VIlGMLFcTRqX0GeOn3g5UoQlzBdL");
            // 可选参数
            var option = new Dictionary<string, string>()
                {
                    { "tex", "你好中国"},
                    { "tok", client.Access_token},
                    { "cuid", ACC.Common.HttpClientHelper.GetMacByNetworkInterface()},
                    { "ctp","1" },
                    { "lan","zh" },
                    { "spd", "5"}, // 语速
                    { "vol", "7"}, // 音量
                    { "per", "4"}  // 发音人，4：情感度丫丫童声
                };
            var result = ACC.SDK.Baidu.Api.Speech.Text2Audio(option);


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
