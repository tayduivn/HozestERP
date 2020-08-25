using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.finance{
	
	
	
	public class ErrorHelper : TBeanSerializer<Error>
	{
		
		public static ErrorHelper OBJ = new ErrorHelper();
		
		public static ErrorHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Error structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("promotion_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPromotion_type(value);
					}
					
					
					
					
					
					if ("promotion_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPromotion_name(value);
					}
					
					
					
					
					
					if ("promotion_description".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPromotion_description(value);
					}
					
					
					
					
					
					if ("error_msg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetError_msg(value);
					}
					
					
					
					
					if(needSkip){
						
						ProtocolUtil.skip(iprot);
					}
					
					iprot.ReadFieldEnd();
				}
				
				iprot.ReadStructEnd();
				Validate(structs);
			}
			else{
				
				throw new OspException();
			}
			
			
		}
		
		
		public void Write(Error structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPromotion_type() != null) {
				
				oprot.WriteFieldBegin("promotion_type");
				oprot.WriteString(structs.GetPromotion_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPromotion_name() != null) {
				
				oprot.WriteFieldBegin("promotion_name");
				oprot.WriteString(structs.GetPromotion_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPromotion_description() != null) {
				
				oprot.WriteFieldBegin("promotion_description");
				oprot.WriteString(structs.GetPromotion_description());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetError_msg() != null) {
				
				oprot.WriteFieldBegin("error_msg");
				oprot.WriteString(structs.GetError_msg());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Error bean){
			
			
		}
		
	}
	
}