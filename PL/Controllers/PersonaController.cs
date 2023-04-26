using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult GetAll()
        {
            ML.Result result = BL.Persona.GetAll();
            ML.Persona persona = new ML.Persona();

            if (result.Correct)
            {

                persona.Personas = result.Objects;
                return View(persona);
            }
            else
            {

                return View(persona);
            }
        }
        [HttpGet]
        public ActionResult Form(int? IdPersona)

        {
            ML.Result resultPersonas = BL.Persona.GetAll();
            ML.Persona persona = new ML.Persona();

            if (resultPersonas.Correct)
            {

                persona.Personas = resultPersonas.Objects;
            }
            if (IdPersona == null)
            {
                return View(persona);
            }
            else
            {
                ML.Result result = BL.Persona.GetById(IdPersona.Value);

                if (result.Correct)
                {

                    persona = (ML.Persona)result.Object;//unboxing
                    persona.Personas = resultPersonas.Objects;
                    //update
                    return View(persona);
                }
                else
                {
                    ViewBag.Message = "Ocurrio al consultar la información de la persona";
                    return View("Modal");
                }
            }

        }


        [HttpPost]
        public ActionResult Form(ML.Persona persona)
        {
            if (ModelState.IsValid == true)
            {
                ML.Result result = new ML.Result();
            

                if (persona.IdPersona != null)
                {
                    result = BL.Persona.Update(persona);
                    ViewBag.Message = "Se ha modificado el registro";
                }
                else
                {
                    result = BL.Persona.Add(persona);
                    ViewBag.Message = "Se ha agregado el registro";
                }
                if (result.Correct)
                {
                    return PartialView("Modal");
                }

                else
                {
                    return PartialView("Modal");
                }
            }return View(persona);
        }

        public ActionResult Delete(int IdPersona)
        {

            ML.Result result = BL.Persona.Delete(IdPersona);

            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado el registro";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se ha podido eliminar el registro seleccionado" + result.ErrorMessage;
                return PartialView("Modal");
            }
        }

    }
}