//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class SongPlay
    {
        public int AccountId { get; set; }
        public int SongId { get; set; }
        public int NumberOfPlays { get; set; }
        public System.DateTime DatePlayed { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Song Song { get; set; }
    }
}