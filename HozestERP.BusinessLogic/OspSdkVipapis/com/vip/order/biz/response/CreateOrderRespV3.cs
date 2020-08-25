using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class CreateOrderRespV3 {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 订单号列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.CreateOrdersItemVOV3> orderIdSnList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.CreateOrdersItemVOV3> GetOrderIdSnList(){
			return this.orderIdSnList_;
		}
		
		public void SetOrderIdSnList(List<com.vip.order.common.pojo.order.vo.CreateOrdersItemVOV3> value){
			this.orderIdSnList_ = value;
		}
		
	}
	
}