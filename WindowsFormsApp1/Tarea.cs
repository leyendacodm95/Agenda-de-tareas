using System;

namespace AgendaTareas.Modelos
{
    public class Tarea
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public EstadoTarea Estado { get; set; }

        public enum EstadoTarea
        {
            Pendiente,
            EnProceso,
            Finalizada
        }

        public Tarea(string titulo, string descripcion)
        {
            Titulo = titulo;
            Descripcion = descripcion;
            FechaCreacion = DateTime.Now;
            Estado = EstadoTarea.Pendiente;
        }

        public override string ToString()
        {
            return $"{Titulo} - {Descripcion} ({FechaCreacion:g})";
        }
    }
}
