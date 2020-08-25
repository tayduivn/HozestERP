using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class OrderReturnResponseHelper : TBeanSerializer<OrderReturnResponse>
	{
		
		public static OrderReturnResponseHelper OBJ = new OrderReturnResponseHelper();
		
		public static OrderReturnResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderReturnResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_return_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.OrderReturn> value;
						
						value = new List<vipapis.delivery.OrderReturn>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.OrderReturn elem0;
								
								elem0 = new vipapis.delivery.OrderReturn();
								vipapis.delivery.OrderReturnHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrder_return_list(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
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
		
		
		public void Write(OrderReturnResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_return_list() != null) {
				
				oprot.WriteFieldBegin("order_return_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.OrderReturn _item0 in structs.GetOrder_return_list()){
					
					
					vipapis.delivery.OrderReturnHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderReturnResponse bean){
			
			
		}
		
	}
	
}