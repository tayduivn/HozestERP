//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.Codes
{
    public partial class AreaCode : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the xmlid
        /// </summary>
        public int xmlid { get; set; }

        /// <summary>
        /// Gets or sets the NumberID
        /// </summary>
        public string NumberID { get; set; }

        /// <summary>
        /// Gets or sets the Root
        /// </summary>
        public string Root { get; set; }

        /// <summary>
        /// Gets or sets the Preceding
        /// </summary>
        public string Preceding { get; set; }

        /// <summary>
        /// Gets or sets the PrePath
        /// </summary>
        public string PrePath { get; set; }

        /// <summary>
        /// Gets or sets the Rank
        /// </summary>
        public Nullable<int> Rank { get; set; }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the CityType
        /// </summary>
        public string CityType { get; set; }

        /// <summary>
        /// Gets or sets the Govt
        /// </summary>
        public Nullable<int> Govt { get; set; }

        /// <summary>
        /// Gets or sets the Post
        /// </summary>
        public string Post { get; set; }

        /// <summary>
        /// Gets or sets the AreaID
        /// </summary>
        public string AreaID { get; set; }

        /// <summary>
        /// Gets or sets the shortening
        /// </summary>
        public string shortening { get; set; }

        /// <summary>
        /// Gets or sets the Spell
        /// </summary>
        public string Spell { get; set; }

        /// <summary>
        /// Gets or sets the KeyWord
        /// </summary>
        public string KeyWord { get; set; }

        /// <summary>
        /// Gets or sets the OrderStr
        /// </summary>
        public Nullable<int> OrderStr { get; set; }

        /// <summary>
        /// Gets or sets the Acreage
        /// </summary>
        public Nullable<decimal> Acreage { get; set; }

        /// <summary>
        /// Gets or sets the Population
        /// </summary>
        public Nullable<decimal> Population { get; set; }

        /// <summary>
        /// Gets or sets the Enabled
        /// </summary>
        public bool Enabled { get; set; }

        #endregion


        #region Custom Properties

        /// <summary>
        /// 
        /// </summary>
        public AreaCode ParentCategory
        {
            get
            {
                return IoC.Resolve<IAreaCodeService>().GetAreaByNumberID(this.Preceding);
            }
        }

        #endregion
    }
}
