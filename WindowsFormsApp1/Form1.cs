using AgendaTareas.Modelos;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2016.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq;

namespace AgendaTareas
{
    public partial class Form1 : Form
    {
        // ----- Modelo de datos -----
        private class Tarea
        {
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public string Estado { get; set; } // Pendiente | EnProceso | Finalizada
            public DateTime FechaHora { get; set; }

            public override string ToString()
            {
                return $"{Titulo} ({FechaHora:g})";
            }
        }

        private List<Tarea> listaTareas = new List<Tarea>();
        private Usuario usuarioActual;

        public Form1()
        {
            InitializeComponent();
            horafecha.Tick += Hora2_Tick; // Aseguramos que el timer tenga el evento
            horafecha.Start();
        }

        // ================== USUARIO ==================
        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo))
            {
                MessageBox.Show("Completa nombre y correo.");
                return;
            }

            usuarioActual = new Usuario(nombre, correo);
            MessageBox.Show("Usuario registrado correctamente.");
        }

        // ================== TAREAS ==================
        private void btnAgregarTarea_Click(object sender, EventArgs e)
        {
            if (usuarioActual == null)
            {
                MessageBox.Show("Primero registra un usuario.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Agrega un título a la tarea.");
                return;
            }

            var nueva = new Tarea
            {
                Titulo = txtTitulo.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                Estado = "Pendiente",
                FechaHora = DateTime.Now
            };

            listaTareas.Add(nueva);
            usuarioActual.AgregarTarea(nueva.Titulo, nueva.Descripcion); // Mantener lógica de usuario original
            ActualizarListas();
            LimpiarCampos();
        }

        private void btnBuscarTarea_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text.Trim();
            var tarea = listaTareas.FirstOrDefault(t => t.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

            if (tarea != null)
                MessageBox.Show($"Encontrada: {tarea.Titulo}\nEstado: {tarea.Estado}\n{tarea.Descripcion}");
            else
                MessageBox.Show("No se encontró la tarea.");
        }

        private void btnEliminarTarea_Click(object sender, EventArgs e)
        {
            Tarea seleccionada = ObtenerSeleccionada();
            if (seleccionada == null) return;

            listaTareas.Remove(seleccionada);
            ActualizarListas();
        }

        private void btnListarTareas_Click(object sender, EventArgs e)
        {
            ActualizarListas();
            MessageBox.Show($"Total de tareas: {listaTareas.Count}");
        }

        // ================== CAMBIO DE ESTADO ==================
        private void btnCambiarEstadoPend_Click(object sender, EventArgs e)
        {
            Tarea seleccionada = ObtenerSeleccionada();
            if (seleccionada == null) return;

            if (seleccionada.Estado == "Pendiente")
                seleccionada.Estado = "EnProceso";

            ActualizarListas();
        }

        private void btnCambiarEstadoProc_Click(object sender, EventArgs e)
        {
            Tarea seleccionada = ObtenerSeleccionada();
            if (seleccionada == null) return;

            if (seleccionada.Estado == "EnProceso")
                seleccionada.Estado = "Finalizada";

            ActualizarListas();
        }

        // ================== EXPORTAR EXCEL USANDO PLANTILLA ==================
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (listaTareas.Count == 0)
            {
                MessageBox.Show("No hay tareas para exportar.");
                return;
            }

            // Ruta relativa a la carpeta Plantillas dentro de la carpeta del ejecutable
            string rutaPlantilla = System.IO.Path.Combine(Application.StartupPath, "Plantillas", "Plantilla.xlsx");

            if (!System.IO.File.Exists(rutaPlantilla))
            {
                MessageBox.Show("No se encontró la plantilla. Verifica que exista la carpeta 'Plantillas' y el archivo 'PlantillaTareas.xlsx'.");
                return;
            }

            using (var wb = new ClosedXML.Excel.XLWorkbook(rutaPlantilla))
            {
                var ws = wb.Worksheet(1); // Primer hoja de la plantilla

                int fila = 11; // Inicia en fila 11 (debajo de los encabezados en fila 10)
                for (int i = 0; i < listaTareas.Count; i++)
                {
                    ws.Cell(fila, 4).Value = i + 1;                     // Num. Tarea -> columna D
                    ws.Cell(fila, 5).Value = listaTareas[i].Titulo;    // Título -> columna E
                    ws.Cell(fila, 6).Value = listaTareas[i].Descripcion; // Descripción -> columna F
                    ws.Cell(fila, 7).Value = listaTareas[i].Estado;    // Estado -> columna G
                    ws.Cell(fila, 8).Value = listaTareas[i].FechaHora; // Fecha y Hora -> columna H
                    fila++;
                }

                using (SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Excel Workbook|*.xlsx",
                    FileName = "AgendaTareas_Reporte.xlsx"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        wb.SaveAs(sfd.FileName);
                        MessageBox.Show("Exportado correctamente usando la plantilla.");
                    }
                }
            }
        }



        // ================== MÉTODOS DE APOYO ==================
        private void ActualizarListas()
        {
            lstTareas.Items.Clear();
            Proceso.Items.Clear();
            Finalizadas.Items.Clear();

            foreach (var t in listaTareas)
            {
                if (t.Estado == "Pendiente") lstTareas.Items.Add(t);
                else if (t.Estado == "EnProceso") Proceso.Items.Add(t);
                else if (t.Estado == "Finalizada") Finalizadas.Items.Add(t);
            }
        }

        private Tarea ObtenerSeleccionada()
        {
            if (lstTareas.SelectedItem is Tarea t1) return t1;
            if (Proceso.SelectedItem is Tarea t2) return t2;
            if (Finalizadas.SelectedItem is Tarea t3) return t3;
            MessageBox.Show("Selecciona una tarea de cualquiera de las listas.");
            return null;
        }

        private void LimpiarCampos()
        {
            txtTitulo.Clear();
            txtDescripcion.Clear();
        }

        // ================== RELOJ / FECHA ==================
        private void Hora2_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }

        // ================== MOVIMIENTO / MINIMIZAR / MAXIMIZAR / CERRAR ==================
        private void BotonCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lstTareas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Proceso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblhora_Click(object sender, EventArgs e)
        {

        }

        private void lblfecha_Click(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
