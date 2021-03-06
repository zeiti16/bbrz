//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bbrz_projekt.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblGame
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblGame()
        {
            this.tblRating = new HashSet<tblRating>();
            this.tblImage = new HashSet<tblImage>();
        }
    
        public int Game_ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Visible { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public byte[] CreatenDate { get; set; }
        public string FK_User { get; set; }
        public Nullable<int> FK_Genre { get; set; }
        public Nullable<int> FK_Publisher { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblRating> tblRating { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblImage> tblImage { get; set; }
        public virtual tblGenre tblGenre { get; set; }
        public virtual tblPublisher tblPublisher { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}
