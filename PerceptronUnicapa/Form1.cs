using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LiveCharts;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.IO;
using Utilidades;
using Newtonsoft.Json;
using System.Threading;
using LiveCharts.Defaults;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using LiveCharts.Wpf;
using System.Threading.Tasks;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;

namespace PerceptronUnicapa
{

    public partial class Form1 : Form
    {
        #region Dlls para poder hacer el movimiento del Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        int w = 0;
        int h = 0;
        #endregion
        private List<ComboBoxes> comboBoxes = new List<ComboBoxes>();
        double[,] matrizEntradas;
        double[,] matrizSalidas;
        int cantidadEntradas, cantidadSalidas, patrones;
        bool redInicializada, redEntrenada;
        public ChartValues<ObservableValue> Errores { get; set; }
        public ChartValues<ObservableValue>[] PuntosReales { get; set; }
        public ChartValues<ObservableValue>[] PuntosDeseados { get; set; }
        RedNeuronal RedNeuronal;
        private const int keepRecords = 20;
        private int VelocidadCharts { get; set; }

        //Creamos el delegado 

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;            
            redInicializada = false;
            redEntrenada = false;
            Errores = new ChartValues<ObservableValue>();            
        }
        private void WriteJSON(object objeto, string path)
        {
            string json = JsonConvert.SerializeObject(objeto);
            File.WriteAllText(path, json);
        }
        private void Plot()
        {
            Errores.Add(new ObservableValue(RedNeuronal.ErrorEntrenamiento));
            for (int i = 0; i < RedNeuronal.SalidasDeseadas.GetLength(0); i++)
            {
                for (int j = 0; j < RedNeuronal.SalidasDeseadas.GetLength(1); j++)
                {

                    PuntosDeseados[j].Add(new ObservableValue(RedNeuronal.SalidasDeseadas[i, j]));
                    PuntosReales[j].Add(new ObservableValue(RedNeuronal.SalidasReales[i, j]));
                    RemoverPuntos(j);
                }
            }            
            Thread.Sleep(VelocidadCharts);
        }

        private void RemoverPuntos(int j)
        {
            var first = PuntosDeseados[j].FirstOrDefault();
            if (PuntosDeseados[j].Count > keepRecords - 1) PuntosDeseados[j].Remove(first);
            var _first = PuntosReales[j].FirstOrDefault();
            if (PuntosReales[j].Count > keepRecords - 1) PuntosReales[j].Remove(_first);
        }

        private void CrearSeriesGrafica()
        {
            PuntosDeseados = new ChartValues<ObservableValue>[matrizSalidas.GetLength(1)];
            PuntosReales = new ChartValues<ObservableValue>[matrizSalidas.GetLength(1)];
            LineSeries[] SerieDeseadas = new LineSeries[matrizSalidas.GetLength(1)];
            LineSeries[] SerieReales = new LineSeries[matrizSalidas.GetLength(1)];
            for (int i = 0; i < matrizSalidas.GetLength(1); i++)
            {
                InicializarSeriesCharts(SerieDeseadas, SerieReales, i);
            }
        }

