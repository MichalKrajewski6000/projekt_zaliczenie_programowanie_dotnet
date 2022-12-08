namespace Projekt_Blog
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            comments = new HashSet<comment>();
            posts = new HashSet<post>();
        }

        [Key]
        public int user_id { get; set; }

        public int role_id { get; set; }

        [Required]
        [StringLength(45)]
        public string nick { get; set; }

        [Required]
        [StringLength(20)]
        public string haslo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? data_rej { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comment> comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<post> posts { get; set; }

        public virtual role role { get; set; }
    }
}
