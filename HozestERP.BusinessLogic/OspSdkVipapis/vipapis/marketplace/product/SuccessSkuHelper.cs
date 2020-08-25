using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class SuccessSkuHelper : TBeanSerializer<SuccessSku>
	{
		
		public static SuccessSkuHelper OBJ = new SuccessSkuHelper();
		
		public static SuccessSkuHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SuccessSku structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sku_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSku_id(value);
					}
					
					
					
					
					
					if ("outer_sku_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOuter_sku_id(value);
					}
					
					
					
					
					
					if ("simple_sale_props".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.product.SimpleProperty> value;
						
						value = new List<vipapis.marketplace.product.SimpleProperty>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.product.SimpleProperty elem0;
								
								elem0 = new vipapis.marketplace.product.SimpleProperty();
								vipapis.marketplace.product.SimplePropertyHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSimple_sale_props(value);
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
		
		
		public void Write(SuccessSku structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSku_id() != null) {
				
				oprot.WriteFieldBegin("sku_id");
				oprot.WriteString(structs.GetSku_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sku_id can not be null!");
			}
			
			
			if(structs.GetOuter_sku_id() != null) {
				
				oprot.WriteFieldBegin("outer_sku_id");
				oprot.WriteString(structs.GetOuter_sku_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSimple_sale_props() != null) {
				
				oprot.WriteFieldBegin("simple_sale_props");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.product.SimpleProperty _item0 in structs.GetSimple_sale_props()){
					
					
					vipapis.marketplace.product.SimplePropertyHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SuccessSku bean){
			
			
		}
		
	}
	
}