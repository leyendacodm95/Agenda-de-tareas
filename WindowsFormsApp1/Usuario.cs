using System.Collections.Generic;
using System.Linq;

namespace AgendaTareas.Modelos
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public List<Tarea> Tareas { get; set; }

        public Usuario(string nombre, string correo)
        {
            Nombre = nombre;
            Correo = correo;
            Tareas = new List<Tarea>();
        }

        public void AgregarTarea(string titulo, string descripcion)
        {
            Tareas.Add(new Tarea(titulo, descripcion));
        }

        public void EliminarTarea(string titulo)
        {
            Tareas.RemoveAll(t => t.Titulo == titulo);
        }

        public Tarea BuscarTarea(string titulo)
        {
            return Tareas.FirstOrDefault(t => t.Titulo == titulo);
        }

        public List<Tarea> ListarTareas() => Tareas;
    }
}
