using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC
{
    public interface IComentariosService
    {
        // Crear un comentario
        Comentarios CreateProduct(Comentarios comentarios);

        // Eliminar un comentario por iD
        bool Delete(int id);

        // Obtener todos los comentarios
        List<Comentarios> GetAll();

        // Obtener un comentario por ID
        Comentarios GetById(int id);

        // Actualizar un comentario
        bool UpdateProduct(Comentarios comentarios);
    }
}