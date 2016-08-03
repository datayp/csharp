using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mobpex1
{
    public class Constants
    {
        public const string SIGN_METHOD = "sign_method";
        public const string PARTNER_ID = "partner_id";
        public const string SESSION = "session";
      
        public const string SIMPLIFY = "simplify";
        public const string TARGET_APP_KEY = "target_app_key";

        public const String ENCODING = "UTF-8";

        public const String SUCCESS = "SUCCESS";
        public const String FAILURE = "FAILURE";
        public const String CALLBACK = "callback";
        public const string CONTENT_ENCODING_GZIP = "gzip";


        // 方法的默认参数名
        public const String METHOD = "method";

        // 格式化默认参数名
        public const String FORMAT = "format";

        // 本地化默认参数名
        public const String LOCALE = "locale";

        // 会话id默认参数名
        public const String SESSION_ID = "sessionId";

        // 应用键的默认参数名 ;
        public const String APP_Id = "appId";

        // 服务版本号的默认参数名
        public const String VERSION = "v";

        // 签名的默认参数名
        public const String SIGN = "sign";

        // 返回结果是否签名
        public const String SIGN_RETURN = "signRet";

        // 商户编号
        public const String CUSTOMER_NO = "customerNo";

        //是否生产模式
        public const String LIVE_MODE = "liveMode";

        // 加密报文key
        public const String ENCRYPT = "encrypt";


        //回调相关key名称常量

        public const String DATA = "data";//回调响应JSON的参数名

        public const String PAY_ORDER_ID = "payOrderId";//第三方支付交易订单号,成功时才会有
        public const String ORDER_ID = "tradeNo";//商户订单号
        public const String AMOUNT = "amount";//支付金额
        public const String PRODUCT_NAME = "productName";//产品名称
        public const String PRODUCT_DESCRIPTION = "productDescription";//产品描述
        public const String ORDER_STATUS = "orderStatus";//订单状态
        public const String REFUND_STATUS = "refundStatus";//订单状态

        public const String TRANSACTION_CLOSE_TIME = "transactionCloseTime";//订单结束时间
        public const String EVENT_TYPE = "eventType";//事件类型
                                                     //public const String  EVENT_TYPE= "eventType";//订单状态
        public const String ERROR = "error";//错误
        public const String TXN_TIME = "txnTime";//接收到订单时间
        public const String ERR_CODE = "errCode";
        public const String ERR_MSG = "errMsg";
        public const String REFUND_ID = "refundId"; ////第三方退款订单号,成功时才会有
        public const String REFUND_ORDER_ID = "refundNo";

        // 时间戳
        public const String TIMESTAMP = "ts";
        public const String USER_ID = "userId";
        public const String KEY_TYPE = "keyType";
      
        /**  默认时间格式 **/
        public const String DATE_TIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

        /** UTF-8字符集 **/
        public const String CHARSET_UTF8 = "UTF-8";

        /** GBK字符集 **/
        public const String CHARSET_GBK = "GBK";

        /** TOP JSON 应格式 */
        public const String FORMAT_JSON = "json";
      
        /** MD5签名方式 */
        public const String SIGN_METHOD_MD5 = "md5";
        /** HMAC签名方式 */
        public const String SIGN_METHOD_HMAC = "hmac";

    }
}


