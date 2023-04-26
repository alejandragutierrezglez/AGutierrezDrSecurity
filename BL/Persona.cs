using CURP.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CURP;
using CURP.Enums;

namespace BL
{
    public class Persona
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezDrSecurityEntities context = new DL.AGutierrezDrSecurityEntities())
                {
                    var query = context.PersonaGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var resultPersona in query)
                        {
                            ML.Persona persona = new ML.Persona();
                            persona.IdPersona = resultPersona.IdPersona;
                            persona.Nombre = resultPersona.Nombre;
                            persona.PrimerApellido = resultPersona.PrimerApellido;
                            persona.SegundoApellido = resultPersona.SegundoApellido;
                            persona.FechaNacimiento = resultPersona.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                            persona.Sexo = resultPersona.Sexo;
                            persona.EstadoNacimiento = resultPersona.EstadoNacimiento;
                            persona.Telefono = resultPersona.Telefono;
                            persona.CURP = resultPersona.CURP;
                            persona.NombreCompleto = persona.Nombre + persona.PrimerApellido + persona.SegundoApellido;

                            persona.Direccion = new ML.Direccion();
                            persona.Direccion.IdDireccion = resultPersona.IdDireccion;
                            persona.Direccion.EstadoCiudad = resultPersona.EstadoCiudad;
                            persona.Direccion.DelegacionMunicipio = resultPersona.DelegacionMunicipio;
                            persona.Direccion.Colonia = resultPersona.Colonia;
                            persona.Direccion.Calle = resultPersona.Calle;
                            persona.Direccion.Numero = resultPersona.Numero;
                            persona.Direccion.DireccionCompleta = persona.Direccion.Calle + persona.Direccion.Numero + persona.Direccion.Colonia + persona.Direccion.DelegacionMunicipio + persona.Direccion.EstadoCiudad;


                            result.Objects.Add(persona);

                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.ErrorMessage = Ex.Message;
                result.Correct = false;
                result.Ex = Ex;
            }
            return result;

        }
        public static ML.Result GetById(int IdPersona)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezDrSecurityEntities context = new DL.AGutierrezDrSecurityEntities())
                {
                    var query = context.PersonaGetById(IdPersona).FirstOrDefault();

                    if (query != null)
                    {

                        ML.Persona persona = new ML.Persona();
                        persona.IdPersona = query.IdPersona;
                        persona.Nombre = query.Nombre;
                        persona.PrimerApellido = query.PrimerApellido;
                        persona.SegundoApellido = query.SegundoApellido;
                        persona.FechaNacimiento = query.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                        persona.Sexo = query.Sexo;
                        persona.EstadoNacimiento = query.EstadoNacimiento;
                        persona.Telefono = query.Telefono;
                        persona.CURP = query.CURP;
                        persona.NombreCompleto = persona.Nombre + persona.PrimerApellido + persona.SegundoApellido;

                        persona.Direccion = new ML.Direccion();
                        persona.Direccion.IdDireccion = query.IdDireccion;
                        persona.Direccion.EstadoCiudad = query.EstadoCiudad;
                        persona.Direccion.DelegacionMunicipio = query.DelegacionMunicipio;
                        persona.Direccion.Colonia = query.Colonia;
                        persona.Direccion.Calle = query.Calle;
                        persona.Direccion.Numero = query.Numero;
                        persona.Direccion.DireccionCompleta = persona.Direccion.Calle + persona.Direccion.Numero + persona.Direccion.Colonia + persona.Direccion.DelegacionMunicipio + persona.Direccion.EstadoCiudad;


                        result.Object = persona;


                        result.Correct = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.ErrorMessage = Ex.Message;
                result.Correct = false;
                result.Ex = Ex;
            }
            return result;

        }

        public static ML.Result Add(ML.Persona persona)
        {
            ML.Result result = new ML.Result();
            persona.CURP = GenerarCurp(persona);

            try
            {
                using (DL.AGutierrezDrSecurityEntities context = new DL.AGutierrezDrSecurityEntities())
                {
                    var query = context.PersonaAdd(persona.Nombre, persona.PrimerApellido, persona.SegundoApellido, DateTime.Parse(persona.FechaNacimiento), persona.Sexo, persona.EstadoNacimiento, persona.Telefono, persona.CURP, persona.Direccion.EstadoCiudad, persona.Direccion.DelegacionMunicipio, persona.Direccion.Colonia, persona.Direccion.Calle, persona.Direccion.Numero);

                    if (query > 0)
                    {
                        result.Correct = true;

                    }
                    else
                    {

                        result.Correct = false;
                    }

                }

            }
            catch (Exception Ex)
            {
                result.ErrorMessage = Ex.Message;
                result.Correct = false;
                result.Ex = Ex;
            }
            return result;

        }

        public static ML.Result Update(ML.Persona persona)
        {
            ML.Result result = new ML.Result();
            persona.CURP = GenerarCurp(persona);
            try
            {
                using (DL.AGutierrezDrSecurityEntities context = new DL.AGutierrezDrSecurityEntities())
                {
                    var query = context.PersonaUpdate(persona.IdPersona, persona.Nombre, persona.PrimerApellido, persona.SegundoApellido, DateTime.Parse(persona.FechaNacimiento), persona.Sexo, persona.EstadoNacimiento, persona.Telefono, persona.CURP, persona.Direccion.EstadoCiudad, persona.Direccion.DelegacionMunicipio, persona.Direccion.Colonia, persona.Direccion.Calle, persona.Direccion.Numero);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }
            catch (Exception Ex)
            {
                result.ErrorMessage = Ex.Message;
                result.Correct = false;
                result.Ex = Ex;
            }
            return result;
        }

        public static ML.Result Delete(int IdPersona)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezDrSecurityEntities context = new DL.AGutierrezDrSecurityEntities())
                {
                    var query = context.PersonaDelete(IdPersona);
                    if (query > 0)
                    {

                        result.Correct = true;
                    }
                    else
                    {

                        result.Correct = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.ErrorMessage = Ex.Message;
                result.Correct = false;
                result.Ex = Ex;
                throw;
            }
            return result;
        }

        public static string GenerarCurp(ML.Persona persona)
        {          
            ML.Result result = new ML.Result();
            try
            {
                Estado estado;
                Sexo sexo;
                
                Enum.TryParse(persona.EstadoNacimiento, out estado);
                Enum.TryParse(persona.Sexo, out sexo);

                if (persona.Sexo == "M")
                {
                    sexo = Sexo.Mujer;
                }
                if (persona.Sexo == "H")
                {
                    sexo = Sexo.Hombre;
                
                }           
                string CURP = Curp.Generar(persona.Nombre, persona.PrimerApellido, persona.SegundoApellido, sexo, DateTime.Parse(persona.FechaNacimiento), estado);
              
                persona.CURP= CURP;               
                            
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
                result.Ex = Ex;
            }

            return persona.CURP;
        }
    }
}
