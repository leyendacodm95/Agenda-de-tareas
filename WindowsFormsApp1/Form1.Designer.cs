using System;

namespace AgendaTareas
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnBuscarTarea = new System.Windows.Forms.Button();
            this.btnEliminarTarea = new System.Windows.Forms.Button();
            this.btnListarTareas = new System.Windows.Forms.Button();
            this.btnCambiarEstadoProc = new System.Windows.Forms.Button();
            this.lstTareas = new System.Windows.Forms.ListBox();
            this.Proceso = new System.Windows.Forms.ListBox();
            this.Finalizadas = new System.Windows.Forms.ListBox();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.BotonCerrar = new System.Windows.Forms.PictureBox();
            this.Minimizar = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblhora = new System.Windows.Forms.Label();
            this.lblfecha = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAgregarTarea = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.horafecha = new System.Windows.Forms.Timer(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BotonCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.Info;
            this.txtNombre.Location = new System.Drawing.Point(11, 102);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.SystemColors.Info;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(13, 313);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(255, 116);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // txtTitulo
            // 
            this.txtTitulo.BackColor = System.Drawing.SystemColors.Info;
            this.txtTitulo.Location = new System.Drawing.Point(13, 237);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(255, 20);
            this.txtTitulo.TabIndex = 2;
            // 
            // txtCorreo
            // 
            this.txtCorreo.BackColor = System.Drawing.SystemColors.Info;
            this.txtCorreo.Location = new System.Drawing.Point(142, 102);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(126, 20);
            this.txtCorreo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(33, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(81, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Titulo de la tarea";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(181, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Correo";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(90, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Descripcion";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label5.Location = new System.Drawing.Point(308, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(487, 46);
            this.label5.TabIndex = 8;
            this.label5.Text = "Lista de tareas registradas";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 32);
            this.button1.TabIndex = 9;
            this.button1.Text = "Registro del usuario";
            this.button1.Click += new System.EventHandler(this.btnRegistrarUsuario_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(208, 615);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Cambiar Estado";
            this.button4.Click += new System.EventHandler(this.btnCambiarEstado_Click);
            // 
            // btnBuscarTarea
            // 
            this.btnBuscarTarea.Location = new System.Drawing.Point(56, 485);
            this.btnBuscarTarea.Name = "btnBuscarTarea";
            this.btnBuscarTarea.Size = new System.Drawing.Size(164, 34);
            this.btnBuscarTarea.TabIndex = 11;
            this.btnBuscarTarea.Text = "Buscar Tarea";
            this.btnBuscarTarea.Click += new System.EventHandler(this.btnBuscarTarea_Click);
            // 
            // btnEliminarTarea
            // 
            this.btnEliminarTarea.Location = new System.Drawing.Point(56, 525);
            this.btnEliminarTarea.Name = "btnEliminarTarea";
            this.btnEliminarTarea.Size = new System.Drawing.Size(164, 32);
            this.btnEliminarTarea.TabIndex = 12;
            this.btnEliminarTarea.Text = "Eliminar Tarea";
            this.btnEliminarTarea.Click += new System.EventHandler(this.btnEliminarTarea_Click);
            // 
            // btnListarTareas
            // 
            this.btnListarTareas.Location = new System.Drawing.Point(56, 796);
            this.btnListarTareas.Name = "btnListarTareas";
            this.btnListarTareas.Size = new System.Drawing.Size(164, 32);
            this.btnListarTareas.TabIndex = 13;
            this.btnListarTareas.Text = "Listar Tareas";
            // 
            // btnCambiarEstadoProc
            // 
            this.btnCambiarEstadoProc.Location = new System.Drawing.Point(351, 644);
            this.btnCambiarEstadoProc.Name = "btnCambiarEstadoProc";
            this.btnCambiarEstadoProc.Size = new System.Drawing.Size(205, 32);
            this.btnCambiarEstadoProc.TabIndex = 14;
            this.btnCambiarEstadoProc.Text = "Cambiar Estado";
            this.btnCambiarEstadoProc.Click += new System.EventHandler(this.btnCambiarEstadoPend_Click);
            // 
            // lstTareas
            // 
            this.lstTareas.Location = new System.Drawing.Point(316, 154);
            this.lstTareas.Name = "lstTareas";
            this.lstTareas.Size = new System.Drawing.Size(268, 472);
            this.lstTareas.TabIndex = 13;
            this.lstTareas.SelectedIndexChanged += new System.EventHandler(this.lstTareas_SelectedIndexChanged);
            // 
            // Proceso
            // 
            this.Proceso.Location = new System.Drawing.Point(611, 154);
            this.Proceso.Name = "Proceso";
            this.Proceso.Size = new System.Drawing.Size(268, 472);
            this.Proceso.TabIndex = 19;
            // 
            // Finalizadas
            // 
            this.Finalizadas.Location = new System.Drawing.Point(907, 154);
            this.Finalizadas.Name = "Finalizadas";
            this.Finalizadas.Size = new System.Drawing.Size(268, 472);
            this.Finalizadas.TabIndex = 20;
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.SystemColors.GrayText;
            this.BarraTitulo.Controls.Add(this.BotonCerrar);
            this.BarraTitulo.Controls.Add(this.Minimizar);
            this.BarraTitulo.Controls.Add(this.pictureBox3);
            this.BarraTitulo.Controls.Add(this.lblhora);
            this.BarraTitulo.Controls.Add(this.lblfecha);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(1201, 54);
            this.BarraTitulo.TabIndex = 14;
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // BotonCerrar
            // 
            this.BotonCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BotonCerrar.Image = global::WindowsFormsApp1.Properties.Resources.cerrar_ventana;
            this.BotonCerrar.Location = new System.Drawing.Point(1144, 4);
            this.BotonCerrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BotonCerrar.Name = "BotonCerrar";
            this.BotonCerrar.Size = new System.Drawing.Size(44, 45);
            this.BotonCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BotonCerrar.TabIndex = 12;
            this.BotonCerrar.TabStop = false;
            this.BotonCerrar.Click += new System.EventHandler(this.BotonCerrar_Click);
            // 
            // Minimizar
            // 
            this.Minimizar.BackColor = System.Drawing.SystemColors.GrayText;
            this.Minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Minimizar.Image = global::WindowsFormsApp1.Properties.Resources.minimazar;
            this.Minimizar.Location = new System.Drawing.Point(1092, 4);
            this.Minimizar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Minimizar.Name = "Minimizar";
            this.Minimizar.Size = new System.Drawing.Size(44, 45);
            this.Minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Minimizar.TabIndex = 11;
            this.Minimizar.TabStop = false;
            this.Minimizar.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WindowsFormsApp1.Properties.Resources.tarea;
            this.pictureBox3.Location = new System.Drawing.Point(0, 8);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(45, 35);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // lblhora
            // 
            this.lblhora.AutoSize = true;
            this.lblhora.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhora.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblhora.Location = new System.Drawing.Point(806, 9);
            this.lblhora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblhora.Name = "lblhora";
            this.lblhora.Size = new System.Drawing.Size(107, 46);
            this.lblhora.TabIndex = 23;
            this.lblhora.Text = "Hora";
            this.lblhora.Click += new System.EventHandler(this.lblhora_Click);
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfecha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblfecha.Location = new System.Drawing.Point(311, 18);
            this.lblfecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(67, 25);
            this.lblfecha.TabIndex = 24;
            this.lblfecha.Text = "Fecha";
            this.lblfecha.Click += new System.EventHandler(this.lblfecha_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnAgregarTarea);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.txtCorreo);
            this.panel1.Controls.Add(this.txtTitulo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnBuscarTarea);
            this.panel1.Controls.Add(this.btnEliminarTarea);
            this.panel1.Controls.Add(this.btnListarTareas);
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 948);
            this.panel1.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(56, 563);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 32);
            this.button2.TabIndex = 17;
            this.button2.Text = "Listar Tareas";
            this.button2.Click += new System.EventHandler(this.btnListarTareas_Click);
            // 
            // btnAgregarTarea
            // 
            this.btnAgregarTarea.Location = new System.Drawing.Point(56, 444);
            this.btnAgregarTarea.Name = "btnAgregarTarea";
            this.btnAgregarTarea.Size = new System.Drawing.Size(164, 32);
            this.btnAgregarTarea.TabIndex = 16;
            this.btnAgregarTarea.Text = "Agregar Tarea";
            this.btnAgregarTarea.Click += new System.EventHandler(this.btnAgregarTarea_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBox2.Image = global::WindowsFormsApp1.Properties.Resources.cropped_Logotipo_sitio_web_1;
            this.pictureBox2.Location = new System.Drawing.Point(13, 11);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(255, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(637, 644);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(226, 32);
            this.button5.TabIndex = 21;
            this.button5.Text = "Cambiar Estado";
            this.button5.Click += new System.EventHandler(this.btnCambiarEstadoProc_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(963, 644);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(164, 32);
            this.button6.TabIndex = 22;
            this.button6.Text = "Exportar a Excel";
            this.button6.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // textBox2
            // 
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox2.Location = new System.Drawing.Point(670, 116);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(142, 20);
            this.textBox2.TabIndex = 25;
            this.textBox2.Text = "Tareas en proceso";
            // 
            // textBox3
            // 
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox3.Location = new System.Drawing.Point(985, 116);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(142, 20);
            this.textBox3.TabIndex = 26;
            this.textBox3.Text = "Tareas finalizadas";
            // 
            // textBox1
            // 
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.Location = new System.Drawing.Point(351, 116);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(198, 20);
            this.textBox1.TabIndex = 27;
            this.textBox1.Text = "Lista de tareas por realizar";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1201, 733);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.Finalizadas);
            this.Controls.Add(this.Proceso);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BarraTitulo);
            this.Controls.Add(this.lstTareas);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCambiarEstadoProc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Lista de Tareas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.BarraTitulo.ResumeLayout(false);
            this.BarraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BotonCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1; // Registro usuario
        private System.Windows.Forms.Button button4; // Cambiar estado
        private System.Windows.Forms.ListBox lstTareas;
        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.Panel panel1;
       private System.Windows.Forms.ListBox Proceso;
        private System.Windows.Forms.ListBox Finalizadas;
        private System.Windows.Forms.Timer horafecha;
        // Nuevos botones adicionales
        private System.Windows.Forms.Button btnBuscarTarea;
        private System.Windows.Forms.Button btnEliminarTarea;
        private System.Windows.Forms.Button btnListarTareas;
        private System.Windows.Forms.Button btnCambiarEstadoProc;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnAgregarTarea;
        private System.Windows.Forms.PictureBox Minimizar;
        private System.Windows.Forms.PictureBox BotonCerrar;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.Label lblhora;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
    }
}