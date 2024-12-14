using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class ComentariosLogic
    {
        public Comentarios Create(Comentarios comentario)
        {
            Comentarios _comentario = null;

            using (var repository = RepositoryFactory.CreateRepository())
            {
                var _result = repository.Retrieve<Comentarios>(c => c.PublicacionID == comentario.PublicacionID && c.Autor == comentario.Autor && c.Contenido == comentario.Contenido);

                if (_result == null)
                {
                    _comentario = repository.Create(comentario);
                }
                else
                {
                    throw new Exception("Comentario ya existe.");
                }
            }

            return _comentario;
        }
        //recupera un comentario especifico
        public Comentarios RetrieveById(int id)
        {
            Comentarios _comentario = null;
            using (var repository = RepositoryFactory.CreateRepository())
            {
                _comentario = repository.Retrieve<Comentarios>(c => c.ComentarioID == id);
            }
            return _comentario;
        }

        public bool Update(Comentarios comentario)
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                var existingComentario = repository.Retrieve<Comentarios>(c => c.ComentarioID == comentario.ComentarioID);

                if (existingComentario == null)
                {
                    throw new Exception("El comentario no existe.");
                }

                // Actualiza manualmente las propiedades necesarias
                existingComentario.PublicacionID = comentario.PublicacionID;
                existingComentario.Autor = comentario.Autor;
                existingComentario.Contenido = comentario.Contenido;

                // Guarda los cambios
                return repository.Update(existingComentario);
            }
        }

        public bool Delete(int id)
        {
            bool _delete = false;
            var _comentario = RetrieveById(id);
            if (_comentario != null)
            {
                using (var repository = RepositoryFactory.CreateRepository())
                {
                    _delete = repository.Delete(_comentario);
                }
            }
            return _delete;
        }
        //lamar a todos los comentarios
        public List<Comentarios> RetrieveAll()
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                var comentarios = repository.Filter<Comentarios>(c => c.ComentarioID > 0).ToList();
                return comentarios;
            }
        }
    }
}
