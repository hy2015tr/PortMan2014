//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PortMan2014
{
    using System;
    using System.Collections.Generic;
    
    public partial class TableSession
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> SessionStart { get; set; }
        public Nullable<System.DateTime> SessionFinish { get; set; }
        public Nullable<long> ElapsedTime { get; set; }
        public string UserName { get; set; }
        public string PCName { get; set; }
        public string IPAddress { get; set; }
        public string AppVersion { get; set; }
        public string NetVersion { get; set; }
        public string Status { get; set; }
    }
}
