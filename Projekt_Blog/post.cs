namespace Projekt_Blog
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public post()
        {
            comments = new HashSet<comment>();
        }

        [Key]
        public int post_id { get; set; }

        public int kategoria_id { get; set; }

        public int user_id { get; set; }

        [Required]
        [StringLength(30)]
        public string Temat { get; set; }

        [Required]
        [StringLength(30)]
        public string Gra { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Tresc { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? data_dodania { get; set; }

        public virtual category category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comment> comments { get; set; }

        public virtual user user { get; set; }
    }
}