        private void InicializarSeriesCharts(LineSeries[] SerieDeseadas, LineSeries[] SerieReales, int i)
        {
            PuntosDeseados[i] = new ChartValues<ObservableValue>();
            PuntosReales[i] = new ChartValues<ObservableValue>();
            SerieDeseadas[i] = InicializarSerie(PuntosDeseados[i], "Yd" + (i + 1));
            SerieReales[i] = InicializarSerie(PuntosReales[i], "Yr" + (i + 1));
            CartesianVariacionRealDeseada.Series.Add(SerieDeseadas[i]);
            CartesianVariacionRealDeseada.Series.Add(SerieReales[i]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LineSeries serieErrores = new LineSeries
            {
                Title = "Error de Entrenamiento",
                Values = Errores,
                StrokeThickness = 4,
                Fill = Brushes.Transparent,
                PointGeometry = DefaultGeometries.None,
                PointGeometrySize = 8,
                DataLabels = false,

            };            
            CartesianErrors.Series.Add(serieErrores);
            LlenarDatagridTopologia();
            VelocidadCharts = Convert.ToInt16(numericUpDown1.Value);
            CartesianErrors.LegendLocation = LegendLocation.Top;
            CartesianVariacionRealDeseada.LegendLocation = LegendLocation.Top;
            CartesianVariacionRealDeseada.AnimationsSpeed = TimeSpan.FromMilliseconds(0);
            CartesianVariacionRealDeseada.Background = Brushes.White;
        }
        private void BtnInicializarRed_Click(object sender, EventArgs e)
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
                int[] neuronasPorCapa = new int[Convert.ToInt16(nudNumeroCapas.Value)];
                int numeroActivaciones = Convert.ToInt16(nudNumeroCapas.Value);
                int[] activaciones = new int[numeroActivaciones];
                activaciones[0] = 1;

                TopologiaCapas(neuronasPorCapa, numeroActivaciones, activaciones);
                Random random = new Random();
                RedNeuronal = new RedNeuronal(this.matrizSalidas, Convert.ToDouble(
                    nudErrorMaximo.Value), this.patrones, Convert.ToDouble(
                        this.nudRataAprendizaje.Value), Convert.ToInt16(
                     nudNoIteraciones.Value), this.matrizEntradas, random,
                    activaciones, neuronasPorCapa, Convert.ToDouble(NudRataDinamica.Value),
                    CmbAlgoritmoEntrenamiento.SelectedIndex);
                redInicializada = true;
                txtLog.Text += "Red Inicalizada con exito\n";
                txtLog.Text += "_____________________\n";
                CrearSeriesGrafica();
            }
        }

        private void TopologiaCapas(int[] neuronasPorCapa, int numeroActivaciones, int[] activaciones)
        {
            for (int i = 0; i < numeroActivaciones; i++)
            {
                neuronasPorCapa[i] = Convert.ToInt32(dgvTopologiaRed[1, i].Value);
                activaciones[i] = comboBoxes[i].Opcion;

            }
        }

        private LineSeries InicializarSerie(
            ChartValues<ObservableValue> observables, string title)
        {
            LineSeries Serie = new LineSeries
            {
                Title = title,
                Values = observables,
                StrokeThickness = 4,
                Fill = Brushes.Transparent,
                PointGeometry = DefaultGeometries.None,
                PointGeometrySize = 8,
                DataLabels = false
            };
            return Serie;
        }

        private void BtnEntrenar_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(Entrenar);
        }

        private void Entrenar()
        {
            if (patrones == 0)
            {
                MessageBox.Show("Debe cargar un archivo para continuar con el entrenamiento",
                    "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (redInicializada)
            {

                if (RedNeuronal.ErrorEntrenamiento < RedNeuronal.ErrorMaximo)
                {
                    MessageBox.Show("La red ha entrenado en la iteracion " + RedNeuronal.IteracionesEntrenamiento,
                        "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    RedNeuronal.Entrenar();
                    Plot();                    
                    if (!RedNeuronal.Entrenando)
                    {
                        redEntrenada = true;

                    }

                }

            }
            else
            {
                MessageBox.Show("Debe inicializar la red para continuar con el entrenamiento",
                   "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoverColumnasDataDrid(DataGridView dataGridView)
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
        private void BtnContinuar_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew( Continuar);
        }

        private void Continuar()
        {
            if (patrones == 0)
            {
                MessageBox.Show("Debe cargar un archivo para continuar con el entreamiento",
                    "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (redInicializada)
            {
                while (Aprendio(RedNeuronal))
                {
                    RedNeuronal.Entrenar();
                    
                    Plot();
                }
                if (!RedNeuronal.Entrenada)
                {
                    redEntrenada = true;
                    DialogResult result =
                    MessageBox.Show("\tLa Red Ha entrenado.\n¿Desea guardar " +
                        "pesos y umbrales?", "Informacion", MessageBoxButtons
                        .YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        saveFileDialog1.Filter = "json files (*.json)|*.json";
                        if (saveFileDialog1.ShowDialog() ==
                            DialogResult.OK && saveFileDialog1.FileName.Length
                            > 0)
                        {
                            WriteJSON(RedNeuronal, saveFileDialog1.FileName);
                        }

                    }

                }
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
            else
            {
                MessageBox.Show("Debe inicializar la red para continuar con el entrenamiento",
                   "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private static bool Aprendio(RedNeuronal perceptron)
        {
            return perceptron.Entrenando && perceptron.IteracionesEntrenamiento <=
                                    perceptron.IteracionesRequeridas;
        }

        private void BtnSimular_Click(object sender, EventArgs e)
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
        private void BtnCargarPesosyUmbrales_Click(object sender, EventArgs e)
        {
            if (patrones == 0)
            {
                MessageBox.Show("Debe cargar un archivo para continuar con el entreamiento",
                    "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                System.Windows.Forms.OpenFileDialog d = new OpenFileDialog
                {
                    Title = "Importar archivo (.json)",
                    Filter = "JSON|*.json"
                };
                if (d.ShowDialog() == DialogResult.OK)
                {         
                    
                    using (StreamReader jsonStream = File.OpenText(d.FileName))
                    {
                        var json = jsonStream.ReadToEnd();
                        RedNeuronal perceptronDevuelto = JsonConvert.DeserializeObject<RedNeuronal>(json);
                        RedNeuronal = perceptronDevuelto;
                        redInicializada = true;
                        btnInicializarRed.Enabled = false;
                    }
                }
            }
            
        }

        private void BtnBorrarLog_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
        }
        private void LimpiarDataGrid(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            dataGridView.Refresh();
        }
        private void NudNumeroCapas_ValueChanged(object sender, EventArgs e)
        {
            LlenarDatagridTopologia();
        }

        private void LlenarDatagridTopologia()
        {
            LimpiarDataGrid(dgvTopologiaRed);
            int k = 1;
            for (int i = 0; i < nudNumeroCapas.Value; i++)
            {
                if (i == nudNumeroCapas.Value - 1)
                {
                    dgvTopologiaRed.Rows.Add("Salida",
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

        private void DgvTopologiaRed_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox combo)
            {

                combo.SelectedIndexChanged -= new EventHandler(Combo_SelectedIndexChange);
                combo.SelectedIndexChanged += Combo_SelectedIndexChange;
            }

        }

        private void Combo_SelectedIndexChange(object sender, EventArgs e)
        {
            string selectedIndex = (sender as ComboBox).SelectedIndex.ToString();
            int filaDataGrid = dgvTopologiaRed.CurrentCell.RowIndex;
            ComboBoxes combo =  comboBoxes.Find(x => x.IndiceDatagridView == filaDataGrid);
            if (combo != null)
            {
                combo.Opcion = Convert.ToInt16(selectedIndex);
                //comboBoxes.Add(combo);
            }
            else
            {
                combo = new ComboBoxes
                {
                    IndiceDatagridView = filaDataGrid,
                    Opcion = Convert.ToInt16(selectedIndex)
                };
                comboBoxes.Add(combo);
            }            
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            VelocidadCharts = Convert.ToInt16 (numericUpDown1.Value);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            RedNeuronal = null;
                    
            foreach (var series in CartesianErrors.Series)
            {
                series.Values.Clear();
            }
            foreach (var series in CartesianVariacionRealDeseada.Series)
            {
                series.Values.Clear();
            }                        
            btnInicializarRed.Enabled = true;
            //while (dgvPesosyUmbrales.RowCount > 1)
            //{

            //    dgvPesosyUmbrales.Rows.Remove(dgvPesosyUmbrales.CurrentRow);

            //}
            //while (dgvSimulacion.RowCount > 1)
            //{

            //    dgvSimulacion.Rows.Remove(dgvSimulacion.CurrentRow);
            //}

        }

        private void TabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            //para poder arrastrar el formulario sin bordes

            SendMessage(this.Handle, 0x112, 0xf012, 0);
            w = this.Width;
            h = this.Height;

        }

        private void BtnCargarPatrones_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog
            {
                Title = "Importar archivo (.csv)",
                Filter = "Csv|*.csv"
            };
            List<String> datos = new List<string>();
            if (d.ShowDialog() == DialogResult.OK)
            {
                /// Console.WriteLine(d.FileName);            
                
                StreamReader reader = new StreamReader(d.FileName);

                string line = reader.ReadLine();
                char separador = ';';
                if (!line.Contains(separador))
                {
                    separador = ',';                    
                }
                string[] headers = line.Split(separador);                
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
                    RemoverColumnasDataDrid(dgvPatrones);
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
                    LimpiarDataGrid(dgvPatrones);
                

                    foreach (string patron in datos)
                    {                                                   
                        dgvPatrones.Rows.Add(patron.Split(separador));
                    }
                    for (int i = 0; i < patrones; i++)
                    {
                        string[] linea = datos[i].Split(separador);
                        int k = 0;
                        for (int j = 0; j < salidas+entradas; j++)
                        {
                            if (j<entradas)
                            {
                                this.matrizEntradas[i, j] = Double.Parse(linea[j]);
                            }
                            else
                            {                           
                                this.matrizSalidas[i, k] = Double.Parse(linea[j]);
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
                                        
                    txtLog.Text += "Patrones cargados con exito\n";
                    txtLog.Text += "_____________________\n";
                }
                
            }

        }

    }
    public class ComboBoxes
    {
        public int Opcion { get; set; }
        public int IndiceDatagridView { get; set; }
    }

}