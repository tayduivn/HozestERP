using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.dvd{
	
	
	
	
	
	public class AreaOccupiedOrderResponse {
		
		///<summary>
		/// 是否有下页 true:有 false:无
		///</summary>
		
		private bool? has_next_;
		
		///<summary>
		/// 商品订单列表
		///</summary>
		
		private List<vipapis.dvd.AreaOccupiedOrder> occupied_orders_;
		
		public bool? GetHas_next(){
			return this.has_next_;
		}
		
		public void SetHas_next(bool? value){
			this.has_next_ = value;
		}
		public List<vipapis.dvd.AreaOccupiedOrder> GetOccupied_orders(){
			return this.occupied_orders_;
		}
		
		public void SetOccupied_orders(List<vipapis.dvd.AreaOccupiedOrder> value){
			this.occupied_orders_ = value;
		}
		
	}
	
}