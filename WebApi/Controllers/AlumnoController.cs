﻿using Microsoft.AspNetCore.Mvc;
using reactBackend.Models;
using reactBackend.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AlumnoController : Controller
    {
        //este elemento representa el modelo de datos de alumno para poder instanciarlo es privado
        private AlumnoDAO _dao = new AlumnoDAO();


        [HttpGet("alumnoProfesor")]

        public List<AlumnoProfesor> GetAlumnoProfesor(string usuario)
        {
            return _dao.alumnoProfesors(usuario);
        }


        #region SelectByID
        [HttpGet("alumno")]
        public Alumno selectById(int id)
        {
            var alumno = _dao.GetByIdAlumno(id);
            return alumno;
        }

        #endregion
        #region ACtualizar
        [HttpPut("alumno")]
        //pede tenre el mismo nombre que el endpoint anteriro ya que es un metodo diferente el que se esta utilizando
        public bool actualizaAlumno([FromBody] Alumno alumno)
        {
            //FromBody indica que se obtendra desde el navegador el objecto alumno es el objecto alumno es el nombre de la instancia de ese object

            return _dao.updateAlumno(alumno.Id, alumno);

        }

        #endregion
    }
}
