using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string EstadoCiudad { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string DelegacionMunicipio { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Colonia { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string DireccionCompleta { get; set; }
        public ML.Persona Persona { get; set; }
    }
}
