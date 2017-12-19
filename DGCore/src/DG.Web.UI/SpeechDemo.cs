using System;
using System.Collections.Generic;
using System.IO;
using Baidu.Aip.Speech;

namespace DG.Web.UI
{
    public class SpeechDemo
    {
        private readonly Asr _asrClient;
        private readonly Tts _ttsClient;
        private readonly string Key = "Z1ut00CPND75MRjMCTPz52T6";
        private readonly string Secret = "fA68VIlGMLFcTRqX0GeOn3g5UoQlzBdL";


        public SpeechDemo()
        {
            _asrClient = new Asr(Key, Secret);
            _ttsClient = new Tts(Key, Secret);
        }

        // 识别本地文件
        public void AsrData()
        {
            var data = File.ReadAllBytes(@"C:\Users\hym\Downloads\aip-speech-csharp-sdk-1.0.0\Speech\re.txt");
            var result = _asrClient.Recognize(data, "pcm", 16000);
            Console.Write(result);
        }

        // 识别URL中的语音文件
        public void AsrUrl()
        {
            var result = _asrClient.Recoginze(
                "http://xxx.com/待识别的pcm文件地址", 
                "http://xxx.com/识别结果回调地址", 
                "pcm", 
                16000);
            Console.WriteLine(result);
        }

        // 合成
        public void Tts()
        {
            // 可选参数
            var option = new Dictionary<string, object>()
            {
                {"spd", 5}, // 语速
                {"vol", 7}, // 音量
                {"per", 4}  // 发音人，4：情感度丫丫童声
            };
            var result = _ttsClient.Synthesis("众里寻他千百度", option);

            if (result.ErrorCode == 0)  // 或 result.Success
            {
                File.WriteAllBytes("合成的语音文件本地存储地址.mp3", result.Data);
            }
        }
        
    }
}