using System.Collections.Generic;
using System.Linq;

namespace AgendaTareas.Modelos
{
    public class Usuario
    {
        /// <summary>
        /// El nombre del usuario.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// El correo electrónico del usuario.
        /// </summary>
        public string Correo { get; set; }

        /// <summary>
        /// La lista de todas las tareas asociadas a este usuario.
        /// </summary>
        public List<Tarea> Tareas { get; set; }

        /// <summary>
        /// Crea una nueva instancia de Usuario y inicializa su lista de tareas vacía.
        /// </summary>
        /// <param name="nombre">El nombre del usuario.</param>
        /// <param name="correo">El correo del usuario.</param>
        public Usuario(string nombre, string correo)
        {
            Nombre = nombre;
            Correo = correo;
            Tareas = new List<Tarea>();
        }

        /// <summary>
        /// Crea y añade una nueva tarea a la lista del usuario.
        /// </summary>
        /// <param name="titulo">El título de la nueva tarea.</param>
        /// <param name="descripcion">La descripción de la nueva tarea.</param>
        public void AgregarTarea(string titulo, string descripcion)
        {
            Tareas.Add(new Tarea(titulo, descripcion));
        }

        /// <summary>
        /// Elimina todas las tareas que coincidan con el título proporcionado.
        /// </summary>
        /// <param name="titulo">El título de la tarea a eliminar.</param>
        public void EliminarTarea(string titulo)
        {
            Tareas.RemoveAll(t => t.Titulo == titulo);
        }

        /// <summary>
        /// Busca y devuelve la primera tarea que coincida con el título proporcionado.
        /// </summary>
        /// <param name="titulo">El título de la tarea a buscar.</param>
        /// <returns>El objeto Tarea si se encuentra; de lo contrario, null.</returns>
        public Tarea BuscarTarea(string titulo)
        {
            return Tareas.FirstOrDefault(t => t.Titulo == titulo);
        }

        /// <summary>
        /// Devuelve la lista completa de tareas del usuario.
        /// </summary>
        /// <returns>Una lista de objetos Tarea.</returns>
        public List<Tarea> ListarTareas() => Tareas;
    }
}