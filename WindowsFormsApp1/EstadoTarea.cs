namespace AgendaTareas.Modelos
{
    public class EstadoTarea
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public EstadoTarea Estado { get; set; }
        public static EstadoTarea Pendiente { get; }
        public static EstadoTarea EnProceso { get; internal set; }

        public EstadoTarea(string titulo, string descripcion)
        {
            Titulo = titulo;
            Descripcion = descripcion;
            Estado = EstadoTarea.Pendiente;
        }

        public void CambiarEstado(EstadoTarea nuevoEstado)
        {
            Estado = nuevoEstado;
        }
    }
}
