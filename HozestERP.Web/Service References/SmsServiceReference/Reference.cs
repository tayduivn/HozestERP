﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HozestERP.Web.SmsServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://sms.wx360.bjfzq.com/", ConfigurationName="SmsServiceReference.SmsServices")]
    public interface SmsServices {
        
        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        HozestERP.Web.SmsServiceReference.sendSmsResponse sendSms(HozestERP.Web.SmsServiceReference.sendSms request);
        
        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        HozestERP.Web.SmsServiceReference.queryBalanceResponse queryBalance(HozestERP.Web.SmsServiceReference.queryBalance request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sms.wx360.bjfzq.com/")]
    public partial class smsResult : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int resultField;
        
        private string result_descField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public int result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
                this.RaisePropertyChanged("result");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string result_desc {
            get {
                return this.result_descField;
            }
            set {
                this.result_descField = value;
                this.RaisePropertyChanged("result_desc");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("value");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendSms", WrapperNamespace="http://sms.wx360.bjfzq.com/", IsWrapped=true)]
    public partial class sendSms {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://sms.wx360.bjfzq.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string loginid;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://sms.wx360.bjfzq.com/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string loginpwd;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://sms.wx360.bjfzq.com/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string content;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://sms.wx360.bjfzq.com/", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sign;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://sms.wx360.bjfzq.com/", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string mobiles;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://sms.wx360.bjfzq.com/", Order=5)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sendtime;
        
        public sendSms() {
        }
        
        public sendSms(string loginid, string loginpwd, string content, string sign, string mobiles, string sendtime) {
            this.loginid = loginid;
            this.loginpwd = loginpwd;
            this.content = content;
            this.sign = sign;
            this.mobiles = mobiles;
            this.sendtime = sendtime;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendSmsResponse", WrapperNamespace="http://sms.wx360.bjfzq.com/", IsWrapped=true)]
    public partial class sendSmsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://sms.wx360.bjfzq.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public HozestERP.Web.SmsServiceReference.smsResult @return;
        
        public sendSmsResponse() {
        }
        
        public sendSmsResponse(HozestERP.Web.SmsServiceReference.smsResult @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="queryBalance", WrapperNamespace="http://sms.wx360.bjfzq.com/", IsWrapped=true)]
    public partial class queryBalance {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://sms.wx360.bjfzq.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string loginid;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://sms.wx360.bjfzq.com/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string loginpwd;
        
        public queryBalance() {
        }
        
        public queryBalance(string loginid, string loginpwd) {
            this.loginid = loginid;
            this.loginpwd = loginpwd;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="queryBalanceResponse", WrapperNamespace="http://sms.wx360.bjfzq.com/", IsWrapped=true)]
    public partial class queryBalanceResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://sms.wx360.bjfzq.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public HozestERP.Web.SmsServiceReference.smsResult @return;
        
        public queryBalanceResponse() {
        }
        
        public queryBalanceResponse(HozestERP.Web.SmsServiceReference.smsResult @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SmsServicesChannel : HozestERP.Web.SmsServiceReference.SmsServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SmsServicesClient : System.ServiceModel.ClientBase<HozestERP.Web.SmsServiceReference.SmsServices>, HozestERP.Web.SmsServiceReference.SmsServices {
        
        public SmsServicesClient() {
        }
        
        public SmsServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SmsServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SmsServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SmsServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HozestERP.Web.SmsServiceReference.sendSmsResponse HozestERP.Web.SmsServiceReference.SmsServices.sendSms(HozestERP.Web.SmsServiceReference.sendSms request) {
            return base.Channel.sendSms(request);
        }
        
        public HozestERP.Web.SmsServiceReference.smsResult sendSms(string loginid, string loginpwd, string content, string sign, string mobiles, string sendtime) {
            HozestERP.Web.SmsServiceReference.sendSms inValue = new HozestERP.Web.SmsServiceReference.sendSms();
            inValue.loginid = loginid;
            inValue.loginpwd = loginpwd;
            inValue.content = content;
            inValue.sign = sign;
            inValue.mobiles = mobiles;
            inValue.sendtime = sendtime;
            HozestERP.Web.SmsServiceReference.sendSmsResponse retVal = ((HozestERP.Web.SmsServiceReference.SmsServices)(this)).sendSms(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HozestERP.Web.SmsServiceReference.queryBalanceResponse HozestERP.Web.SmsServiceReference.SmsServices.queryBalance(HozestERP.Web.SmsServiceReference.queryBalance request) {
            return base.Channel.queryBalance(request);
        }
        
        public HozestERP.Web.SmsServiceReference.smsResult queryBalance(string loginid, string loginpwd) {
            HozestERP.Web.SmsServiceReference.queryBalance inValue = new HozestERP.Web.SmsServiceReference.queryBalance();
            inValue.loginid = loginid;
            inValue.loginpwd = loginpwd;
            HozestERP.Web.SmsServiceReference.queryBalanceResponse retVal = ((HozestERP.Web.SmsServiceReference.SmsServices)(this)).queryBalance(inValue);
            return retVal.@return;
        }
    }
}
