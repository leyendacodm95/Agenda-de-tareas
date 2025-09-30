using AgendaTareas.Modelos;
using ClosedXML.Excel;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;

namespace AgendaTareas
{
    public partial class Form1 : Form
    {
        private Usuario usuarioActual;
        private CheckBox chkEstadoDinamico;
        private CheckBox chkRegresar;
        private bool actualizandoCheckbox = false;
        private Tarea tareaActualmenteSeleccionada;
        private bool enModoEdicion = false;

        private readonly string rutaArchivoJson = Path.Combine(Application.StartupPath, "datos.json");

        /// <summary>
        /// Constructor principal del formulario. Inicializa los componentes, conecta los eventos y carga los datos guardados.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            horafecha.Tick += Hora2_Tick;
            horafecha.Start();

            #region Inicialización Controles Dinámicos
            chkEstadoDinamico = new CheckBox();
            chkEstadoDinamico.Visible = false;
            chkEstadoDinamico.AutoSize = true;
            this.Controls.Add(chkEstadoDinamico);
            chkEstadoDinamico.CheckedChanged += chkEstadoDinamico_CheckedChanged;

            chkRegresar = new CheckBox();
            chkRegresar.Visible = false;
            chkRegresar.AutoSize = true;
            chkRegresar.Text = "Regresar a Pendiente";
            this.Controls.Add(chkRegresar);
            chkRegresar.CheckedChanged += chkRegresar_CheckedChanged;

            lstTareas.SelectedIndexChanged += Listas_SelectedIndexChanged;
            Proceso.SelectedIndexChanged += Listas_SelectedIndexChanged;
            Finalizadas.SelectedIndexChanged += Listas_SelectedIndexChanged;

            this.lstTareas.DoubleClick += new System.EventHandler(this.ListaTareas_DoubleClick);
            this.Proceso.DoubleClick += new System.EventHandler(this.ListaTareas_DoubleClick);
            this.Finalizadas.DoubleClick += new System.EventHandler(this.ListaTareas_DoubleClick);
            #endregion

            CargarDatos();
            ActualizarListas();
        }

