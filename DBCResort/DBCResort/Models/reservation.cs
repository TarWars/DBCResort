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
    
    public partial class reservation
    {
        public int idReservation { get; set; }
        public int Room_idRoom { get; set; }
        public int Guest_idGuest { get; set; }
        public int Employee_idEmployee { get; set; }
        public Nullable<System.DateTime> DateOfStart { get; set; }
        public Nullable<System.DateTime> DateOfEnd { get; set; }
        public string ExtraOptions { get; set; }
        public Nullable<int> NumOfGuests { get; set; }
        public Nullable<int> NumOfRooms { get; set; }
        public Nullable<double> Price { get; set; }
    
        public virtual employee employee { get; set; }
        public virtual guest guest { get; set; }
    }
}