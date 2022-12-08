using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Projekt_Blog
{
    public partial class SoulsborneBlogContext : DbContext
    {
        public SoulsborneBlogContext()
            : base("name=SoulsborneBlogContext")
        {
        }

        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<post> posts { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .Property(e => e.Kategoria)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .Property(e => e.Opis)
                .IsUnicode(false);

            modelBuilder.Entity<comment>()
                .Property(e => e.Tresc)
                .IsUnicode(false);

            modelBuilder.Entity<post>()
                .Property(e => e.Temat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<post>()
                .Property(e => e.Gra)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<post>()
                .Property(e => e.Tresc)
                .IsUnicode(false);

            modelBuilder.Entity<post>()
                .Property(e => e.data_dodania)
                .HasPrecision(0);

            modelBuilder.Entity<role>()
                .Property(e => e.Rola)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.opis)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.nick)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.haslo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.comments)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);
        }
    }
}
