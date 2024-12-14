using System;
using System.Collections.Generic;
using System.Web.Http;
using Entities;
using BLL;

namespace API_Comentarios.Controllers
{
    public class ComentariosController : ApiController
    {
        [HttpPost]
        [Route("api/Comentarios")]
        public IHttpActionResult CreateComentario(Comentarios comentario)
        {
            if (comentario == null)
                return BadRequest("El comentario no puede ser nulo.");

            var _comentariosLogic = new ComentariosLogic();

            try
            {
                var createdComentario = _comentariosLogic.Create(comentario);
                return Created($"api/Comentarios/{createdComentario.ComentarioID}", createdComentario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el comentario: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/Comentarios/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var _comentariosLogic = new ComentariosLogic();
            var result = _comentariosLogic.Delete(id);

            if (result)
                return Ok("Comentario eliminado correctamente.");
            else
                return NotFound();
        }

        [HttpGet]
        [Route("api/Comentarios")]
        public IHttpActionResult GetAll()
        {
            var _comentariosLogic = new ComentariosLogic();

            try
            {
                var comentarios = _comentariosLogic.RetrieveAll();
                if (comentarios == null || comentarios.Count == 0)
                    return NotFound();

                return Ok(comentarios);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Comentarios/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var _comentariosLogic = new ComentariosLogic();

            try
            {
                var comentario = _comentariosLogic.RetrieveById(id);
                if (comentario == null)
                    return NotFound();

                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("api/Comentarios/{id:int}")]
        public IHttpActionResult UpdateComentario(int id, Comentarios comentario)
        {
            if (comentario == null)
                return BadRequest("El comentario no puede ser nulo.");

            if (id != comentario.ComentarioID)
                return BadRequest("El ID del comentario no coincide con el ID de la URL.");

            var _comentariosLogic = new ComentariosLogic();

            try
            {
                var updated = _comentariosLogic.Update(comentario);
                if (updated)
                    return Ok("Comentario actualizado correctamente.");
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el comentario: {ex.Message}");
            }
        }
    }
}
