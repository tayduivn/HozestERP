#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-10-26 10:25:35.34958 +08:00
*/
#endregion

using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JdSdk.Domain;
using JdSdk.Response;

namespace JdSdk.Request
{
    /// <summary>
    /// 获取服务单信息 Request
    /// </summary>
    public class JingdongAfsserviceServiceinfoGetRequest : JdRequestBase<JingdongAfsserviceServiceinfoGetResponse>
    {
        /// <summary>
        /// 服务单号 ID
        /// </summary>
        /// <example></example>
        [XmlElement("afsServiceId")]
        [JsonProperty("afsServiceId")]
        public Nullable<Int64> AfsServiceId
        {
            get;
            set;
        }


        public override String ApiName
        {
            get{ return "jingdong.afsservice.serviceinfo.get"; }
        }

        protected override void PrepareParam(IDictionary<String, Object> paramters)
        {
            paramters.Add("afsServiceId", this.AfsServiceId);
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("afsServiceId", this.AfsServiceId);
        }

    }
}
