//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnimalShelter.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KsiazeczkaZdrowiaElem
    {
        public int KzE_GIDNumer { get; set; }
        public int KzE_GIDLp { get; set; }
        public string KzE_OpisBadania { get; set; }
        public string KzE_WynikBadania { get; set; }
        public System.DateTime KzE_DataBadania { get; set; }
    
        public virtual KsiazeczkaZdrowiaNag KsiazeczkaZdrowiaNag { get; set; }
        public virtual Leczenie Leczenie { get; set; }
    }
}