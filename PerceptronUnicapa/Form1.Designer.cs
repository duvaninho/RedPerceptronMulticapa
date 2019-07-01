namespace RedesNeuronales
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chartErrorvsIteracion = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bunifuGradientPanel4 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.CartesianVariacionRealDeseada = new LiveCharts.WinForms.CartesianChart();
            this.panel9 = new System.Windows.Forms.Panel();
            this.CartesianErrors = new LiveCharts.WinForms.CartesianChart();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnContinuar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnEntrenar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label5 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.bunifuGradientPanel2 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.CmbAlgoritmoEntrenamiento = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.NudRataDinamica = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBorrarLog = new Bunifu.Framework.UI.BunifuThinButton2();
            this.nudRataAprendizaje = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudErrorMaximo = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudNoIteraciones = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.btnSimular = new Bunifu.Framework.UI.BunifuThinButton2();
            this.DgvParametrosSimulacion = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btnNuevo = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnInicializarRed = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnCargarPesosyUmbrales = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnCargarPatrones = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel15 = new System.Windows.Forms.Panel();
            this.dgvTopologiaRed = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Capa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Neuronas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activacion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.nudNumeroCapas = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblEntradas = new System.Windows.Forms.Label();
            this.lblSalidas = new System.Windows.Forms.Label();
            this.lblPatrones = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvPatrones = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Entradas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salidas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartErrorvsIteracion)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.bunifuGradientPanel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.bunifuGradientPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudRataDinamica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRataAprendizaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudErrorMaximo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoIteraciones)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvParametrosSimulacion)).BeginInit();
            this.panel16.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopologiaRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroCapas)).BeginInit();
            this.panel12.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatrones)).BeginInit();
            this.panel17.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.chartErrorvsIteracion);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(493, 347);
            this.panel2.TabIndex = 0;
            // 
            // chartErrorvsIteracion
            // 
            this.chartErrorvsIteracion.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.chartErrorvsIteracion.ChartAreas.Add(chartArea1);
            this.chartErrorvsIteracion.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartErrorvsIteracion.Legends.Add(legend1);
            this.chartErrorvsIteracion.Location = new System.Drawing.Point(0, 0);
            this.chartErrorvsIteracion.Name = "chartErrorvsIteracion";
            this.chartErrorvsIteracion.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartErrorvsIteracion.Series.Add(series1);
            this.chartErrorvsIteracion.Size = new System.Drawing.Size(489, 343);
            this.chartErrorvsIteracion.TabIndex = 0;
            this.chartErrorvsIteracion.Text = "Error Por Iteracion";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1574, 847);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Fase de Simulacion";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bunifuGradientPanel4);
            this.tabPage1.Controls.Add(this.bunifuGradientPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1574, 847);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Fase de Entrenamiento";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bunifuGradientPanel4
            // 
            this.bunifuGradientPanel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel4.BackgroundImage")));
            this.bunifuGradientPanel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel4.Controls.Add(this.panel3);
            this.bunifuGradientPanel4.Controls.Add(this.panel9);
            this.bunifuGradientPanel4.Controls.Add(this.panel6);
            this.bunifuGradientPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGradientPanel4.GradientBottomLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel4.GradientBottomRight = System.Drawing.Color.White;
            this.bunifuGradientPanel4.GradientTopLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel4.GradientTopRight = System.Drawing.Color.White;
            this.bunifuGradientPanel4.Location = new System.Drawing.Point(931, 3);
            this.bunifuGradientPanel4.Name = "bunifuGradientPanel4";
            this.bunifuGradientPanel4.Quality = 10;
            this.bunifuGradientPanel4.Size = new System.Drawing.Size(640, 841);
            this.bunifuGradientPanel4.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.CartesianVariacionRealDeseada);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 432);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(640, 258);
            this.panel3.TabIndex = 1;
            // 
            // CartesianVariacionRealDeseada
            // 
            this.CartesianVariacionRealDeseada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CartesianVariacionRealDeseada.Location = new System.Drawing.Point(0, 0);
            this.CartesianVariacionRealDeseada.Name = "CartesianVariacionRealDeseada";
            this.CartesianVariacionRealDeseada.Size = new System.Drawing.Size(640, 258);
            this.CartesianVariacionRealDeseada.TabIndex = 0;
            this.CartesianVariacionRealDeseada.Text = "cartesianChart1";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.CartesianErrors);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(640, 432);
            this.panel9.TabIndex = 1;
            // 
            // CartesianErrors
            // 
            this.CartesianErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CartesianErrors.Location = new System.Drawing.Point(0, 0);
            this.CartesianErrors.Name = "CartesianErrors";
            this.CartesianErrors.Size = new System.Drawing.Size(640, 432);
            this.CartesianErrors.TabIndex = 0;
            this.CartesianErrors.Text = "CartesianErrors";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel11);
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 690);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(640, 151);
            this.panel6.TabIndex = 1;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btnContinuar);
            this.panel11.Controls.Add(this.btnEntrenar);
            this.panel11.Controls.Add(this.label5);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(361, 151);
            this.panel11.TabIndex = 15;
            // 
            // btnContinuar
            // 
            this.btnContinuar.Activecolor = System.Drawing.Color.White;
            this.btnContinuar.BackColor = System.Drawing.Color.White;
            this.btnContinuar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnContinuar.BorderRadius = 0;
            this.btnContinuar.ButtonText = "      Continuar";
            this.btnContinuar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinuar.DisabledColor = System.Drawing.Color.Gray;
            this.btnContinuar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnContinuar.Iconcolor = System.Drawing.Color.Gainsboro;
            this.btnContinuar.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnContinuar.Iconimage")));
            this.btnContinuar.Iconimage_right = null;
            this.btnContinuar.Iconimage_right_Selected = null;
            this.btnContinuar.Iconimage_Selected = null;
            this.btnContinuar.IconMarginLeft = 0;
            this.btnContinuar.IconMarginRight = 0;
            this.btnContinuar.IconRightVisible = true;
            this.btnContinuar.IconRightZoom = 0D;
            this.btnContinuar.IconVisible = true;
            this.btnContinuar.IconZoom = 70D;
            this.btnContinuar.IsTab = false;
            this.btnContinuar.Location = new System.Drawing.Point(0, 75);
            this.btnContinuar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Normalcolor = System.Drawing.Color.White;
            this.btnContinuar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnContinuar.OnHoverTextColor = System.Drawing.Color.White;
            this.btnContinuar.selected = false;
            this.btnContinuar.Size = new System.Drawing.Size(361, 50);
            this.btnContinuar.TabIndex = 7;
            this.btnContinuar.Text = "      Continuar";
            this.btnContinuar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContinuar.Textcolor = System.Drawing.Color.SeaGreen;
            this.btnContinuar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuar.Click += new System.EventHandler(this.BtnContinuar_Click);
            // 
            // btnEntrenar
            // 
            this.btnEntrenar.Activecolor = System.Drawing.Color.White;
            this.btnEntrenar.BackColor = System.Drawing.Color.White;
            this.btnEntrenar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEntrenar.BorderRadius = 0;
            this.btnEntrenar.ButtonText = "      Entrenar";
            this.btnEntrenar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntrenar.DisabledColor = System.Drawing.Color.Gray;
            this.btnEntrenar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEntrenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrenar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEntrenar.Iconcolor = System.Drawing.Color.Gainsboro;
            this.btnEntrenar.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnEntrenar.Iconimage")));
            this.btnEntrenar.Iconimage_right = null;
            this.btnEntrenar.Iconimage_right_Selected = null;
            this.btnEntrenar.Iconimage_Selected = null;
            this.btnEntrenar.IconMarginLeft = 0;
            this.btnEntrenar.IconMarginRight = 0;
            this.btnEntrenar.IconRightVisible = true;
            this.btnEntrenar.IconRightZoom = 0D;
            this.btnEntrenar.IconVisible = true;
            this.btnEntrenar.IconZoom = 70D;
            this.btnEntrenar.IsTab = false;
            this.btnEntrenar.Location = new System.Drawing.Point(0, 25);
            this.btnEntrenar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnEntrenar.Name = "btnEntrenar";
            this.btnEntrenar.Normalcolor = System.Drawing.Color.White;
            this.btnEntrenar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnEntrenar.OnHoverTextColor = System.Drawing.Color.White;
            this.btnEntrenar.selected = false;
            this.btnEntrenar.Size = new System.Drawing.Size(361, 50);
            this.btnEntrenar.TabIndex = 6;
            this.btnEntrenar.Text = "      Entrenar";
            this.btnEntrenar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntrenar.Textcolor = System.Drawing.Color.SeaGreen;
            this.btnEntrenar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrenar.Click += new System.EventHandler(this.BtnEntrenar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.ForestGreen;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(339, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Control de pasos de entrenamiento";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.numericUpDown1);
            this.panel10.Controls.Add(this.label9);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(361, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(279, 151);
            this.panel10.TabIndex = 14;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(0, 25);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(279, 32);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.ForestGreen;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(273, 25);
            this.label9.TabIndex = 13;
            this.label9.Text = "Velocidad de Entrenamiento";
            // 
            // bunifuGradientPanel2
            // 
            this.bunifuGradientPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel2.BackgroundImage")));
            this.bunifuGradientPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel2.Controls.Add(this.panel5);
            this.bunifuGradientPanel2.Controls.Add(this.panel8);
            this.bunifuGradientPanel2.Controls.Add(this.panel12);
            this.bunifuGradientPanel2.Controls.Add(this.panel1);
            this.bunifuGradientPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuGradientPanel2.GradientBottomLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel2.GradientBottomRight = System.Drawing.Color.White;
            this.bunifuGradientPanel2.GradientTopLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel2.GradientTopRight = System.Drawing.Color.White;
            this.bunifuGradientPanel2.Location = new System.Drawing.Point(3, 3);
            this.bunifuGradientPanel2.Name = "bunifuGradientPanel2";
            this.bunifuGradientPanel2.Quality = 10;
            this.bunifuGradientPanel2.Size = new System.Drawing.Size(928, 841);
            this.bunifuGradientPanel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this.txtLog);
            this.panel5.Controls.Add(this.CmbAlgoritmoEntrenamiento);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.NudRataDinamica);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.btnBorrarLog);
            this.panel5.Controls.Add(this.nudRataAprendizaje);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.nudErrorMaximo);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.nudNoIteraciones);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 298);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(233, 543);
            this.panel5.TabIndex = 12;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(0, 286);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(233, 216);
            this.txtLog.TabIndex = 11;
            this.txtLog.Text = "";
            // 
            // CmbAlgoritmoEntrenamiento
            // 
            this.CmbAlgoritmoEntrenamiento.Dock = System.Windows.Forms.DockStyle.Top;
            this.CmbAlgoritmoEntrenamiento.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbAlgoritmoEntrenamiento.FormattingEnabled = true;
            this.CmbAlgoritmoEntrenamiento.Items.AddRange(new object[] {
            "Regla Delta",
            "BackPropagation"});
            this.CmbAlgoritmoEntrenamiento.Location = new System.Drawing.Point(0, 253);
            this.CmbAlgoritmoEntrenamiento.Name = "CmbAlgoritmoEntrenamiento";
            this.CmbAlgoritmoEntrenamiento.Size = new System.Drawing.Size(233, 33);
            this.CmbAlgoritmoEntrenamiento.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.ForestGreen;
            this.label8.Location = new System.Drawing.Point(0, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(238, 25);
            this.label8.TabIndex = 16;
            this.label8.Text = "AlgoritmoEntrenamiento";
            // 
            // NudRataDinamica
            // 
            this.NudRataDinamica.DecimalPlaces = 5;
            this.NudRataDinamica.Dock = System.Windows.Forms.DockStyle.Top;
            this.NudRataDinamica.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NudRataDinamica.Location = new System.Drawing.Point(0, 196);
            this.NudRataDinamica.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudRataDinamica.Name = "NudRataDinamica";
            this.NudRataDinamica.Size = new System.Drawing.Size(233, 32);
            this.NudRataDinamica.TabIndex = 13;
            this.NudRataDinamica.Value = new decimal(new int[] {
            9,
            0,
            0,
            131072});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.ForestGreen;
            this.label7.Location = new System.Drawing.Point(0, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "Rata Dinamica";
            this.label7.Click += new System.EventHandler(this.Label7_Click);
            // 
            // btnBorrarLog
            // 
            this.btnBorrarLog.ActiveBorderThickness = 1;
            this.btnBorrarLog.ActiveCornerRadius = 20;
            this.btnBorrarLog.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnBorrarLog.ActiveForecolor = System.Drawing.Color.White;
            this.btnBorrarLog.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnBorrarLog.BackColor = System.Drawing.Color.Transparent;
            this.btnBorrarLog.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBorrarLog.BackgroundImage")));
            this.btnBorrarLog.ButtonText = "Borrar Log";
            this.btnBorrarLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrarLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBorrarLog.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarLog.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnBorrarLog.IdleBorderThickness = 1;
            this.btnBorrarLog.IdleCornerRadius = 20;
            this.btnBorrarLog.IdleFillColor = System.Drawing.Color.White;
            this.btnBorrarLog.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnBorrarLog.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnBorrarLog.Location = new System.Drawing.Point(0, 502);
            this.btnBorrarLog.Margin = new System.Windows.Forms.Padding(5);
            this.btnBorrarLog.Name = "btnBorrarLog";
            this.btnBorrarLog.Size = new System.Drawing.Size(233, 41);
            this.btnBorrarLog.TabIndex = 4;
            this.btnBorrarLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBorrarLog.Click += new System.EventHandler(this.BtnBorrarLog_Click);
            // 
            // nudRataAprendizaje
            // 
            this.nudRataAprendizaje.DecimalPlaces = 5;
            this.nudRataAprendizaje.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudRataAprendizaje.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRataAprendizaje.Location = new System.Drawing.Point(0, 139);
            this.nudRataAprendizaje.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRataAprendizaje.Name = "nudRataAprendizaje";
            this.nudRataAprendizaje.Size = new System.Drawing.Size(233, 32);
            this.nudRataAprendizaje.TabIndex = 8;
            this.nudRataAprendizaje.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.ForestGreen;
            this.label2.Location = new System.Drawing.Point(0, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rata de Aprendizaje";
            // 
            // nudErrorMaximo
            // 
            this.nudErrorMaximo.DecimalPlaces = 5;
            this.nudErrorMaximo.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudErrorMaximo.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudErrorMaximo.Location = new System.Drawing.Point(0, 82);
            this.nudErrorMaximo.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudErrorMaximo.Name = "nudErrorMaximo";
            this.nudErrorMaximo.Size = new System.Drawing.Size(233, 32);
            this.nudErrorMaximo.TabIndex = 9;
            this.nudErrorMaximo.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.ForestGreen;
            this.label3.Location = new System.Drawing.Point(0, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Error Maximo";
            // 
            // nudNoIteraciones
            // 
            this.nudNoIteraciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudNoIteraciones.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNoIteraciones.Location = new System.Drawing.Point(0, 25);
            this.nudNoIteraciones.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudNoIteraciones.Name = "nudNoIteraciones";
            this.nudNoIteraciones.Size = new System.Drawing.Size(233, 32);
            this.nudNoIteraciones.TabIndex = 10;
            this.nudNoIteraciones.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.ForestGreen;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "N° Iteraciones";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Controls.Add(this.panel14);
            this.panel8.Controls.Add(this.panel18);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(233, 298);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(695, 543);
            this.panel8.TabIndex = 1;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.btnSimular);
            this.panel14.Controls.Add(this.DgvParametrosSimulacion);
            this.panel14.Controls.Add(this.panel16);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(0, 190);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(695, 353);
            this.panel14.TabIndex = 14;
            // 
            // btnSimular
            // 
            this.btnSimular.ActiveBorderThickness = 1;
            this.btnSimular.ActiveCornerRadius = 20;
            this.btnSimular.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnSimular.ActiveForecolor = System.Drawing.Color.White;
            this.btnSimular.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnSimular.BackColor = System.Drawing.Color.Transparent;
            this.btnSimular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSimular.BackgroundImage")));
            this.btnSimular.ButtonText = "Simular";
            this.btnSimular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimular.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSimular.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimular.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnSimular.IdleBorderThickness = 1;
            this.btnSimular.IdleCornerRadius = 20;
            this.btnSimular.IdleFillColor = System.Drawing.Color.White;
            this.btnSimular.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnSimular.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnSimular.Location = new System.Drawing.Point(0, 214);
            this.btnSimular.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnSimular.Name = "btnSimular";
            this.btnSimular.Size = new System.Drawing.Size(695, 68);
            this.btnSimular.TabIndex = 3;
            this.btnSimular.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSimular.Click += new System.EventHandler(this.BtnSimular_Click_1);
            // 
            // DgvParametrosSimulacion
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvParametrosSimulacion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvParametrosSimulacion.BackgroundColor = System.Drawing.Color.White;
            this.DgvParametrosSimulacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvParametrosSimulacion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvParametrosSimulacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvParametrosSimulacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvParametrosSimulacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.DgvParametrosSimulacion.DoubleBuffered = true;
            this.DgvParametrosSimulacion.EnableHeadersVisualStyles = false;
            this.DgvParametrosSimulacion.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.DgvParametrosSimulacion.HeaderForeColor = System.Drawing.Color.Honeydew;
            this.DgvParametrosSimulacion.Location = new System.Drawing.Point(0, 48);
            this.DgvParametrosSimulacion.Name = "DgvParametrosSimulacion";
            this.DgvParametrosSimulacion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DgvParametrosSimulacion.Size = new System.Drawing.Size(695, 166);
            this.DgvParametrosSimulacion.TabIndex = 4;
            this.DgvParametrosSimulacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvParametrosSimulacion_KeyDown);
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel16.Controls.Add(this.label11);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(0, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(695, 48);
            this.panel16.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.ForestGreen;
            this.label11.Location = new System.Drawing.Point(183, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(285, 35);
            this.label11.TabIndex = 17;
            this.label11.Text = "Simulacion de la Red";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.panel13);
            this.panel18.Controls.Add(this.panel15);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(0, 0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(695, 190);
            this.panel18.TabIndex = 4;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.btnNuevo);
            this.panel13.Controls.Add(this.btnInicializarRed);
            this.panel13.Controls.Add(this.btnCargarPesosyUmbrales);
            this.panel13.Controls.Add(this.btnCargarPatrones);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(343, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(352, 190);
            this.panel13.TabIndex = 13;
            // 
            // btnNuevo
            // 
            this.btnNuevo.ActiveBorderThickness = 1;
            this.btnNuevo.ActiveCornerRadius = 20;
            this.btnNuevo.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnNuevo.ActiveForecolor = System.Drawing.Color.White;
            this.btnNuevo.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnNuevo.BackColor = System.Drawing.Color.Transparent;
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.ButtonText = "Nuevo";
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNuevo.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnNuevo.IdleBorderThickness = 1;
            this.btnNuevo.IdleCornerRadius = 20;
            this.btnNuevo.IdleFillColor = System.Drawing.Color.White;
            this.btnNuevo.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnNuevo.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnNuevo.Location = new System.Drawing.Point(0, 138);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(352, 46);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // btnInicializarRed
            // 
            this.btnInicializarRed.ActiveBorderThickness = 1;
            this.btnInicializarRed.ActiveCornerRadius = 20;
            this.btnInicializarRed.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnInicializarRed.ActiveForecolor = System.Drawing.Color.White;
            this.btnInicializarRed.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnInicializarRed.BackColor = System.Drawing.Color.Transparent;
            this.btnInicializarRed.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInicializarRed.BackgroundImage")));
            this.btnInicializarRed.ButtonText = "Inicializar Red";
            this.btnInicializarRed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicializarRed.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInicializarRed.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicializarRed.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnInicializarRed.IdleBorderThickness = 1;
            this.btnInicializarRed.IdleCornerRadius = 20;
            this.btnInicializarRed.IdleFillColor = System.Drawing.Color.White;
            this.btnInicializarRed.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnInicializarRed.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnInicializarRed.Location = new System.Drawing.Point(0, 92);
            this.btnInicializarRed.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnInicializarRed.Name = "btnInicializarRed";
            this.btnInicializarRed.Size = new System.Drawing.Size(352, 46);
            this.btnInicializarRed.TabIndex = 1;
            this.btnInicializarRed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnInicializarRed.Click += new System.EventHandler(this.BtnInicializarRed_Click);
            // 
            // btnCargarPesosyUmbrales
            // 
            this.btnCargarPesosyUmbrales.ActiveBorderThickness = 1;
            this.btnCargarPesosyUmbrales.ActiveCornerRadius = 20;
            this.btnCargarPesosyUmbrales.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnCargarPesosyUmbrales.ActiveForecolor = System.Drawing.Color.White;
            this.btnCargarPesosyUmbrales.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnCargarPesosyUmbrales.BackColor = System.Drawing.Color.Transparent;
            this.btnCargarPesosyUmbrales.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargarPesosyUmbrales.BackgroundImage")));
            this.btnCargarPesosyUmbrales.ButtonText = "Cargar Pesos y umbrales";
            this.btnCargarPesosyUmbrales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarPesosyUmbrales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCargarPesosyUmbrales.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarPesosyUmbrales.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnCargarPesosyUmbrales.IdleBorderThickness = 1;
            this.btnCargarPesosyUmbrales.IdleCornerRadius = 20;
            this.btnCargarPesosyUmbrales.IdleFillColor = System.Drawing.Color.White;
            this.btnCargarPesosyUmbrales.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnCargarPesosyUmbrales.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnCargarPesosyUmbrales.Location = new System.Drawing.Point(0, 46);
            this.btnCargarPesosyUmbrales.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnCargarPesosyUmbrales.Name = "btnCargarPesosyUmbrales";
            this.btnCargarPesosyUmbrales.Size = new System.Drawing.Size(352, 46);
            this.btnCargarPesosyUmbrales.TabIndex = 2;
            this.btnCargarPesosyUmbrales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCargarPesosyUmbrales.Click += new System.EventHandler(this.BtnCargarPesosyUmbrales_Click);
            // 
            // btnCargarPatrones
            // 
            this.btnCargarPatrones.ActiveBorderThickness = 1;
            this.btnCargarPatrones.ActiveCornerRadius = 20;
            this.btnCargarPatrones.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnCargarPatrones.ActiveForecolor = System.Drawing.Color.White;
            this.btnCargarPatrones.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnCargarPatrones.BackColor = System.Drawing.Color.Transparent;
            this.btnCargarPatrones.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargarPatrones.BackgroundImage")));
            this.btnCargarPatrones.ButtonText = "Cargar Patrones";
            this.btnCargarPatrones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarPatrones.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCargarPatrones.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarPatrones.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnCargarPatrones.IdleBorderThickness = 1;
            this.btnCargarPatrones.IdleCornerRadius = 20;
            this.btnCargarPatrones.IdleFillColor = System.Drawing.Color.White;
            this.btnCargarPatrones.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnCargarPatrones.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnCargarPatrones.Location = new System.Drawing.Point(0, 0);
            this.btnCargarPatrones.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnCargarPatrones.Name = "btnCargarPatrones";
            this.btnCargarPatrones.Size = new System.Drawing.Size(352, 46);
            this.btnCargarPatrones.TabIndex = 0;
            this.btnCargarPatrones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCargarPatrones.Click += new System.EventHandler(this.BtnCargarPatrones_Click);
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.dgvTopologiaRed);
            this.panel15.Controls.Add(this.nudNumeroCapas);
            this.panel15.Controls.Add(this.label1);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(343, 190);
            this.panel15.TabIndex = 15;
            // 
            // dgvTopologiaRed
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvTopologiaRed.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTopologiaRed.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopologiaRed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTopologiaRed.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTopologiaRed.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTopologiaRed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopologiaRed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Capa,
            this.Neuronas,
            this.Activacion});
            this.dgvTopologiaRed.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTopologiaRed.DoubleBuffered = true;
            this.dgvTopologiaRed.EnableHeadersVisualStyles = false;
            this.dgvTopologiaRed.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.dgvTopologiaRed.HeaderForeColor = System.Drawing.Color.Honeydew;
            this.dgvTopologiaRed.Location = new System.Drawing.Point(0, 57);
            this.dgvTopologiaRed.Name = "dgvTopologiaRed";
            this.dgvTopologiaRed.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTopologiaRed.Size = new System.Drawing.Size(343, 120);
            this.dgvTopologiaRed.TabIndex = 4;
            this.dgvTopologiaRed.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvTopologiaRed_EditingControlShowing);
            // 
            // Capa
            // 
            this.Capa.HeaderText = "Capa";
            this.Capa.Name = "Capa";
            // 
            // Neuronas
            // 
            this.Neuronas.HeaderText = "Neuronas";
            this.Neuronas.Name = "Neuronas";
            // 
            // Activacion
            // 
            this.Activacion.HeaderText = "Activacion";
            this.Activacion.Items.AddRange(new object[] {
            "Sigmoidal",
            "Tangente Hiperbolico",
            "Escalon"});
            this.Activacion.Name = "Activacion";
            // 
            // nudNumeroCapas
            // 
            this.nudNumeroCapas.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudNumeroCapas.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNumeroCapas.Location = new System.Drawing.Point(0, 25);
            this.nudNumeroCapas.Name = "nudNumeroCapas";
            this.nudNumeroCapas.Size = new System.Drawing.Size(343, 32);
            this.nudNumeroCapas.TabIndex = 12;
            this.nudNumeroCapas.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudNumeroCapas.ValueChanged += new System.EventHandler(this.NudNumeroCapas_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Numero de Capas";
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel12.Controls.Add(this.label10);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 250);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(928, 48);
            this.panel12.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.ForestGreen;
            this.label10.Location = new System.Drawing.Point(299, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(325, 35);
            this.label10.TabIndex = 17;
            this.label10.Text = "Configuracion de la Red";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel17);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(928, 250);
            this.panel1.TabIndex = 11;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.lblEntradas);
            this.panel7.Controls.Add(this.lblSalidas);
            this.panel7.Controls.Add(this.lblPatrones);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(696, 48);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(232, 202);
            this.panel7.TabIndex = 2;
            // 
            // lblEntradas
            // 
            this.lblEntradas.AutoSize = true;
            this.lblEntradas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEntradas.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntradas.Location = new System.Drawing.Point(0, 75);
            this.lblEntradas.Name = "lblEntradas";
            this.lblEntradas.Size = new System.Drawing.Size(91, 25);
            this.lblEntradas.TabIndex = 1;
            this.lblEntradas.Text = "Entradas";
            // 
            // lblSalidas
            // 
            this.lblSalidas.AutoSize = true;
            this.lblSalidas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSalidas.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalidas.Location = new System.Drawing.Point(0, 50);
            this.lblSalidas.Name = "lblSalidas";
            this.lblSalidas.Size = new System.Drawing.Size(76, 25);
            this.lblSalidas.TabIndex = 2;
            this.lblSalidas.Text = "Salidas";
            // 
            // lblPatrones
            // 
            this.lblPatrones.AutoSize = true;
            this.lblPatrones.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPatrones.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatrones.Location = new System.Drawing.Point(0, 25);
            this.lblPatrones.Name = "lblPatrones";
            this.lblPatrones.Size = new System.Drawing.Size(93, 25);
            this.lblPatrones.TabIndex = 0;
            this.lblPatrones.Text = "Patrones";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.ForestGreen;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(227, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "Propiedades del Patron";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvPatrones);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 48);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(696, 202);
            this.panel4.TabIndex = 1;
            // 
            // dgvPatrones
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPatrones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPatrones.BackgroundColor = System.Drawing.Color.White;
            this.dgvPatrones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPatrones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatrones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPatrones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatrones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Entradas,
            this.Salidas});
            this.dgvPatrones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatrones.DoubleBuffered = true;
            this.dgvPatrones.EnableHeadersVisualStyles = false;
            this.dgvPatrones.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.dgvPatrones.HeaderForeColor = System.Drawing.Color.Honeydew;
            this.dgvPatrones.Location = new System.Drawing.Point(0, 0);
            this.dgvPatrones.Name = "dgvPatrones";
            this.dgvPatrones.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPatrones.Size = new System.Drawing.Size(696, 202);
            this.dgvPatrones.TabIndex = 0;
            // 
            // Entradas
            // 
            this.Entradas.HeaderText = "Entradas";
            this.Entradas.Name = "Entradas";
            // 
            // Salidas
            // 
            this.Salidas.HeaderText = "Salidas";
            this.Salidas.Name = "Salidas";
            // 
            // panel17
            // 
            this.panel17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel17.Controls.Add(this.label12);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(928, 48);
            this.panel17.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.ForestGreen;
            this.label12.Location = new System.Drawing.Point(299, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(367, 35);
            this.label12.TabIndex = 17;
            this.label12.Text = "Patrones de Entrenamiento";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1582, 873);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabControl1_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 873);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Perceptron Unicapa";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartErrorvsIteracion)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.bunifuGradientPanel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.bunifuGradientPanel2.ResumeLayout(false);
            this.bunifuGradientPanel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudRataDinamica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRataAprendizaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudErrorMaximo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoIteraciones)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvParametrosSimulacion)).EndInit();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopologiaRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroCapas)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatrones)).EndInit();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartErrorvsIteracion;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel4;
        private System.Windows.Forms.Panel panel9;
        private LiveCharts.WinForms.CartesianChart CartesianErrors;
        private System.Windows.Forms.Panel panel3;
        private LiveCharts.WinForms.CartesianChart CartesianVariacionRealDeseada;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private Bunifu.Framework.UI.BunifuFlatButton btnContinuar;
        private Bunifu.Framework.UI.BunifuFlatButton btnEntrenar;
        private System.Windows.Forms.Panel panel8;
        private Bunifu.Framework.UI.BunifuThinButton2 btnNuevo;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSimular;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvTopologiaRed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Neuronas;
        private System.Windows.Forms.DataGridViewComboBoxColumn Activacion;
        private Bunifu.Framework.UI.BunifuThinButton2 btnInicializarRed;
        private Bunifu.Framework.UI.BunifuThinButton2 btnCargarPesosyUmbrales;
        private Bunifu.Framework.UI.BunifuThinButton2 btnCargarPatrones;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.ComboBox CmbAlgoritmoEntrenamiento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown NudRataDinamica;
        private System.Windows.Forms.Label label7;
        private Bunifu.Framework.UI.BunifuThinButton2 btnBorrarLog;
        private System.Windows.Forms.NumericUpDown nudNumeroCapas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudRataAprendizaje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudErrorMaximo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudNoIteraciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPatrones;
        private System.Windows.Forms.Label lblSalidas;
        private System.Windows.Forms.Label lblEntradas;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvPatrones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entradas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salidas;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel14;
        private Bunifu.Framework.UI.BunifuCustomDataGrid DgvParametrosSimulacion;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label label12;
    }
}

