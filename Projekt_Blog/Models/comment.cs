//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projekt_Blog.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class comment
    {
        public int id_comment { get; set; }
        public int post_id { get; set; }
        public int user_id { get; set; }
        public string Tresc { get; set; }
    
        public virtual post post { get; set; }
        public virtual user user { get; set; }
    }
}