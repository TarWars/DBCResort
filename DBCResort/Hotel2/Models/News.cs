
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Hotel2.Models
{

using System;
    using System.Collections.Generic;
    
public partial class News
{

    public int idNews { get; set; }

    public int idEmpoyee { get; set; }

    public System.DateTime DateOfStart { get; set; }

    public System.DateTime DateOfEnd { get; set; }

    public string Text { get; set; }

    public string ImgLink { get; set; }

    public string Place { get; set; }



    public virtual Employee Employee { get; set; }

}

}