        /// <summary>
        /// Maneja el clic en el botón "Guardar proyecto". Tiene una doble función:
        /// 1. Si está en modo edición, actualiza la tarea seleccionada.
        /// 2. Si no, guarda todo el proyecto en el archivo JSON.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (enModoEdicion)
            {
                if (tareaActualmenteSeleccionada != null)
                {
                    if (string.IsNullOrWhiteSpace(txtTitulo.Text))
                    {
                        MessageBox.Show("El título no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    tareaActualmenteSeleccionada.Titulo = txtTitulo.Text.Trim();
                    tareaActualmenteSeleccionada.Descripcion = txtDescripcion.Text.Trim();
                    ActualizarListas();
                    GuardarDatos();
                    MessageBox.Show("¡Tarea actualizada y proyecto guardado!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CancelarEdicion();
                }
            }
            else
            {
                GuardarDatos();
                MessageBox.Show("¡Proyecto guardado exitosamente!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Carga los datos del usuario y sus tareas desde el archivo "datos.json" al iniciar la aplicación.
        /// </summary>
        private void CargarDatos()
        {
            try
            {
                if (File.Exists(rutaArchivoJson))
                {
                    string jsonString = File.ReadAllText(rutaArchivoJson);
                    if (!string.IsNullOrWhiteSpace(jsonString))
                    {
                        usuarioActual = JsonSerializer.Deserialize<Usuario>(jsonString);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudieron cargar los datos. El archivo puede estar dañado.\nError: {ex.Message}");
                usuarioActual = null;
            }
        }

        /// <summary>
        /// Guarda el objeto 'usuarioActual' (con todas sus tareas) en el archivo "datos.json".
        /// </summary>
        private void GuardarDatos()
        {
            try
            {
                if (usuarioActual != null)
                {
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string jsonString = JsonSerializer.Serialize(usuarioActual, options);
                    File.WriteAllText(rutaArchivoJson, jsonString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos.\nError: {ex.Message}");
            }
        }

        /// <summary>
        /// Maneja el evento del checkbox "Regresar a Pendiente", cambiando el estado de la tarea seleccionada.
        /// </summary>
        private void chkRegresar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRegresar.Checked && tareaActualmenteSeleccionada != null && tareaActualmenteSeleccionada.Estado == "EnProceso")
            {
                tareaActualmenteSeleccionada.Estado = "Pendiente";
                ActualizarListas();
            }
        }

        /// <summary>
        /// Registra un nuevo usuario. Si ya existe uno, pide confirmación para reemplazarlo.
        /// </summary>
        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo))
            {
                MessageBox.Show("Completa nombre y correo.");
                return;
            }
            if (usuarioActual != null)
            {
                var resultado = MessageBox.Show("Ya existe un usuario. ¿Deseas reemplazarlo? Se perderán las tareas anteriores.", "Confirmar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.No) return;
            }
            usuarioActual = new Usuario(nombre, correo);
            MessageBox.Show("Usuario registrado correctamente.");
            ActualizarListas();
        }

        /// <summary>
        /// Crea una nueva tarea con los datos de los campos de texto y la añade al inicio de la lista (LIFO).
        /// </summary>
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
            usuarioActual.Tareas.Insert(0, nueva);
            ActualizarListas();
            LimpiarCampos();
        }

        /// <summary>
        /// Elimina la tarea que está actualmente seleccionada en cualquiera de las tres listas.
        /// </summary>
        private void btnEliminarTarea_Click(object sender, EventArgs e)
        {
            if (tareaActualmenteSeleccionada != null)
            {
                usuarioActual.Tareas.Remove(tareaActualmenteSeleccionada);
                ActualizarListas();
            }
            else
            {
                MessageBox.Show("Selecciona una tarea para eliminar.");
            }
        }

        /// <summary>
        /// Refresca el contenido de las tres listas (Pendiente, Proceso, Finalizadas) y actualiza los datos del usuario en la UI.
        /// </summary>
        private void ActualizarListas()
        {
            tareaActualmenteSeleccionada = null;
            chkEstadoDinamico.Visible = false;
            chkRegresar.Visible = false;
            chkRegresar.Checked = false;

            lstTareas.Items.Clear();
            Proceso.Items.Clear();
            Finalizadas.Items.Clear();

            if (usuarioActual != null)
            {
                txtNombre.Text = usuarioActual.Nombre;
                txtCorreo.Text = usuarioActual.Correo;

                foreach (var t in usuarioActual.Tareas)
                {
                    if (t.Estado == "Pendiente") lstTareas.Items.Add(t);
                    else if (t.Estado == "EnProceso") Proceso.Items.Add(t);
                    else if (t.Estado == "Finalizada") Finalizadas.Items.Add(t);
                }
            }
        }

        /// <summary>
        /// Busca una tarea en la lista del usuario basándose en el título ingresado en el campo de texto.
        /// </summary>
        private void btnBuscarTarea_Click(object sender, EventArgs e)
        {
            if (usuarioActual == null) return;
            string titulo = txtTitulo.Text.Trim();
            var tarea = usuarioActual.Tareas.FirstOrDefault(t => t.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
            if (tarea != null)
                MessageBox.Show($"Encontrada: {tarea.Titulo}\nEstado: {tarea.Estado}\n{tarea.Descripcion}");
            else
                MessageBox.Show("No se encontró la tarea.");
        }

        /// <summary>
        /// Vuelve a cargar las listas y muestra un mensaje con el número total de tareas del usuario.
        /// </summary>
        private void btnListarTareas_Click(object sender, EventArgs e)
        {
            if (usuarioActual == null) { MessageBox.Show("No hay un usuario registrado."); return; }
            ActualizarListas();
            MessageBox.Show($"Total de tareas: {usuarioActual.Tareas.Count}");
        }

        /// <summary>
        /// Exporta la lista completa de tareas a un archivo de Excel, utilizando una plantilla predefinida.
        /// </summary>
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (usuarioActual == null || usuarioActual.Tareas.Count == 0) { MessageBox.Show("No hay tareas para exportar."); return; }
            string rutaPlantilla = Path.Combine(Application.StartupPath, "Plantillas", "Plantilla.xlsx");
            if (!File.Exists(rutaPlantilla)) { MessageBox.Show("No se encontró la plantilla."); return; }
            using (var wb = new ClosedXML.Excel.XLWorkbook(rutaPlantilla))
            {
                var ws = wb.Worksheet(1);
                int fila = 11;
                for (int i = 0; i < usuarioActual.Tareas.Count; i++)
                {
                    ws.Cell(fila, 4).Value = i + 1;
                    ws.Cell(fila, 5).Value = usuarioActual.Tareas[i].Titulo;
                    ws.Cell(fila, 6).Value = usuarioActual.Tareas[i].Descripcion;
                    ws.Cell(fila, 7).Value = usuarioActual.Tareas[i].Estado;
                    ws.Cell(fila, 8).Value = usuarioActual.Tareas[i].FechaHora;
                    fila++;
                }
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "AgendaTareas_Reporte.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK) { wb.SaveAs(sfd.FileName); MessageBox.Show("Exportado correctamente."); }
                }
            }
        }

        /// <summary>
        /// Limpia los campos de texto de Título y Descripción.
        /// </summary>
        private void LimpiarCampos()
        {
            txtTitulo.Clear();
            txtDescripcion.Clear();
        }

        /// <summary>
        /// Se activa al hacer doble clic en una tarea. Prepara el formulario para el modo de edición.
        /// </summary>
        private void ListaTareas_DoubleClick(object sender, EventArgs e)
        {
            if (tareaActualmenteSeleccionada != null)
            {
                enModoEdicion = true;
                txtTitulo.Text = tareaActualmenteSeleccionada.Titulo;
                txtDescripcion.Text = tareaActualmenteSeleccionada.Descripcion;
                btnGuardar.Text = "Actualizar Tarea";
                btnAgregarTarea.Enabled = false;
                panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            }
        }

        /// <summary>
        /// Restablece la interfaz a su estado normal, saliendo del modo de edición.
        /// </summary>
        private void CancelarEdicion()
        {
            txtTitulo.Clear();
            txtDescripcion.Clear();
            btnGuardar.Text = "Guardar proyecto";
            btnAgregarTarea.Enabled = true;
            panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            enModoEdicion = false;
        }

        /// <summary>
        /// Se activa cuando cambia la selección en cualquiera de las listas. Gestiona la visibilidad de los checkboxes y cancela el modo edición si estaba activo.
        /// </summary>
        private void Listas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (enModoEdicion)
            {
                CancelarEdicion();
            }

            chkEstadoDinamico.Visible = false;
            chkRegresar.Visible = false;
            ListBox listaActiva = sender as ListBox;
            if (listaActiva.SelectedItem == null) { tareaActualmenteSeleccionada = null; return; }
            tareaActualmenteSeleccionada = listaActiva.SelectedItem as Tarea;
            if (!listaActiva.Equals(Proceso)) Proceso.ClearSelected();
            if (!listaActiva.Equals(Finalizadas)) Finalizadas.ClearSelected();
            if (!listaActiva.Equals(lstTareas)) lstTareas.ClearSelected();
            int indiceSeleccionado = listaActiva.SelectedIndex;
            System.Drawing.Rectangle rect = listaActiva.GetItemRectangle(indiceSeleccionado);
            chkEstadoDinamico.Location = new System.Drawing.Point(listaActiva.Left + rect.Width + 5, listaActiva.Top + rect.Y);
            chkRegresar.Location = new System.Drawing.Point(chkEstadoDinamico.Left, chkEstadoDinamico.Top + 25);
            actualizandoCheckbox = true;
            if (listaActiva.Equals(lstTareas)) { chkEstadoDinamico.Text = "Iniciar Tarea"; chkEstadoDinamico.Checked = false; chkEstadoDinamico.Visible = true; }
            else if (listaActiva.Equals(Proceso)) { chkEstadoDinamico.Text = "Finalizar Tarea"; chkEstadoDinamico.Checked = false; chkEstadoDinamico.Visible = true; chkRegresar.Checked = false; chkRegresar.Visible = true; }
            else if (listaActiva.Equals(Finalizadas)) { chkEstadoDinamico.Text = "Reabrir Tarea"; chkEstadoDinamico.Checked = true; chkEstadoDinamico.Visible = true; }
            if (chkEstadoDinamico.Visible) chkEstadoDinamico.BringToFront();
            if (chkRegresar.Visible) chkRegresar.BringToFront();
            actualizandoCheckbox = false;
        }

        /// <summary>
        /// Maneja la lógica del checkbox dinámico para cambiar el estado de una tarea (Pendiente -> Proceso -> Finalizada).
        /// </summary>
        private void chkEstadoDinamico_CheckedChanged(object sender, EventArgs e)
        {
            if (actualizandoCheckbox) return;
            if (tareaActualmenteSeleccionada == null) return;
            if (chkRegresar.Checked) return;
            string estadoOriginal = tareaActualmenteSeleccionada.Estado;
            if (estadoOriginal == "Pendiente" && chkEstadoDinamico.Checked) { tareaActualmenteSeleccionada.Estado = "EnProceso"; }
            else if (estadoOriginal == "EnProceso" && chkEstadoDinamico.Checked) { tareaActualmenteSeleccionada.Estado = "Finalizada"; }
            else if (estadoOriginal == "Finalizada" && !chkEstadoDinamico.Checked) { tareaActualmenteSeleccionada.Estado = "EnProceso"; }
            ActualizarListas();
        }

        /// <summary>
        /// Se ejecuta a cada tick del timer para actualizar los labels de la hora y la fecha.
        /// </summary>
        private void Hora2_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }

        /// <summary>
        /// Cierra la aplicación al hacer clic en el botón de cerrar de la barra de título.
        /// </summary>
        private void BotonCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Minimiza la ventana de la aplicación.
        /// </summary>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // --- Bloque para poder mover la ventana desde la barra de título ---
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        /// <summary>
        /// Permite que la ventana se pueda arrastrar al mantener presionado el clic en la barra de título.
        /// </summary>
        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /// <summary>
        /// Evento que se dispara cuando el formulario se ha cargado.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e) 
        { 
        
        }
    }
}