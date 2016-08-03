using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mobpex1
{
    public class MobpexConfig
    {
        private static String serverRoot = "http://wwww.mobpex.com/yop-center";
        private static Boolean ignoreSSLCheck = false;
        private static String appId;
        private static String secretKey;
        private static int connectTimeout = 30000;
        private static int readTimeout = 60000;
        public static String ServerRoot
        {
            get { return serverRoot; }
            set { serverRoot = value; }
        }
        public bool IgnoreSSLCheck
        {
            get { return ignoreSSLCheck; }
            set { ignoreSSLCheck = value; }
        }
        public static String SecretKey
        {
            get { return secretKey; }
            set { secretKey = value; }
        }
        public static String AppId
        {
            get { return appId; }
            set { appId = value; }
        }
        public static int  ConnectTimeout
        {
            get { return connectTimeout; }
            set { connectTimeout = value; }
        }
        public static int ReadTimeout
        {
            get { return readTimeout; }
            set { readTimeout = value; }
        }
    }
}