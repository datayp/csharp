using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Mobpex1;
namespace DemoTest
{
    [TestClass]
    public class DemoTest
    {
        private String serverRoot = "https://www.mobpex.com/yop-center";//Mobpex对外提供的接口地址
        private String appId = "16031706093671048936";//企业在Mobpex注册的应用ID；
        private String userId = "changkun.deng@datayp.com";//用户id
        private string secretKey = "密钥";//密钥值 
                                                                        // private String serverRoot = "https://220.181.25.235/yop-center";
                                                                        // private String secretKey = "LS_1bilscsAFBWqFnc3f61ssiors7qira";
                                                                        // private String appId = "15122404366710489367";
                                                                        // private String userId = "long.chen-1@yeepay.com";
        [TestMethod]
        //查询渠道
        public void TestQueryChannel()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            string methodOrUri = "/rest/v1.0/query/findChannelInfoByAppId";//API的唯一标识
            param.Add(Constants.APP_Id, appId);
            param.Add(Constants.FORMAT, "json");
            param.Add(Constants.VERSION, "1.0");
            param.Add(Constants.LOCALE, "zh_CN");
            param.Add(Constants.METHOD, methodOrUri);
            param.Add(Constants.USER_ID, userId);
            param.Add(Constants.TIMESTAMP, utils.GetCurrentTimeMillis());
            MobpexClient mc = new MobpexClient();
            mc.SecretKey = secretKey;
            string sign = MobpexClient.SignTopRequest(param, secretKey, "md5");
            param.Add(Constants.SIGN, sign);
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
        [TestMethod]
        //统一下单
        public void TestPrePay()
        {
            string methodOrUri = "/rest/v1.0/pay/unifiedOrder";//API的唯一标识
            Dictionary<string, string> param = new Dictionary<string, string>();
            Dictionary<string, string> paramDic = new Dictionary<string, string>();
            //param中添加预支付请求参数
            param.Add("tradeNo", "338215020");//商户订单号（商户退款流水号）
            param.Add("productName", "法拉利");//商品或服务名称
            param.Add("productDescription", "拉风");//商品或服务的描述
            param.Add("payChannel", "ALIPAY");//支付渠道
            param.Add("payType", "WAP");//支付类型
            param.Add("payCurrency", "CNY");//货币单位
            param.Add("amount", "200");//金额
            //将字典类型序列化为json字符串
            string jsonStr = utils.SerializeDictionaryToJsonString<string, string>(param);
            paramDic.Add(Constants.FORMAT, "json");
            paramDic.Add(Constants.VERSION, "1.0");
            paramDic.Add(Constants.LOCALE, "zh_CN");
            paramDic.Add(Constants.TIMESTAMP, utils.GetCurrentTimeMillis());
            paramDic.Add(Constants.METHOD, methodOrUri);
            paramDic.Add("prePayRequest", jsonStr);
            paramDic.Add(Constants.APP_Id, appId);
            paramDic.Add(Constants.USER_ID, userId);
            MobpexClient mc = new MobpexClient();
            mc.SecretKey = secretKey;
            string sign = MobpexClient.SignTopRequest(paramDic, secretKey, "md5");
            paramDic.Add("sign", sign);
            String content = mc.DoPost(serverRoot + methodOrUri, paramDic);
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
        //退款
        public void testRefund()
        {
            string methodOrUri = "/rest/v1.0/pay/refund";//API的唯一标识
            Dictionary<string, string> param = new Dictionary<string, string>();
            Dictionary<string, string> paramDic = new Dictionary<string, string>();
            //param中添加退款请求参数
            param.Add("tradeNo", "338215020");
            param.Add("refundNo", "11234563333");
            param.Add("amount", "0.01");
            param.Add("description", "我要退款");
            //将字典类型序列化为json字符串
            string jsonStr = utils.SerializeDictionaryToJsonString<string, string>(param);
            paramDic.Add(Constants.FORMAT, "json");
            paramDic.Add(Constants.VERSION, "1.0");
            paramDic.Add(Constants.LOCALE, "zh_CN");
            paramDic.Add(Constants.TIMESTAMP, utils.GetCurrentTimeMillis());
            paramDic.Add(Constants.METHOD, methodOrUri);
            paramDic.Add("refundRequest", jsonStr);
            paramDic.Add(Constants.APP_Id, appId);
            paramDic.Add(Constants.USER_ID, userId);
            MobpexClient mc = new MobpexClient();
            mc.SecretKey = secretKey;
            string sign = MobpexClient.SignTopRequest(paramDic, secretKey, "md5");
            paramDic.Add("sign", sign);
            String content = mc.DoPost(serverRoot + methodOrUri, paramDic);
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
        //退款查询
        public void testRefundQuery()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(Constants.APP_Id, appId);
            param.Add(Constants.FORMAT, "json");
            param.Add(Constants.VERSION, "1.0");
            param.Add(Constants.LOCALE, "zh_CN");
            param.Add(Constants.METHOD, "/rest/v1.0/pay/queryRefundOrder");
            param.Add(Constants.USER_ID, userId);
            param.Add(Constants.TIMESTAMP, utils.GetCurrentTimeMillis());
            param.Add("tradeNo", "338215098");
            param.Add("refundNo", "760173609");//商户退款请求流水号
            MobpexClient mc = new MobpexClient();
            mc.SecretKey = secretKey;
            string sign = MobpexClient.SignTopRequest(param, secretKey, "md5");
            param.Add(Constants.SIGN, sign);
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
        //支付查询
        public void testPayQuery()
        {
            string methodOrUri = "/rest/v1.0/pay/queryPaymentOrder";//API的唯一标识
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(Constants.APP_Id, appId);
            param.Add(Constants.FORMAT, "json");
            param.Add(Constants.VERSION, "1.0");
            param.Add(Constants.LOCALE, "zh_CN");
            param.Add(Constants.METHOD, methodOrUri);
            param.Add(Constants.USER_ID, userId);
            param.Add(Constants.TIMESTAMP, utils.GetCurrentTimeMillis());
            param.Add("tradeNo", "338215098");
            MobpexClient mc = new MobpexClient();
            mc.SecretKey = secretKey;
            string sign = MobpexClient.SignTopRequest(param, secretKey, "md5");
            param.Add(Constants.SIGN, sign);
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
        [TestMethod]
        //企业付款请求
        public void testEPPay()
        {
            string methodOrUri = "/rest/v1.0/transfer/transfer";//API的唯一标识
            Dictionary<string, string> param = new Dictionary<string, string>();
            Dictionary<string, string> paramDic = new Dictionary<string, string>();
            //param中添加企业代发代付请求参数
            param.Add("orderNo", "1098836026");//商户订单号（商户支付请求流水号）
            param.Add("payDesc", "还款");//付款描述
            param.Add("payChannel", "YEEPAY");//支付渠道
            param.Add("payType", "WAP");//支付类型
            param.Add("Currency", "CNY");//货币单位
            param.Add("amount", "200");//金额
            param.Add("custName", "张氏");//客户姓名
            param.Add("bankCode", "ICBC");//银行编码
            param.Add("cardNo", "6217042715400684874");//银行账号
            param.Add("accountType", "pr");//账户类型
            param.Add("feeType", "SOURCE");//费率类型
            //将字典类型序列化为json字符串
            string jsonStr = utils.SerializeDictionaryToJsonString<string, string>(param);
            paramDic.Add(Constants.FORMAT, "json");
            paramDic.Add(Constants.VERSION, "1.0");
            paramDic.Add(Constants.LOCALE, "zh_CN");
            paramDic.Add(Constants.TIMESTAMP, utils.GetCurrentTimeMillis());
            paramDic.Add(Constants.METHOD, methodOrUri);
            paramDic.Add("transferRequest", jsonStr);
            paramDic.Add(Constants.APP_Id, appId);
            paramDic.Add(Constants.USER_ID, userId);
            MobpexClient mc = new MobpexClient();
            mc.SecretKey = secretKey;
            string sign = MobpexClient.SignTopRequest(paramDic, secretKey, "md5");
            paramDic.Add("sign", sign);
            String content = mc.DoPost(serverRoot + methodOrUri, paramDic);
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
        //企业查询
        public void testEPQuery()
        {
            string methodOrUri = "/rest/v1.0/transfer/queryOrder";//API的唯一标识
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(Constants.APP_Id, appId);
            param.Add(Constants.FORMAT, "json");
            param.Add(Constants.VERSION, "1.0");
            param.Add(Constants.LOCALE, "zh_CN");
            param.Add(Constants.METHOD, methodOrUri);
            param.Add(Constants.USER_ID, userId);
            param.Add(Constants.TIMESTAMP, utils.GetCurrentTimeMillis());
            param.Add("orderNo", "1687906461");//商户支付请求流水号
            MobpexClient mc = new MobpexClient();
            mc.SecretKey = secretKey;
            string sign = MobpexClient.SignTopRequest(param, secretKey, "md5");
            param.Add(Constants.SIGN, sign);
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
        [TestMethod]
        //企业余额查询
        public void testBalanceQuery()
        {
            string methodOrUri = "/rest/v1.0/transfer/queryBalance";//API的唯一标识
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(Constants.APP_Id, appId);
            param.Add(Constants.FORMAT, "json");
            param.Add(Constants.VERSION, "1.0");
            param.Add(Constants.LOCALE, "zh_CN");
            param.Add(Constants.METHOD, methodOrUri);
            param.Add(Constants.USER_ID, userId);
            param.Add(Constants.TIMESTAMP, utils.GetCurrentTimeMillis());
            param.Add("payChannel", "YEEPAY");//支付渠道
            param.Add("payType", "HELPBUY");//支付类型
            MobpexClient mc = new MobpexClient();
            mc.SecretKey = secretKey;
            string sign = MobpexClient.SignTopRequest(param, secretKey, "md5");
            param.Add(Constants.SIGN, sign);
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