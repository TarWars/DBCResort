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
    
    public partial class guest
    {
        public guest()
        {
            this.reservations = new HashSet<reservation>();
        }
    
        public int idGuest { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string CreditCardNum { get; set; }
        public Nullable<System.DateTime> DateOfExpiration { get; set; }
    
        public virtual ICollection<reservation> reservations { get; set; }
    }
}