using System;

namespace AgendaTareas.Modelos
{
    public class Tarea
    {
        /// <summary>
        /// El título principal de la tarea.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Una descripción más detallada de la tarea.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// El estado actual de la tarea (Pendiente, EnProceso, Finalizada).
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// La fecha y hora en que se creó la tarea.
        /// </summary>
        public DateTime FechaHora { get; set; }

        /// <summary>
        /// Constructor vacío requerido por el deserializador de JSON para crear instancias de la clase al cargar datos.
        /// </summary>
        public Tarea() { }

        /// <summary>
        /// Crea una nueva instancia de Tarea con un título y descripción. Asigna "Pendiente" como estado por defecto.
        /// </summary>
        /// <param name="titulo">El título de la tarea.</param>
        /// <param name="descripcion">La descripción de la tarea.</param>
        public Tarea(string titulo, string descripcion)
        {
            Titulo = titulo;
            Descripcion = descripcion;
            Estado = "Pendiente";
            FechaHora = DateTime.Now;
        }

        /// <summary>
        /// Sobrescribe el método ToString para mostrar la información de la tarea de forma legible en los ListBox.
        /// </summary>
        /// <returns>Una cadena de texto formateada con los detalles de la tarea.</returns>
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Descripcion))
            {
                return $"{Titulo} - {Descripcion} ({FechaHora:g})";
            }
            else
            {
                return $"{Titulo} ({FechaHora:g})";
            }
        }
    }
}