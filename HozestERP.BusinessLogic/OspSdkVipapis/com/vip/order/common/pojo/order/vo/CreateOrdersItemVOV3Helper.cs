using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class CreateOrdersItemVOV3Helper : TBeanSerializer<CreateOrdersItemVOV3>
	{
		
		public static CreateOrdersItemVOV3Helper OBJ = new CreateOrdersItemVOV3Helper();
		
		public static CreateOrdersItemVOV3Helper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CreateOrdersItemVOV3 structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("orderId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderId(value);
					}
					
					
					
					
					
					if ("orderCategory".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderCategory(value);
					}
					
					
					
					
					
					if ("orderGroupSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderGroupSn(value);
					}
					
					
					
					
					
					if ("retCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRetCode(value);
					}
					
					
					
					
					
					if ("retMessage".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRetMessage(value);
					}
					
					
					
					
					
					if ("orderCodeList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderCodeVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderCodeVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderCodeVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.OrderCodeVO();
								com.vip.order.common.pojo.order.vo.OrderCodeVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderCodeList(value);
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
		
		
		public void Write(CreateOrdersItemVOV3 structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderId() != null) {
				
				oprot.WriteFieldBegin("orderId");
				oprot.WriteI64((long)structs.GetOrderId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderCategory() != null) {
				
				oprot.WriteFieldBegin("orderCategory");
				oprot.WriteI32((int)structs.GetOrderCategory()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderGroupSn() != null) {
				
				oprot.WriteFieldBegin("orderGroupSn");
				oprot.WriteString(structs.GetOrderGroupSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRetCode() != null) {
				
				oprot.WriteFieldBegin("retCode");
				oprot.WriteString(structs.GetRetCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRetMessage() != null) {
				
				oprot.WriteFieldBegin("retMessage");
				oprot.WriteString(structs.GetRetMessage());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderCodeList() != null) {
				
				oprot.WriteFieldBegin("orderCodeList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderCodeVO _item0 in structs.GetOrderCodeList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderCodeVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CreateOrdersItemVOV3 bean){
			
			
		}
		
	}
	
}