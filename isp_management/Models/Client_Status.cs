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
    
    public partial class Client_Status
    {
        public Client_Status()
        {
            this.Clients = new HashSet<Client>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Client> Clients { get; set; }
    }
}
