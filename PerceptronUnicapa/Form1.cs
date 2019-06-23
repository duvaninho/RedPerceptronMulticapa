using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Utilidades;
using System.Threading;


namespace PerceptronUnicapa
{
    
    public partial class Form1 : Form
    {
        #region Dlls para poder hacer el movimiento del Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        Rectangle sizeGripRectangle;
        bool inSizeDrag = false;
        const int GRIP_SIZE = 15;
        List<Perceptron> perceptrons = new List<Perceptron>();
        int w = 0;
        int h = 0;
        #endregion
        private List<ComboBoxes> comboBoxes = new List<ComboBoxes>();
        double[,] matrizEntradas;
        double[,] matrizSalidas;
        int cantidadEntradas, cantidadSalidas, patrones;
        bool redInicializada, redEntrenada;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;            
            redInicializada = false;
            redEntrenada = false;
            chartError.Titles.Add("Error entrenamiento Vs Iteracion");
            chartError.Titles[0].Font = new Font("Microsoft YaHei UI", 15);
            chartError.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chartError.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            chartError.ChartAreas["ChartArea1"].AxisX.RoundAxisValues();
            chartPesos.Titles.Add("Varacion de Pesos sinapticos Vs Iteracion");
            chartPesos.Titles[0].Font = new Font("Microsoft YaHei UI", 15);
            chartPesos.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chartPesos.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            chartPesos.ChartAreas["ChartArea1"].AxisX.RoundAxisValues();
            chartUmbrales.Titles.Add("Variacion de Umbrales Vs Iteracion");
            chartUmbrales.Titles[0].Font = new Font("Microsoft YaHei UI", 15);
            chartUmbrales.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chartUmbrales.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;            
            chartUmbrales.ChartAreas["ChartArea1"].AxisX.RoundAxisValues();

        }

        

