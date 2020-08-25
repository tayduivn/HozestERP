using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class CancelledOrdersResponseHelper : TBeanSerializer<CancelledOrdersResponse>
	{
		
		public static CancelledOrdersResponseHelper OBJ = new CancelledOrdersResponseHelper();
		
		public static CancelledOrdersResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CancelledOrdersResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("has_next".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool value;
						value = iprot.ReadBool();
						
						structs.SetHas_next(value);
					}
					
					
					
					
					
					if ("occupied_orders".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.order.OccupiedOrder> value;
						
						value = new List<vipapis.order.OccupiedOrder>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.order.OccupiedOrder elem1;
								
								elem1 = new vipapis.order.OccupiedOrder();
								vipapis.order.OccupiedOrderHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOccupied_orders(value);
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
		
		
		public void Write(CancelledOrdersResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetHas_next() != null) {
				
				oprot.WriteFieldBegin("has_next");
				oprot.WriteBool((bool)structs.GetHas_next());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("has_next can not be null!");
			}
			
			
			if(structs.GetOccupied_orders() != null) {
				
				oprot.WriteFieldBegin("occupied_orders");
				
				oprot.WriteListBegin();
				foreach(vipapis.order.OccupiedOrder _item0 in structs.GetOccupied_orders()){
					
					
					vipapis.order.OccupiedOrderHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CancelledOrdersResponse bean){
			
			
		}
		
	}
	
}