//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace isp_management.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User_StatusTB
    {
        public User_StatusTB()
        {
            this.UserTBs = new HashSet<UserTB>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<UserTB> UserTBs { get; set; }
    }
}