//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBCResort.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class news
    {
        public int idNews { get; set; }
        public int Employee_idEmployee { get; set; }
        public Nullable<System.DateTime> DateOfStart { get; set; }
        public Nullable<System.DateTime> DateOfEnd { get; set; }
        public string Text { get; set; }
        public string ImgLink { get; set; }
        public string Place { get; set; }
    
        public virtual employee employee { get; set; }
    }
}