using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.sizetable{
	
	
	
	
	
	public class SizeTable {
		
		///<summary>
		/// 尺码表ID
		///</summary>
		
		private long? size_table_id_;
		
		///<summary>
		/// 1：标准尺码表，2：自定义
		///</summary>
		
		private short? size_table_type_;
		
		///<summary>
		/// Html内容，类型为2时有效
		///</summary>
		
		private string size_table_html_;
		
		///<summary>
		/// 温馨提示，类型为1时有效
		///</summary>
		
		private string size_table_tips_;
		
		///<summary>
		/// 删除标记(默认0，1已删除)
		///</summary>
		
		private short? del_flag_;
		
		public long? GetSize_table_id(){
			return this.size_table_id_;
		}
		
		public void SetSize_table_id(long? value){
			this.size_table_id_ = value;
		}
		public short? GetSize_table_type(){
			return this.size_table_type_;
		}
		
		public void SetSize_table_type(short? value){
			this.size_table_type_ = value;
		}
		public string GetSize_table_html(){
			return this.size_table_html_;
		}
		
		public void SetSize_table_html(string value){
			this.size_table_html_ = value;
		}
		public string GetSize_table_tips(){
			return this.size_table_tips_;
		}
		
		public void SetSize_table_tips(string value){
			this.size_table_tips_ = value;
		}
		public short? GetDel_flag(){
			return this.del_flag_;
		}
		
		public void SetDel_flag(short? value){
			this.del_flag_ = value;
		}
		
	}
	
}