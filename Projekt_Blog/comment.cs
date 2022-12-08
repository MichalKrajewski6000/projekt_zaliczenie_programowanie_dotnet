namespace Projekt_Blog
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class comment
    {
        [Key]
        public int id_comment { get; set; }

        public int post_id { get; set; }

        public int user_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Tresc { get; set; }

        public virtual post post { get; set; }

        public virtual user user { get; set; }
    }
}
