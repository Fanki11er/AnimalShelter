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
    
    public partial class Leczenie
    {
        public int Lec_GIDNumer { get; set; }
        public int Lec_GIDLp { get; set; }
        public string Lec_Opis { get; set; }
    
        public virtual KsiazeczkaZdrowiaElem KsiazeczkaZdrowiaElem { get; set; }
        public virtual KsiazeczkaZdrowiaNag KsiazeczkaZdrowiaNag { get; set; }
    }
}
