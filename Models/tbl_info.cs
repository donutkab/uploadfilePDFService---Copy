//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace uploadfilePDFService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_info
    {
        public int tr_id { get; set; }
        public string citizen { get; set; }
        public string identify { get; set; }
        public string status { get; set; }
        public string process { get; set; }
        public string organization { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public Nullable<System.DateTime> updated_date { get; set; }
    }
}