//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BakeryMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BakeryLog
    {
        public int BakeryLogKey { get; set; }
        public Nullable<int> PersonKey { get; set; }
        public Nullable<System.DateTime> BakeryLogTimeStamp { get; set; }
    
        public virtual Person Person { get; set; }
    }
}
