using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mobpex1
{
    public class MobpexRequest
    {
        private static String serverRoot = "http://wwww.mobpex.com/yop-center";
        private static Boolean ignoreSSLCheck = false;
        private static String appId;
        private static String secretKey;
        private static string userId;
        private static int connectTimeout = 30000;
        private static int readTimeout = 60000;
        private string method;
        private string locale="zh_CN";
        private String version = "1.0";
        private Boolean signRet = true;
        private Boolean liveMode = true;
        Dictionary<string, string> dic = new Dictionary<string, string>();
        public MobpexRequest()
        {
            MobpexRequest.appId =MobpexConfig.AppId;
            MobpexRequest.secretKey = MobpexConfig.SecretKey;
            MobpexRequest.serverRoot = MobpexConfig.ServerRoot;
            dic.Add(Constants.APP_Id, MobpexConfig.AppId);
            dic.Add(Constants.FORMAT, "json");
            dic.Add(Constants.VERSION, version);
            dic.Add(Constants.LOCALE, locale);
            dic.Add(Constants.SIGN_RETURN, Convert.ToString(signRet));
            dic.Add(Constants.TIMESTAMP,DateTime.Now.Millisecond.ToString());
        }

        public string Method
        {
            get { return method; }
            set { method = value; }
        }
        public string Locale 
        {
            get { return locale; }
            set { locale = value; }
        }
        public string Version
        {
            get { return version; }
            set { version = value; }
        }
        public bool LiveMode
        {
            get { return liveMode; }
            set { liveMode = value; }
        }

        public bool SignRet
        {   get { return signRet; }
            set { signRet= value; }
        }
        public string ServerRoot
        {
            get { return serverRoot; }
            set { serverRoot = value; }
        }
        public bool IgnoreSSLCheck
        {
            get { return ignoreSSLCheck; }
            set { ignoreSSLCheck = value; }
        }
        public string SecretKey
        {
            get { return secretKey; }
            set { secretKey = value; }
        }
        public string AppId
        {
            get { return appId; }
            set { appId = value; }
        }
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public int ConnectTimeout
        {
            get { return connectTimeout; }
            set { connectTimeout = value; }
        }
        public int ReadTimeout
        {
            get { return readTimeout; }
            set { readTimeout = value; }
        }
    }

}