//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HainadeblanaSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Adresa_Facturare
    {
        public int AdresaFacturareID { get; set; }
        public Nullable<int> ComandaID { get; set; }
        public string Adresa { get; set; }
    
        public virtual Comanda Comanda { get; set; }
    }
}
