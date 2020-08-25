//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using HozestERP.BusinessLogic.ManageFile;


namespace HozestERP.BusinessLogic.Data
{
    #region 上下文
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    public partial class HozestERPObjectContext : ObjectContext
    {
    
        #region 函数导入
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        /// <param name="objectID">没有元数据文档可用。</param>
        /// <param name="taggantID">没有元数据文档可用。</param>
        /// <param name="tableName">没有元数据文档可用。</param>
        public ObjectResult<UploadFile> GetUploadFileList(Nullable<global::System.Int32> objectID, Nullable<global::System.Guid> taggantID, global::System.String tableName)
        {
            ObjectParameter objectIDParameter;
            if (objectID.HasValue)
            {
                objectIDParameter = new ObjectParameter("ObjectID", objectID);
            }
            else
            {
                objectIDParameter = new ObjectParameter("ObjectID", typeof(global::System.Int32));
            }
    
            ObjectParameter taggantIDParameter;
            if (taggantID.HasValue)
            {
                taggantIDParameter = new ObjectParameter("TaggantID", taggantID);
            }
            else
            {
                taggantIDParameter = new ObjectParameter("TaggantID", typeof(global::System.Guid));
            }
    
            ObjectParameter tableNameParameter;
            if (tableName != null)
            {
                tableNameParameter = new ObjectParameter("TableName", tableName);
            }
            else
            {
                tableNameParameter = new ObjectParameter("TableName", typeof(global::System.String));
            }
    
            return base.ExecuteFunction<UploadFile>("GetUploadFileList", objectIDParameter, taggantIDParameter, tableNameParameter);
        }
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        /// <param name="mergeOption"></param>
        /// <param name="objectID">没有元数据文档可用。</param>
        /// <param name="taggantID">没有元数据文档可用。</param>
        /// <param name="tableName">没有元数据文档可用。</param>
        public ObjectResult<UploadFile> GetUploadFileList(Nullable<global::System.Int32> objectID, Nullable<global::System.Guid> taggantID, global::System.String tableName, MergeOption mergeOption)
        {
            ObjectParameter objectIDParameter;
            if (objectID.HasValue)
            {
                objectIDParameter = new ObjectParameter("ObjectID", objectID);
            }
            else
            {
                objectIDParameter = new ObjectParameter("ObjectID", typeof(global::System.Int32));
            }
    
            ObjectParameter taggantIDParameter;
            if (taggantID.HasValue)
            {
                taggantIDParameter = new ObjectParameter("TaggantID", taggantID);
            }
            else
            {
                taggantIDParameter = new ObjectParameter("TaggantID", typeof(global::System.Guid));
            }
    
            ObjectParameter tableNameParameter;
            if (tableName != null)
            {
                tableNameParameter = new ObjectParameter("TableName", tableName);
            }
            else
            {
                tableNameParameter = new ObjectParameter("TableName", typeof(global::System.String));
            }
    
            return base.ExecuteFunction<UploadFile>("GetUploadFileList", mergeOption, objectIDParameter, taggantIDParameter, tableNameParameter);
        }
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        /// <param name="objectID">没有元数据文档可用。</param>
        /// <param name="taggantID">没有元数据文档可用。</param>
        /// <param name="tableName">没有元数据文档可用。</param>
        public int UploadFileList(Nullable<global::System.Int32> objectID, Nullable<global::System.Guid> taggantID, global::System.String tableName)
        {
            ObjectParameter objectIDParameter;
            if (objectID.HasValue)
            {
                objectIDParameter = new ObjectParameter("ObjectID", objectID);
            }
            else
            {
                objectIDParameter = new ObjectParameter("ObjectID", typeof(global::System.Int32));
            }
    
            ObjectParameter taggantIDParameter;
            if (taggantID.HasValue)
            {
                taggantIDParameter = new ObjectParameter("TaggantID", taggantID);
            }
            else
            {
                taggantIDParameter = new ObjectParameter("TaggantID", typeof(global::System.Guid));
            }
    
            ObjectParameter tableNameParameter;
            if (tableName != null)
            {
                tableNameParameter = new ObjectParameter("TableName", tableName);
            }
            else
            {
                tableNameParameter = new ObjectParameter("TableName", typeof(global::System.String));
            }
    
            return base.ExecuteFunction("UploadFileList", objectIDParameter, taggantIDParameter, tableNameParameter);
        }
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        /// <param name="id">没有元数据文档可用。</param>
        /// <param name="agentAccountName">没有元数据文档可用。</param>
        /// <param name="password">没有元数据文档可用。</param>
        /// <param name="enabled">没有元数据文档可用。</param>
        /// <param name="createStaff">没有元数据文档可用。</param>
        /// <param name="createDate">没有元数据文档可用。</param>
        /// <param name="modifyStaff">没有元数据文档可用。</param>
        /// <param name="modifyDate">没有元数据文档可用。</param>
        public int SaveAgentAccount(Nullable<global::System.Int32> id, global::System.String agentAccountName, global::System.String password, Nullable<global::System.Int32> enabled, Nullable<global::System.Int32> createStaff, Nullable<global::System.DateTime> createDate, Nullable<global::System.Int32> modifyStaff, Nullable<global::System.DateTime> modifyDate)
        {
            ObjectParameter idParameter;
            if (id.HasValue)
            {
                idParameter = new ObjectParameter("id", id);
            }
            else
            {
                idParameter = new ObjectParameter("id", typeof(global::System.Int32));
            }
    
            ObjectParameter agentAccountNameParameter;
            if (agentAccountName != null)
            {
                agentAccountNameParameter = new ObjectParameter("agentAccountName", agentAccountName);
            }
            else
            {
                agentAccountNameParameter = new ObjectParameter("agentAccountName", typeof(global::System.String));
            }
    
            ObjectParameter passwordParameter;
            if (password != null)
            {
                passwordParameter = new ObjectParameter("password", password);
            }
            else
            {
                passwordParameter = new ObjectParameter("password", typeof(global::System.String));
            }
    
            ObjectParameter enabledParameter;
            if (enabled.HasValue)
            {
                enabledParameter = new ObjectParameter("enabled", enabled);
            }
            else
            {
                enabledParameter = new ObjectParameter("enabled", typeof(global::System.Int32));
            }
    
            ObjectParameter createStaffParameter;
            if (createStaff.HasValue)
            {
                createStaffParameter = new ObjectParameter("createStaff", createStaff);
            }
            else
            {
                createStaffParameter = new ObjectParameter("createStaff", typeof(global::System.Int32));
            }
    
            ObjectParameter createDateParameter;
            if (createDate.HasValue)
            {
                createDateParameter = new ObjectParameter("createDate", createDate);
            }
            else
            {
                createDateParameter = new ObjectParameter("createDate", typeof(global::System.DateTime));
            }
    
            ObjectParameter modifyStaffParameter;
            if (modifyStaff.HasValue)
            {
                modifyStaffParameter = new ObjectParameter("modifyStaff", modifyStaff);
            }
            else
            {
                modifyStaffParameter = new ObjectParameter("modifyStaff", typeof(global::System.Int32));
            }
    
            ObjectParameter modifyDateParameter;
            if (modifyDate.HasValue)
            {
                modifyDateParameter = new ObjectParameter("modifyDate", modifyDate);
            }
            else
            {
                modifyDateParameter = new ObjectParameter("modifyDate", typeof(global::System.DateTime));
            }
    
            return base.ExecuteFunction("SaveAgentAccount", idParameter, agentAccountNameParameter, passwordParameter, enabledParameter, createStaffParameter, createDateParameter, modifyStaffParameter, modifyDateParameter);
        }
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        /// <param name="agentAccountID">没有元数据文档可用。</param>
        /// <param name="customerID">没有元数据文档可用。</param>
        /// <param name="enabled">没有元数据文档可用。</param>
        /// <param name="createStaff">没有元数据文档可用。</param>
        /// <param name="createDate">没有元数据文档可用。</param>
        public int InsertAgentAccountUser(Nullable<global::System.Int32> agentAccountID, Nullable<global::System.Int32> customerID, Nullable<global::System.Int32> enabled, Nullable<global::System.Int32> createStaff, Nullable<global::System.DateTime> createDate)
        {
            ObjectParameter agentAccountIDParameter;
            if (agentAccountID.HasValue)
            {
                agentAccountIDParameter = new ObjectParameter("agentAccountID", agentAccountID);
            }
            else
            {
                agentAccountIDParameter = new ObjectParameter("agentAccountID", typeof(global::System.Int32));
            }
    
            ObjectParameter customerIDParameter;
            if (customerID.HasValue)
            {
                customerIDParameter = new ObjectParameter("customerID", customerID);
            }
            else
            {
                customerIDParameter = new ObjectParameter("customerID", typeof(global::System.Int32));
            }
    
            ObjectParameter enabledParameter;
            if (enabled.HasValue)
            {
                enabledParameter = new ObjectParameter("enabled", enabled);
            }
            else
            {
                enabledParameter = new ObjectParameter("enabled", typeof(global::System.Int32));
            }
    
            ObjectParameter createStaffParameter;
            if (createStaff.HasValue)
            {
                createStaffParameter = new ObjectParameter("createStaff", createStaff);
            }
            else
            {
                createStaffParameter = new ObjectParameter("createStaff", typeof(global::System.Int32));
            }
    
            ObjectParameter createDateParameter;
            if (createDate.HasValue)
            {
                createDateParameter = new ObjectParameter("createDate", createDate);
            }
            else
            {
                createDateParameter = new ObjectParameter("createDate", typeof(global::System.DateTime));
            }
    
            return base.ExecuteFunction("InsertAgentAccountUser", agentAccountIDParameter, customerIDParameter, enabledParameter, createStaffParameter, createDateParameter);
        }
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        /// <param name="oldContractID">没有元数据文档可用。</param>
        /// <param name="newContractID">没有元数据文档可用。</param>
        /// <param name="creatorID">没有元数据文档可用。</param>
        public int ContractRenewal(Nullable<global::System.Int32> oldContractID, Nullable<global::System.Int32> newContractID, Nullable<global::System.Int32> creatorID)
        {
            ObjectParameter oldContractIDParameter;
            if (oldContractID.HasValue)
            {
                oldContractIDParameter = new ObjectParameter("oldContractID", oldContractID);
            }
            else
            {
                oldContractIDParameter = new ObjectParameter("oldContractID", typeof(global::System.Int32));
            }
    
            ObjectParameter newContractIDParameter;
            if (newContractID.HasValue)
            {
                newContractIDParameter = new ObjectParameter("NewContractID", newContractID);
            }
            else
            {
                newContractIDParameter = new ObjectParameter("NewContractID", typeof(global::System.Int32));
            }
    
            ObjectParameter creatorIDParameter;
            if (creatorID.HasValue)
            {
                creatorIDParameter = new ObjectParameter("CreatorID", creatorID);
            }
            else
            {
                creatorIDParameter = new ObjectParameter("CreatorID", typeof(global::System.Int32));
            }
    
            return base.ExecuteFunction("ContractRenewal", oldContractIDParameter, newContractIDParameter, creatorIDParameter);
        }
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        /// <param name="id">没有元数据文档可用。</param>
        /// <param name="agentAccountName">没有元数据文档可用。</param>
        /// <param name="password">没有元数据文档可用。</param>
        /// <param name="enabled">没有元数据文档可用。</param>
        /// <param name="createStaff">没有元数据文档可用。</param>
        /// <param name="createDate">没有元数据文档可用。</param>
        /// <param name="modifyStaff">没有元数据文档可用。</param>
        /// <param name="modifyDate">没有元数据文档可用。</param>
        public int SaveAgentAccountTP(Nullable<global::System.Int32> id, global::System.String agentAccountName, global::System.String password, Nullable<global::System.Int32> enabled, Nullable<global::System.Int32> createStaff, Nullable<global::System.DateTime> createDate, Nullable<global::System.Int32> modifyStaff, Nullable<global::System.DateTime> modifyDate)
        {
            ObjectParameter idParameter;
            if (id.HasValue)
            {
                idParameter = new ObjectParameter("id", id);
            }
            else
            {
                idParameter = new ObjectParameter("id", typeof(global::System.Int32));
            }
    
            ObjectParameter agentAccountNameParameter;
            if (agentAccountName != null)
            {
                agentAccountNameParameter = new ObjectParameter("agentAccountName", agentAccountName);
            }
            else
            {
                agentAccountNameParameter = new ObjectParameter("agentAccountName", typeof(global::System.String));
            }
    
            ObjectParameter passwordParameter;
            if (password != null)
            {
                passwordParameter = new ObjectParameter("password", password);
            }
            else
            {
                passwordParameter = new ObjectParameter("password", typeof(global::System.String));
            }
    
            ObjectParameter enabledParameter;
            if (enabled.HasValue)
            {
                enabledParameter = new ObjectParameter("enabled", enabled);
            }
            else
            {
                enabledParameter = new ObjectParameter("enabled", typeof(global::System.Int32));
            }
    
            ObjectParameter createStaffParameter;
            if (createStaff.HasValue)
            {
                createStaffParameter = new ObjectParameter("createStaff", createStaff);
            }
            else
            {
                createStaffParameter = new ObjectParameter("createStaff", typeof(global::System.Int32));
            }
    
            ObjectParameter createDateParameter;
            if (createDate.HasValue)
            {
                createDateParameter = new ObjectParameter("createDate", createDate);
            }
            else
            {
                createDateParameter = new ObjectParameter("createDate", typeof(global::System.DateTime));
            }
    
            ObjectParameter modifyStaffParameter;
            if (modifyStaff.HasValue)
            {
                modifyStaffParameter = new ObjectParameter("modifyStaff", modifyStaff);
            }
            else
            {
                modifyStaffParameter = new ObjectParameter("modifyStaff", typeof(global::System.Int32));
            }
    
            ObjectParameter modifyDateParameter;
            if (modifyDate.HasValue)
            {
                modifyDateParameter = new ObjectParameter("modifyDate", modifyDate);
            }
            else
            {
                modifyDateParameter = new ObjectParameter("modifyDate", typeof(global::System.DateTime));
            }
    
            return base.ExecuteFunction("SaveAgentAccountTP", idParameter, agentAccountNameParameter, passwordParameter, enabledParameter, createStaffParameter, createDateParameter, modifyStaffParameter, modifyDateParameter);
        }

        #endregion
    }
    

    #endregion
    
    
}
