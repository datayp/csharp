using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Mobpex1;
namespace DemoTest
{  
    [TestClass]
    public class DemoTest
    {
        private  String serverRoot = "https://www.mobpex.com/yop-center";
        private  String appId = "16031706093671048936";
        private  String userId= "changkun.deng@datayp.com";
        private  string secretKey= "LS_1biokjnAFBWqV8h1242collm9fvaq9l";
        [TestMethod]
        public void TestQueryChannel()
        {
            Dictionary<string,string> param = new Dictionary<string,string> ();
            string methodOrUri = "/rest/v1.0/query/findChannelInfoByAppId";
            MobpexRequest req = new MobpexRequest();
            param.Add(Constants.APP_Id, appId);
            param.Add(Constants.FORMAT, "json");
            param.Add(Constants.VERSION,req.Version);
            param.Add(Constants.LOCALE, req.Locale);
            param.Add(Constants.METHOD, methodOrUri);
            param.Add(Constants.USER_ID, userId);
            param.Add(Constants.SIGN_RETURN, Convert.ToString(req.SignRet));
            param.Add(Constants.TIMESTAMP, utils.GetCurrentTimeMillis());
            string sign= MobpexClient.SignTopRequest(param,secretKey,"md5");
            param.Add(Constants.SIGN,sign);
            MobpexClient mc = new MobpexClient();
            String content=mc.DoPost(serverRoot+ methodOrUri, param);
            bool flag = mc.CheckSign(content);
            if (flag)
            {
                Console.WriteLine("签名验证成功");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("签名验证失败");
                Console.WriteLine(content);
            }   
        }
        [TestMethod]
        public void TestPrePay()
        {
            string methodOrUri = "/rest/v1.0/pay/unifiedOrder";
            Dictionary<string, string> param = new Dictionary<string, string>();
            Dictionary<string, string> paramDic = new Dictionary<string, string>();
            MobpexRequest req = new MobpexRequest();
            param.Add("tradeNo", "338215020");
            param.Add("productName", "法拉利");
            param.Add("productDescription", "拉风");
            param.Add("payChannel", "ALIPAY");
            param.Add("payType", "WAP");
            param.Add("payCurrency", "CNY");
            param.Add("amount", "200");
            string jsonStr = utils.SerializeDictionaryToJsonString<string, string>(param);
            paramDic.Add(Constants.FORMAT, "json");
            paramDic.Add(Constants.VERSION, req.Version);
            paramDic.Add(Constants.LOCALE, req.Locale);
            paramDic.Add(Constants.SIGN_RETURN, Convert.ToString(req.SignRet));
            paramDic.Add(Constants.TIMESTAMP, utils.GetCurrentTimeMillis());
            paramDic.Add(Constants.METHOD, methodOrUri);
            paramDic.Add("prePayRequest", jsonStr);
            paramDic.Add(Constants.APP_Id, appId);
            paramDic.Add(Constants.USER_ID, userId);
            string sign = MobpexClient.SignTopRequest(paramDic, secretKey, "md5");
            paramDic.Add("sign",sign);
            MobpexClient mob = new MobpexClient();
            String content = mob.DoPost(serverRoot + methodOrUri, paramDic);
            bool flag = mob.CheckSign(content);
            if (flag)
            {
                Console.WriteLine("签名验证成功");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("签名验证失败");
                Console.WriteLine(content);
            }
        }
        [TestMethod]
        public void testRefund()
        {
            string methodOrUri = "/rest/v1.0/pay/refund";
            Dictionary<string, string> param = new Dictionary<string, string>();
            Dictionary<string, string> paramDic = new Dictionary<string, string>();
            MobpexRequest req = new MobpexRequest();
            param.Add("tradeNo", "338215020");
            param.Add("refundNo", "11234563333");
            param.Add("amount", "0.01");
            param.Add("description", "我要退款");
            string jsonStr = utils.SerializeDictionaryToJsonString<string, string>(param);
            paramDic.Add(Constants.FORMAT, "json");
            paramDic.Add(Constants.VERSION, req.Version);
            paramDic.Add(Constants.LOCALE, req.Locale);
            paramDic.Add(Constants.SIGN_RETURN, Convert.ToString(req.SignRet));
            paramDic.Add(Constants.TIMESTAMP, utils.GetCurrentTimeMillis());
            paramDic.Add(Constants.METHOD, methodOrUri);
            paramDic.Add("refundRequest", jsonStr);
            paramDic.Add(Constants.APP_Id, appId);
            paramDic.Add(Constants.USER_ID, userId);
            string sign = MobpexClient.SignTopRequest(paramDic, secretKey, "md5");
            paramDic.Add("sign", sign);
            MobpexClient mob= new MobpexClient();
            String content = mob.DoPost(serverRoot + methodOrUri, paramDic);
            bool flag = mob.CheckSign(content);
            if (flag)
            {
                Console.WriteLine("签名验证成功");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("签名验证失败");
                Console.WriteLine(content);
            }
        }
        [TestMethod]
        public void testRefundQuery()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            MobpexRequest req = new MobpexRequest();
            param.Add(Constants.APP_Id, appId);
            param.Add(Constants.FORMAT, "json");
            param.Add(Constants.VERSION, req.Version);
            param.Add(Constants.LOCALE, req.Locale);
            param.Add(Constants.METHOD, "/rest/v1.0/pay/queryRefundOrder");
            param.Add(Constants.USER_ID, userId);
            param.Add(Constants.SIGN_RETURN, Convert.ToString(req.SignRet));
            param.Add(Constants.TIMESTAMP, utils.GetCurrentTimeMillis());
            param.Add("tradeNo", "338215098");
            param.Add("refundNo", "760173609");
            string sign = MobpexClient.SignTopRequest(param, secretKey, "md5");
            param.Add(Constants.SIGN, sign);
            MobpexClient mc = new MobpexClient();
            String content = mc.DoPost(serverRoot + "/rest/v1.0/pay/queryRefundOrder", param);
            bool flag = mc.CheckSign(content);
            if (flag)
            {
                Console.WriteLine("签名验证成功");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("签名验证失败");
                Console.WriteLine(content);
            }
        }
        [TestMethod]
        public void testPayQuery()
        {
            string methodOrUri = "/rest/v1.0/pay/queryPaymentOrder";
            Dictionary<string, string> param = new Dictionary<string, string>();
            MobpexRequest req = new MobpexRequest();
            param.Add(Constants.APP_Id, appId);
            param.Add(Constants.FORMAT, "json");
            param.Add(Constants.VERSION, req.Version);
            param.Add(Constants.LOCALE, req.Locale);
            param.Add(Constants.METHOD, methodOrUri);
            param.Add(Constants.USER_ID, userId);
            param.Add(Constants.SIGN_RETURN, Convert.ToString(req.SignRet));
            param.Add(Constants.TIMESTAMP, utils.GetCurrentTimeMillis());
            param.Add("tradeNo", "338215098");
            string sign = MobpexClient.SignTopRequest(param, secretKey, "md5");
            param.Add(Constants.SIGN, sign);
            MobpexClient mc = new MobpexClient();
            String content = mc.DoPost(serverRoot + methodOrUri, param);
            bool flag = mc.CheckSign(content);
            if (flag)
            {
                Console.WriteLine("签名验证成功");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("签名验证失败");
                Console.WriteLine(content);
            }
        }
    }
}