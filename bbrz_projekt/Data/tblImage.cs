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
    
    public partial class tblImage
    {
        public int Image_ID { get; set; }
        public byte[] ImageData { get; set; }
        public Nullable<int> FK_Game { get; set; }
    
        public virtual tblGame tblGame { get; set; }
    }
}
