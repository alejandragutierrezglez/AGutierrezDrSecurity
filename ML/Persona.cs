using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Persona
    {
        public int? IdPersona { get; set; }
        [Required(ErrorMessage ="Este campo es requerido.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string EstadoNacimiento { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Telefono { get; set; }
        public string CURP { get; set; }
        public string NombreCompleto { get; set; }
        public ML.Direccion Direccion { get; set; }
        public List<object> Personas { get; set; }
    }
}