        private void btnInicializarRed_Click(object sender, EventArgs e)
        {
            if (patrones == 0)
            {
                MessageBox.Show("Debe cargar un archivo para continuar con el entreamiento",
                    "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(nudRataAprendizaje.Value <= 0)
            {
                MessageBox.Show("Ingrese una rata de aprendizaje correcta(>0)",
                   "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (nudNoIteraciones.Value <= 0)
            {
                MessageBox.Show("Ingrese un numero de iteraciones valido",
                   "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                int[] neuronasPorCapa = new int[Convert.ToInt16( nudNumeroCapas.Value)];
                int numeroActivaciones = Convert.ToInt16(nudNumeroCapas.Value);
                int[] activaciones = new int[numeroActivaciones];               
                activaciones[0] = 1;
                
                for (int i = 0; i < numeroActivaciones; i++)
                {
                    neuronasPorCapa[i] = Convert.ToInt32( dgvTopologiaRed[1, i].Value);
                    activaciones[i] = comboBoxes[i].opcion;
                    
                }                
                Random random = new Random();
                perceptrons.Add(new Perceptron(this.matrizSalidas, Convert.ToDouble(
                    nudErrorMaximo.Value), this.patrones, Convert.ToDouble(
                        this.nudRataAprendizaje.Value), Convert.ToInt16(
                     nudNoIteraciones.Value), this.matrizEntradas, random,
                    activaciones, neuronasPorCapa, Convert.ToDouble(NudRataDinamica.Value),
                    CmbAlgoritmoEntrenamiento.SelectedIndex));
                redInicializada = true;
                txtLog.Text += "Red Inicalizada con exito\n";
                txtLog.Text += "_____________________\n";
            }
        }

        private void btnEntrenar_Click(object sender, EventArgs e)
        {
            if (patrones == 0)
            {
                MessageBox.Show("Debe cargar un archivo para continuar con el entrenamiento",
                    "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (redInicializada)
            {
                foreach (var perceptron in perceptrons)
                {
                    if (perceptron.errorEntrenamiento < perceptron.errorMaximo)
                    {
                        MessageBox.Show("La red ha entrenado en la iteracion " + perceptron.iteracionesEntrenamiento,
                            "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //removerColumnasDataDrid(dgvPesosyUmbrales);
                        //dgvPesosyUmbrales.ColumnCount = cantidadEntradas + 1;
                        //int h = 1;
                        //for (int i = 0; i < dgvPesosyUmbrales.ColumnCount; i++)
                        //{
                        //    if (i < cantidadEntradas)
                        //    {
                        //        dgvPesosyUmbrales.Columns[i].Name = "peso" + (i + 1);
                        //    }
                        //    else
                        //    {
                        //        dgvPesosyUmbrales.Columns[i].Name = "umbral" + h;
                        //        h++;
                        //    }
                        //}
                        //string[] pesosyumbrales = new string[cantidadSalidas];
                        //int pesosFinales = 0;
                        //foreach (var neurona in perceptron.capas)
                        //{
                        //    string cadenaPesosUmbrales = "";
                        //    for (int i = 0; i < neurona.pesosSimulacion.Length; i++)
                        //    {
                        //        cadenaPesosUmbrales += neurona.pesosSimulacion[i] + ";";
                        //    }
                        //    cadenaPesosUmbrales += neurona.umbralSimulacion + ";";
                        //    pesosyumbrales[pesosFinales] = cadenaPesosUmbrales;
                        //    dgvPesosyUmbrales.Rows.Add(pesosyumbrales[pesosFinales].Split(';'));
                        //    pesosFinales++;
                        //}
                    }
                    else
                    {
                        perceptron.Entrenar();
                        chartError.Series[0].Points.AddXY(
                            perceptron.iteracionesEntrenamiento, perceptron.errorEntrenamiento);
                        //int iteradorSeriePesos = 0;
                        //int iteradorSerieUmbral = 0;
                        //foreach (var neurona in perceptron.capas)
                        //{
                        //    for (int i = 0; i < neurona.pesosSimulacion.Length; i++)
                        //    {
                        //        chartPesos.Series[iteradorSeriePesos].Points.AddXY(
                        //            perceptron.iteracionesEntrenamiento,
                        //            neurona.pesosSimulacion[i]);
                        //        iteradorSeriePesos++;
                        //    }
                        //    chartUmbrales.Series[iteradorSerieUmbral].Points.AddXY(
                        //        perceptron.iteracionesEntrenamiento,
                        //        neurona.umbralSimulacion);
                        //    iteradorSerieUmbral++;
                        //}
                        if (!perceptron.entrenando)
                        {
                            redEntrenada = true;

                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Debe inicializar la red para continuar con el entrenamiento",
                   "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void removerColumnasDataDrid(DataGridView dataGridView)
        {
            if (dataGridView.Columns.Count >0)
            {
                int columnas = dataGridView.Columns.Count;
                for (int i = 0; i < columnas; i++)
                {
                    dataGridView.Columns.RemoveAt(0);
                }
            }
        }
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (patrones == 0)
            {
                MessageBox.Show("Debe cargar un archivo para continuar con el entreamiento",
                    "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (redInicializada)
            {
                //removerColumnasDataDrid(dgvPesosyUmbrales);
                //dgvPesosyUmbrales.ColumnCount = cantidadEntradas + 1;
                //int h = 1;
                //for (int i = 0; i < dgvPesosyUmbrales.ColumnCount; i++)
                //{
                //    if (i < cantidadEntradas)
                //    {
                //        dgvPesosyUmbrales.Columns[i].Name = "peso" + (i + 1);
                //    }
                //    else
                //    {
                //        dgvPesosyUmbrales.Columns[i].Name = "umbral" + h;
                //        h++;
                //    }
                //}
                //string[] pesosyumbrales = new string[cantidadSalidas];
                foreach (var perceptron in perceptrons)
                {
                    while (perceptron.entrenando && perceptron.iteracionesEntrenamiento <=
                        perceptron.iteracionesRequeridas)
                    {
                        perceptron.Entrenar();
                        chartError.Series[0].Points.AddXY(
                            perceptron.iteracionesEntrenamiento,
                            perceptron.errorEntrenamiento);
                        chartError.Update();
                        //chartUmbrales.Update();
                        //chartPesos.Update();
                        //chartError.ChartAreas[0].RecalculateAxesScale();
                        //int iteradorSeriePesos = 0;
                        //int iteradorSerieUmbral = 0;
                        //int pesosFinales = 0;
                        //foreach (var neurona in perceptron.neuronas)
                        //{
                        //    string cadenaPesosUmbrales = "";
                        //    for (int i = 0; i < neurona.pesosSimulacion.Length; i++)
                        //    {
                        //        cadenaPesosUmbrales += neurona.pesosSimulacion[i] + ";";
                        //        chartPesos.Series[iteradorSeriePesos].Points.AddXY(
                        //            perceptron.iteracionesEntrenamiento,
                        //            neurona.pesosSimulacion[i]);

                        //        iteradorSeriePesos++;
                        //    }
                        //    chartUmbrales.Series[iteradorSerieUmbral].Points.AddXY(
                        //        perceptron.iteracionesEntrenamiento,
                        //        neurona.umbralSimulacion);
                        //    cadenaPesosUmbrales += neurona.umbralSimulacion + ";";
                        //    iteradorSerieUmbral++;
                        //    pesosyumbrales[pesosFinales] = cadenaPesosUmbrales;
                        //    pesosFinales++;
                        //}
                        //Thread.Sleep(500);
                    }

                    //    for (int i = 0; i < pesosyumbrales.Length; i++)
                    //    {
                    //        dgvPesosyUmbrales.Rows.Add(pesosyumbrales[i].Split(';'));
                    //    }
                    //    if (!perceptron.entrenando)
                    //    {
                    //        redEntrenada = true;
                    //        DialogResult result =
                    //        MessageBox.Show("\tLa Red Ha entrenado.\n¿Desea guardar " +
                    //            "pesos y umbrales?", "Informacion", MessageBoxButtons
                    //            .YesNoCancel, MessageBoxIcon.Question);
                    //        if (result == DialogResult.Yes)
                    //        {
                    //            saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
                    //            if (saveFileDialog1.ShowDialog() ==
                    //                DialogResult.OK && saveFileDialog1.FileName.Length
                    //                > 0)
                    //            {
                    //                bool band = false;
                    //                try
                    //                {
                    //                    FileInfo fileInfo = new FileInfo(saveFileDialog1.FileName);
                    //                    StreamWriter writer = fileInfo.CreateText();
                    //                    string header = "";
                    //                    for (int i = 0; i < cantidadEntradas; i++)
                    //                    {
                    //                        header += "peso" + i + ";";
                    //                    }
                    //                    header += "umbral";
                    //                    writer.WriteLine(header);
                    //                    foreach (var neurona in perceptron.neuronas)
                    //                    {
                    //                        string cadena = "";
                    //                        for (int i = 0; i < neurona.pesosSimulacion.Length; i++)
                    //                        {
                    //                            cadena += neurona.pesosSimulacion[i] + ";";
                    //                        }
                    //                        cadena += neurona.umbralSimulacion;
                    //                        writer.WriteLine(cadena);
                    //                    }
                    //                    writer.Close();
                    //                }
                    //                catch (Exception)
                    //                {

                    //                    throw;
                    //                }
                    //            }
                    //            //for (int i = 0; i < length; i++)
                    //            //{

                    //            //}
                    //            //foreach (var neurona in perceptron.neuronas)
                    //            //{

                    //            //}
                    //             }
                    //    }
                    //}
                    //else
                    //{
                    //    redEntrenada = false;
                    //    DialogResult result =
                    //    MessageBox.Show("\tLa Red no alcanzó a entrenar.\n¿Desea guardar " +
                    //        "pesos y umbrales?", "Informacion", MessageBoxButtons
                    //        .YesNoCancel, MessageBoxIcon.Question);
                    //    if (result == DialogResult.Yes)
                    //    {
                    //        saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
                    //        if (saveFileDialog1.ShowDialog() ==
                    //            DialogResult.OK && saveFileDialog1.FileName.Length
                    //            > 0)
                    //        {
                    //            bool band = false;
                    //            try
                    //            {
                    //                FileInfo fileInfo = new FileInfo(saveFileDialog1.FileName);
                    //                StreamWriter writer = fileInfo.CreateText();
                    //                string header = "";
                    //                for (int i = 0; i < cantidadEntradas; i++)
                    //                {
                    //                    header += "peso" + i + ";";
                    //                }
                    //                header += "umbral";
                    //                writer.WriteLine(header);
                    //                foreach (var neurona in perceptron.neuronas)
                    //                {
                    //                    string cadena = "";
                    //                    for (int i = 0; i < neurona.pesosSimulacion.Length; i++)
                    //                    {
                    //                        cadena += neurona.pesosSimulacion[i] + ";";
                    //                    }
                    //                    cadena += neurona.umbralSimulacion;
                    //                    writer.WriteLine(cadena);
                    //                }
                    //                writer.Close();
                    //            }
                    //            catch (Exception)
                    //            {

                    //                throw;
                    //            }
                    //        }
                    //        //for (int i = 0; i < length; i++)
                    //        //{

                    //        //}
                    //        //foreach (var neurona in perceptron.neuronas)
                    //        //{

                    //        //}
                    //}
                    //}
                    }
            }
            else
            {
                    MessageBox.Show("Debe inicializar la red para continuar con el entrenamiento",
                       "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
        private void btnSimular_Click(object sender, EventArgs e)
        {
        //    if (patrones == 0)
        //    {
        //        MessageBox.Show("Debe cargar un archivo para continuar con el entreamiento",
        //            "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    else if (redInicializada)
        //    {
        //        DialogResult respuesta = MessageBox.Show("¿Desea simular los patrones" +
        //            "que participaron en la fase de entrenamiento?", "Informacion",
        //            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
        //        if (respuesta == DialogResult.Yes)
        //        {
        //            removerColumnasDataDrid(dgvSimulacion);
        //            dgvSimulacion.ColumnCount = cantidadSalidas * 2;
        //            int h = 1;
        //            for (int i = 0; i < dgvSimulacion.ColumnCount; i++)
        //            {
        //                if (i < dgvSimulacion.ColumnCount / 2)
        //                {
        //                    dgvSimulacion.Columns[i].Name = "yd" + (i + 1);
        //                }
        //                else
        //                {
        //                    dgvSimulacion.Columns[i].Name = "yr" + h;
        //                    h++;
        //                }
        //            }

        //            foreach (var perceptron in perceptrons)
        //            {
        //                double[] vector = new double[cantidadSalidas];
        //                for (int i = 0; i < patrones; i++)
        //                {
        //                    (perceptron.SimularRed(perceptron.ObtenerPatron(i))).CopyTo(vector, 0);
        //                    string salidaDeseada = "";
        //                    string salidaReal = "";
        //                    for (int j = 0; j < vector.Length; j++)
        //                    {
        //                        salidaDeseada += matrizSalidas[i, j] + ";";
        //                        salidaReal += vector[j] + ";";
        //                    }
        //                    string paraDataGrid = salidaDeseada + salidaReal;
        //                    dgvSimulacion.Rows.Add(paraDataGrid.Split(';'));
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (respuesta == DialogResult.No)
        //            {
        //                //int[] vector = new int[cantidadEntradas];
        //                //for (int i = 0; i < vector.Length; i++)
        //                //{
        //                //    vector[i] = 
        //                //}
        //            }
        //        }
        //    }
        //    else if (!redEntrenada)
        //    {
        //        MessageBox.Show("La red aún no ha entrenado", "Informacion", MessageBoxButtons.OK,
        //            MessageBoxIcon.Information);
        //    }

        }

        private void btnCargarPesosyUmbrales_Click(object sender, EventArgs e)
        {
            //if (patrones == 0)
            //{
            //    MessageBox.Show("Debe cargar un archivo para continuar con el entreamiento",
            //        "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else if (redInicializada)
            //{
            //    OpenFileDialog d = new OpenFileDialog();
            //    List<String> datos = new List<string>();
            //    d.Title = "Importar archivo (.csv)";
            //    d.Filter = "Csv|*.csv";
            //    if (d.ShowDialog() == DialogResult.OK)
            //    {
            //        /// Console.WriteLine(d.FileName);            

            //        StreamReader reader = new StreamReader(d.FileName);
            //        string line = reader.ReadLine();
            //        string[] headers = line.Split(';');
            //        int pesos =0;
            //        int umbrales = 0;
            //        removerColumnasDataDrid(dgvPesosyUmbrales);
            //        dgvPesosyUmbrales.ColumnCount = headers.Length;
            //        for (int i = 0; i < headers.Length; i++)
            //        {
            //            dgvPesosyUmbrales.Columns[i].Name = headers[i]; 
            //            if (headers[i].Contains("peso"))
            //            {
            //                pesos++;
            //            }
            //            else
            //                umbrales++;
            //        }
            //        while (line != null)
            //        {
            //            line = reader.ReadLine();
            //            if (line != null)
            //            {
            //                datos.Add(line);

            //            }
            //        }                
            //        reader.Close();
            //        foreach (string patron in datos)
            //        {
            //            dgvPesosyUmbrales.Rows.Add(patron.Split(';'));
            //        }
            //        txtLog.Text += "Pesos y umbrales cargados con exito\n";
            //        foreach (var perceptron in perceptrons)
            //        {
            //            int k = 0;
            //            foreach (var neurona in perceptron.neuronas)
            //            {
            //                string[] linea = datos[k].Split(';');                            
            //                for (int i = 0; i < neurona.pesosSimulacion.Length; i++)
            //                {
            //                    neurona.pesosSimulacion[i] = Convert.ToDouble(linea[i]);                                                            
            //                }
            //                neurona.umbralSimulacion = Convert.ToDouble(linea[linea.Length - 1]);                            
            //                k++;
            //            }
            //            perceptron.entrenando = false;
            //        }
            //        txtLog.Text += "_____________________\n";
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("La red aún no esta inicializada", "Informacion", MessageBoxButtons.OK,
            //        MessageBoxIcon.Information);
            //}
        }

        private void btnBorrarLog_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
        }
        private void limpiarDataGrid(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            dataGridView.Refresh();
        }
        private void nudNumeroCapas_ValueChanged(object sender, EventArgs e)
        {
            limpiarDataGrid(dgvTopologiaRed);
            int k = 1;
            for (int i = 0; i < nudNumeroCapas.Value; i++)
            {
                if (i == nudNumeroCapas.Value - 1)
                {
                    dgvTopologiaRed.Rows.Add( "Salida",
                        "1");
                }
                else
                {

                    dgvTopologiaRed.Rows.Add("Oculta " + k,
                            "1");
                    k++;
                }

            }
        }

        private void dgvTopologiaRed_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox combo = e.Control as ComboBox;
            if (combo != null)
            {
                
                combo.SelectedIndexChanged -= new EventHandler(combo_SelectedIndexChange);
                combo.SelectedIndexChanged += combo_SelectedIndexChange;
            }

        }

        private void combo_SelectedIndexChange(object sender, EventArgs e)
        {
            string selectedIndex = (sender as ComboBox).SelectedIndex.ToString();
            int filaDataGrid = dgvTopologiaRed.CurrentCell.RowIndex;
            ComboBoxes combo =  comboBoxes.Find(x => x.indiceDatagridView == filaDataGrid);
            if (combo != null)
            {
                combo.opcion = Convert.ToInt16(selectedIndex);
                //comboBoxes.Add(combo);
            }
            else
            {
                combo = new ComboBoxes
                {
                    indiceDatagridView = filaDataGrid,
                    opcion = Convert.ToInt16(selectedIndex)
                };
                comboBoxes.Add(combo);
            }            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            perceptrons.Clear();
            comboBoxes.Clear();
            foreach (var series in chartError.Series)
            {
                series.Points.Clear();
            }
            foreach (var series in chartUmbrales.Series)
            {
                series.Points.Clear();
            }
            foreach (var series in chartPesos.Series)
            {
                series.Points.Clear();
            }
            limpiarDataGrid(dgvTopologiaRed);
            limpiarDataGrid(dgvSimulacion);
            limpiarDataGrid(dgvPesosyUmbrales);
            //while (dgvPesosyUmbrales.RowCount > 1)
            //{

            //    dgvPesosyUmbrales.Rows.Remove(dgvPesosyUmbrales.CurrentRow);

            //}
            //while (dgvSimulacion.RowCount > 1)
            //{

            //    dgvSimulacion.Rows.Remove(dgvSimulacion.CurrentRow);
            //}

        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            //para poder arrastrar el formulario sin bordes

            SendMessage(this.Handle, 0x112, 0xf012, 0);
            w = this.Width;
            h = this.Height;

        }

        private void btnCargarPatrones_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            List<String> datos = new List<string>();
            d.Title = "Importar archivo (.csv)";
            d.Filter = "Csv|*.csv";
            if (d.ShowDialog() == DialogResult.OK)
            {
                /// Console.WriteLine(d.FileName);            
                
                StreamReader reader = new StreamReader(d.FileName);

                string line = reader.ReadLine();
                string[] headers = line.Split(';');
                int entradas = 0;
                int salidas = 0;
                for (int i = 0; i < headers.Length; i++)
                {                   
                    if (headers[i].Contains("x"))
                    {
                        entradas++;
                    }
                    else
                        salidas++;
                            
                }
                if (entradas == 0)
                {
                    MessageBox.Show("El archivo de patrones debe contener una secuncia" +
                        " de entradas(x) y salidas(y), el presente archivo no sigue estas reglas" +
                        " intente cargar otro nuevamente","Atencion",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    removerColumnasDataDrid(dgvPatrones);
                    dgvPatrones.ColumnCount = headers.Length;
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dgvPatrones.Columns[i].Name = headers[i];
                    }    
                    while (line != null)
                    {                    
                        line = reader.ReadLine();
                        if (line !=null)
                        {
                            datos.Add(line);

                        }
                    }
                    this.patrones = datos.Count;
                    this.cantidadSalidas = salidas;
                    this.cantidadEntradas = entradas;
                    this.matrizEntradas = new double[patrones,cantidadEntradas];
                    this.matrizSalidas = new double[patrones, cantidadSalidas];
                    reader.Close();
                    limpiarDataGrid(dgvPatrones);
                

                    foreach (string patron in datos)
                    {                                                   
                        dgvPatrones.Rows.Add(patron.Split(';'));
                    }
                    for (int i = 0; i < patrones; i++)
                    {
                        string[] linea = datos[i].Split(';');
                        int k = 0;
                        for (int j = 0; j < salidas+entradas; j++)
                        {
                            if (j<2)
                            {
                                this.matrizEntradas[i, j] = int.Parse(linea[j]);
                            }
                            else
                            {                           
                                this.matrizSalidas[i, k] = int.Parse(linea[j]);
                                k++;
                            }
                        }
                    }
                    lblEntradas.Text = "Entradas: " + entradas;
                    lblSalidas.Text = "Salidas: " + salidas;
                    lblPatrones.Text = "Patrones: " + patrones;
                    dgvPatrones.AutoResizeColumns();
                    dgvPatrones.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    dgvPatrones.Dock = DockStyle.Fill;
                    chartPesos.Series.Clear();
                    chartUmbrales.Series.Clear();
                    for (int i = 0; i < entradas*salidas; i++)
                    {
                        chartPesos.Series.Add("Peso: " + i);
                        chartPesos.Series[i].ChartType = 
                            System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                       
                    }
                    for (int i = 0; i < salidas; i++)
                    {
                        chartUmbrales.Series.Add("Umbral: "+i);
                        chartUmbrales.Series[i].ChartType = 
                            System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    }
                    txtLog.Text += "Patrones cargados con exito\n";
                    txtLog.Text += "_____________________\n";
                }
                
            }

        }

    }
    public class ComboBoxes
    {
        public int indiceDatagridView;
        public int opcion;

    }

}