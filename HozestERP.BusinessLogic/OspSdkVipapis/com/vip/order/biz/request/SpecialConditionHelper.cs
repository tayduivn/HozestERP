using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class SpecialConditionHelper : TBeanSerializer<SpecialCondition>
	{
		
		public static SpecialConditionHelper OBJ = new SpecialConditionHelper();
		
		public static SpecialConditionHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SpecialCondition structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("relType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRelType(value);
					}
					
					
					
					
					
					if ("conditionItems".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.request.ConditionItem> value;
						
						value = new List<com.vip.order.biz.request.ConditionItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.request.ConditionItem elem0;
								
								elem0 = new com.vip.order.biz.request.ConditionItem();
								com.vip.order.biz.request.ConditionItemHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetConditionItems(value);
					}
					
					
					
					
					
					if ("subConditions".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.request.SubCondition> value;
						
						value = new List<com.vip.order.biz.request.SubCondition>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.request.SubCondition elem2;
								
								elem2 = new com.vip.order.biz.request.SubCondition();
								com.vip.order.biz.request.SubConditionHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSubConditions(value);
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
		
		
		public void Write(SpecialCondition structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetRelType() != null) {
				
				oprot.WriteFieldBegin("relType");
				oprot.WriteString(structs.GetRelType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetConditionItems() != null) {
				
				oprot.WriteFieldBegin("conditionItems");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.request.ConditionItem _item0 in structs.GetConditionItems()){
					
					
					com.vip.order.biz.request.ConditionItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSubConditions() != null) {
				
				oprot.WriteFieldBegin("subConditions");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.request.SubCondition _item0 in structs.GetSubConditions()){
					
					
					com.vip.order.biz.request.SubConditionHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SpecialCondition bean){
			
			
		}
		
	}
	
}