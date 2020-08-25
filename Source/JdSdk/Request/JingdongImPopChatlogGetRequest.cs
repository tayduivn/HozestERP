#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-10-26 10:25:37.57171 +08:00
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
    /// 聊天记录查询 Request
    /// </summary>
    public class JingdongImPopChatlogGetRequest : JdRequestBase<JingdongImPopChatlogGetResponse>
    {
        /// <summary>
        /// 需要查询的客服账号，为空默认查询的是商家主账户
        /// </summary>
        /// <example></example>
        [XmlElement("waiter")]
        [JsonProperty("waiter")]
        public String Waiter
        {
            get;
            set;
        }

        /// <summary>
        /// 要查询的顾客账号
        /// </summary>
        /// <example></example>
        [XmlElement("customer")]
        [JsonProperty("customer")]
        public String Customer
        {
            get;
            set;
        }

        /// <summary>
        /// 查询的商品ID
        /// </summary>
        /// <example></example>
        [XmlElement("skuId")]
        [JsonProperty("skuId")]
        public Int64 SkuId
        {
            get;
            set;
        }

        /// <summary>
        /// 需要查询数据的开始日期（取DateTime的年月日部分）
        /// </summary>
        /// <example></example>
        [XmlElement("startTime")]
        [JsonProperty("startTime")]
        public DateTime StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// 需要查询数据的截止日期（取DateTime的年月日部分），查询起止日期相差不能大于7天，查询的日期距现在不能大于3个月
        /// </summary>
        /// <example></example>
        [XmlElement("endTime")]
        [JsonProperty("endTime")]
        public DateTime EndTime
        {
            get;
            set;
        }

        ///// <summary>
        ///// 查询页数
        ///// </summary>
        ///// <example></example>
        //[XmlElement("page")]
        //[JsonProperty("page")]
        //public Int64 Page
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 每页记录数
        ///// </summary>
        ///// <example></example>
        //[XmlElement("pageSize")]
        //[JsonProperty("pageSize")]
        //public Int64 PageSize
        //{
        //    get;
        //    set;
        //}

        public override String ApiName
        {
            get{ return "jingdong.im.pop.chatlog.get"; }
        }

        protected override void PrepareParam(IDictionary<String, Object> paramters)
        {
            paramters.Add("waiter" ,this.Waiter);
            paramters.Add("customer" ,this.Customer);
           // paramters.Add("skuId" ,this.SkuId);
            paramters.Add("startTime" ,this.StartTime);
            paramters.Add("endTime" ,this.EndTime);
           // paramters.Add("page" ,this.Page);
            //paramters.Add("pageSize" ,this.PageSize);
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("waiter", this.Waiter);
            RequestValidator.ValidateRequired("customer", this.Customer);
            RequestValidator.ValidateRequired("startTime", this.StartTime);
            RequestValidator.ValidateRequired("endTime", this.EndTime);
           // RequestValidator.ValidateRequired("page", this.Page);
           // RequestValidator.ValidateRequired("pageSize", this.PageSize);
        }

    }
}
