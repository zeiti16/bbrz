﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bbrz_projekt
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IGDBEntities : DbContext
    {
        public IGDBEntities()
            : base("name=IGDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblGame> tblGame { get; set; }
        public virtual DbSet<tblGenre> tblGenre { get; set; }
        public virtual DbSet<tblImage> tblImage { get; set; }
        public virtual DbSet<tblPublisher> tblPublisher { get; set; }
        public virtual DbSet<tblRating> tblRating { get; set; }
        public virtual DbSet<tblUser> tblUser { get; set; }
        public virtual DbSet<vUser> vUser { get; set; }
    }
}