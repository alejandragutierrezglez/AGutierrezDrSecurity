//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Direccion
    {
        public int IdDireccion { get; set; }
        public string EstadoCiudad { get; set; }
        public string DelegacionMunicipio { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public Nullable<int> IdPersona { get; set; }
    
        public virtual Persona Persona { get; set; }
    }
}
