//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eSportsTracker.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SponsoredBy
    {
        public int PlayerID { get; set; }
        public int OrgID { get; set; }
        public int SponsoredByID { get; set; }
    
        public virtual Organization Organization { get; set; }
        public virtual Player Player { get; set; }
    }
}
