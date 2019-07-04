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

namespace RedesNeuronales
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
        public bool TopologiaCargada { get; private set; }

        //Creamos el delegado 

        public Form1()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            //this.MaximizeBox = false;            
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
            
            dgvPatrones.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPatrones.Dock = DockStyle.Fill;
            CmbAlgoritmoEntrenamiento.SelectedIndex = 1;
            DgvParametrosSimulacion.ClipboardCopyMode =
    DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dgvPatrones.ClipboardCopyMode =
    DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            
        }
        public void pegar_portapapeles(DataGridView datagrid)
        {
            try
            {
                string texto_copiado = Clipboard.GetText();
                string[] lineas = texto_copiado.Split('\n');
                int error = 0;
                int fila = datagrid.CurrentCell.RowIndex;
                int columna = datagrid.CurrentCell.ColumnIndex;
                DataGridViewCell objeto_celda;

                foreach (string linea in lineas)
                {
                    if (fila < datagrid.RowCount && linea.Length > 0)
                    {
                        string[] celdas = linea.Split('\t');

                        for (int indice = 0; indice < celdas.GetLength(0); ++indice)
                        {
                            if (columna + indice < datagrid.ColumnCount)
                            {
                                objeto_celda = datagrid[columna + indice, fila];

                                //Mientras celda sea Diferente de ReadOnly
                                if (!objeto_celda.ReadOnly)
                                {
                                    
                                        objeto_celda.Value = Convert.ChangeType(celdas[indice], objeto_celda.ValueType);
                                        //A continuación la linea añadida para eliminar los '\r'. De paso, y por si acaso en algún contexto ocurre, tambien los: '\t' y '\n'
                                        objeto_celda.Value = objeto_celda.Value.ToString().Trim(new Char[] { '\t', '\n', '\r' });
                                        // Fin linea añadida
                                    
                                }
                                else
                                {
                                    // solo intercepta un error si los datos que está pegando es en una celda de solo lectura.
                                    error++;
                                }
                            }
                            else
                            { break; }
                        }
                        fila++;
                    }
                    else
                    { break; }

                    if (error > 0)
                        MessageBox.Show(string.Format("{0}  La celda no puede ser actualizada, debido a que la configuración de la columna es de solo lectura.", error),
                                                  "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException fexcepcion)
            {
                MessageBox.Show("Los datos que pegó están en el formato incorrecto para la celda." + "\n\nDETALLES: \n\n" + fexcepcion.Message,
                                "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private string VerficarReglasParaInicializacion()
        {
            string mensaje = "";
            if (patrones == 0)
            {
                mensaje = "Debe cargar un archivo para continuar con el entreamiento";
            }
            else if (nudRataAprendizaje.Value <= 0)
            {
                mensaje = "Ingrese una rata de aprendizaje correcta(>0)";
            }
            else if (nudNoIteraciones.Value <= 0)
            {
                mensaje = "Ingrese un numero de iteraciones valido";
            }
            return mensaje;
        }
        private void BtnInicializarRed_Click(object sender, EventArgs e)
        {
            string respuesta = VerficarReglasParaInicializacion();
            if (respuesta != "")
            {
                MessageBox.Show(respuesta,
                    "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int[] neuronasPorCapa = new int[Convert.ToInt16(nudNumeroCapas.Value)];
                int numeroActivaciones = Convert.ToInt16(nudNumeroCapas.Value);
                int[] activaciones = new int[numeroActivaciones];
                activaciones[0] = 1;

                TopologiaCapas(neuronasPorCapa, numeroActivaciones, activaciones);
                if (!TopologiaCargada)
                {
                    RedNeuronal = new RedNeuronal(matrizSalidas, patrones, matrizEntradas
                        , CmbAlgoritmoEntrenamiento.SelectedIndex);
                    Random random = new Random();
                    RedNeuronal.CreaCapas(neuronasPorCapa, random);
                    
                }
                RedNeuronal.ParametrosEntrenaiento(Convert.ToDouble(
                    nudErrorMaximo.Value), Convert.ToDouble(
                        this.nudRataAprendizaje.Value), Convert.ToInt16(
                     nudNoIteraciones.Value), activaciones, Convert.ToDouble(NudRataDinamica.Value));
                redInicializada = true;
                txtLog.Text += "Red Inicalizada con exito\n";
                txtLog.Text += "_____________________\n";
                foreach (var series in CartesianVariacionRealDeseada.Series)
                {
                    series.Values.Clear();
                }
                CartesianVariacionRealDeseada.Series.Clear();
                CrearSeriesGrafica();
            }
        }

        private void TopologiaCapas(int[] neuronasPorCapa, int numeroActivaciones, int[] activaciones)
        {
            for (int i = 0; i < numeroActivaciones; i++)
            {
                neuronasPorCapa[i] = Convert.ToInt32(dgvTopologiaRed[1, i].Value);                
                activaciones[i] = IndiceActivaciones( dgvTopologiaRed.Rows[i].Cells[2].Value.ToString());

            }
        }
        private int IndiceActivaciones(string funcionActivacion)
        {
            int respuesta = 0;
            switch (funcionActivacion)
            {
                case "Sigmoidal": respuesta = 0; break;
                case "Tangente Hiperbolico": respuesta = 1; break;
                case "Escalon": respuesta = 2; break;
                case "Seno": respuesta = 3; break;
                case "Coseno": respuesta = 4; break;
                case "Lineal": respuesta = 5; break;
                case "Gaussiana": respuesta = 6 ; break;
                default:
                    respuesta = 0;
                    break;
            }
            return respuesta;
        }
        private string NombreActivaciones(int indice)
        {
            string respuesta = "Sigmoidal";
            switch (indice)
            {
                case 0: respuesta = "Sigmoidal"; break;
                case 1:respuesta= "Tangente Hiperbolico"; break;
                case 2:respuesta= "Escalon"; break;
                case 3:respuesta= "Seno"; break;
                case 4:respuesta= "Coseno"; break;
                case 5:respuesta= "Lineal"; break;
                case 6:respuesta= "Gaussiana"; break;
                default:
                    respuesta = "Sigmoidal";
                    break;
            }
            return respuesta;
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
                PointGeometry = DefaultGeometries.Triangle,
                PointGeometrySize = 7,
                DataLabels = false
            };
            return Serie;
        }

        private void BtnEntrenar_Click(object sender, EventArgs e)
        {
            EntrenarConPaso();
        }

        private void EntrenarConPaso()
        {
            string mensaje = VerificarReglasDeEntrenamiento();
            if (mensaje != "")
            {
                MessageBox.Show(mensaje,
                    "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (RedNeuronal.ErrorEntrenamiento < RedNeuronal.ErrorMaximo)
                {
                    MessageBox.Show("La red ha entrenado en la iteracion " + RedNeuronal.IteracionesEntrenamiento,
                        "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    GuardarTopologia();
                }
                else
                {
                    RedNeuronal.Entrenar();
                    Plot();
                    LlenarLabels();
                }

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
            Task.Factory.StartNew(Continuar);            
        }

        private void Continuar()
        {
            string mensaje = VerificarReglasDeEntrenamiento();
            if (mensaje != "")
            {
                MessageBox.Show(mensaje,
                    "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
            else 
            {
                FitRedReuronal();
                Invoke(new CallGuardarTopologia( GuardarTopologia));
                RedNeuronal.IteracionesEntrenamiento = 0;
                
            }
            
        }
        private delegate void CallGuardarTopologia();
        private delegate void CallLlenarLabels();
        private void LlenarLabels()
        {
            lblError.Text = "Error Entrenamiento: " + Math.Round( RedNeuronal.ErrorEntrenamiento,9);
            lblIteracion.Text = "Iteracion: " + RedNeuronal.IteracionesEntrenamiento;
        }
        private void FitRedReuronal()
        {
            while (Entrenando())
            {
                Plot();
                RedNeuronal.Entrenar();

                Invoke(new CallLlenarLabels(LlenarLabels));
            }
        }

        private void GuardarTopologia()
        {
            string mensaje = "";
            mensaje = Entreno();
            DialogResult result =
                MessageBox.Show(mensaje, "Informacion", MessageBoxButtons
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

        private string Entreno()
        {
            string mensaje;
            if (!RedNeuronal.Entrenando)
            {
                mensaje = "La Red Ha entrenado.\n¿Desea guardar " +
                    "pesos y umbrales?";
                redEntrenada = true;
            }
            else
            {
                mensaje = "La Red no alcanzo el error de entrenamiento requerido.\n¿Desea guardar " +
                    "pesos y umbrales?";
                redEntrenada = false;
            }

            return mensaje;
        }

        private bool Entrenando()
        {
            return RedNeuronal.ErrorEntrenamiento >= RedNeuronal.ErrorMaximo && RedNeuronal.IteracionesEntrenamiento < RedNeuronal.IteracionesRequeridas;
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
                OpenFileDialog d = new OpenFileDialog
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
                        
                        if (perceptronDevuelto.Entradas.Equals(matrizEntradas)
                            || perceptronDevuelto.SalidasDeseadas.Equals(this.matrizSalidas))
                        {
                            MessageBox.Show("Los patrones no coinciden entre si", "Atencion",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            RedNeuronal = null;
                        }
                        else
                        {
                            RedNeuronal = perceptronDevuelto;
                            nudNumeroCapas.Enabled = false;
                            TopologiaCargada = true;
                            nudErrorMaximo.Value = Convert.ToDecimal(RedNeuronal.ErrorMaximo);
                            NudRataDinamica.Value = Convert.ToDecimal(RedNeuronal.RataDinamica);
                            nudRataAprendizaje.Value = Convert.ToDecimal(RedNeuronal.RataAprendizaje);
                            nudNumeroCapas.Value = Convert.ToDecimal(RedNeuronal.Capas.Count);
                            lblIteracion.Text = "Iteracion: " + RedNeuronal.IteracionesEntrenamiento;
                            lblError.Text = "Error Entrenamiento: " + Math.Round( RedNeuronal.ErrorEntrenamiento,9);
                            ReadOnlyDgvTopologia(true);
                            MessageBox.Show("¡Pesos y umbrales cargados con exito!\nProceda a " +
                                "configurar los parametros de entrenamiento y pulse Inicializar", "Informacion",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }            
        }
        private void ReadOnlyDgvTopologia(bool enable)
        {
            dgvTopologiaRed.Rows.Clear();
            dgvTopologiaRed.RowCount = RedNeuronal.Capas.Count;

            for (int i = 0; i < dgvTopologiaRed.RowCount; i++)
            {                
                for (int j = 0; j < dgvTopologiaRed.ColumnCount ; j++)
                {
                    ConfigurarDgvTopologia(enable, i, j);
                }
            }
        }

        private void ConfigurarDgvTopologia(bool enable, int i, int j)
        {
            if (j == 0)
            {
                if (i == RedNeuronal.Capas.Count -1)
                {
                    dgvTopologiaRed[j, i].Value = "Salida";
                }else
                    dgvTopologiaRed[j, i].Value = "Oculta: " + i;

                dgvTopologiaRed[j,i].ReadOnly = enable;
            }
            else
            {
                if (j == 1)
                {
                    dgvTopologiaRed[j, i].Value = RedNeuronal.Capas[i].Neuronas.Count;
                    dgvTopologiaRed[j, i].ReadOnly = enable;
                }
                else
                {
                    //DataGridViewComboBoxCell dataGridViewComboBoxCell = dgvTopologiaRed[j,i] as DataGridViewComboBoxCell;
                    //dataGridViewComboBoxCell.Value = dataGridViewComboBoxCell.Items[RedNeuronal.Capas[i].FuncionActivacion];

                    dgvTopologiaRed[j, i].Value = NombreActivaciones(RedNeuronal.Capas[i].FuncionActivacion);
                    dgvTopologiaRed[j,i].ReadOnly = false;
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
                dgvTopologiaRed.Rows.Add();
                for (int j = 0; j < dgvTopologiaRed.ColumnCount-1; j++)
                {
                    if (i == nudNumeroCapas.Value - 1)
                    {
                        if (j==0)
                        {
                            dgvTopologiaRed[j, i].Value = "Salida";
                        }
                        else
                        {
                            if (j==1)
                            {
                                dgvTopologiaRed[j, i].Value = cantidadSalidas;
                                dgvTopologiaRed[j, i].ReadOnly = true;
                            }
                        }                        
                    }
                    else
                    {
                        if (j == 0)
                        {
                            dgvTopologiaRed[j, i].Value = "Oculta " + i;
                        }
                        else
                        {
                            if (j == 1)
                            {
                                dgvTopologiaRed[j, i].Value = 1;                                
                            }
                        }
                    }
                }

            }
        }

        private void DgvTopologiaRed_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (e.Control is ComboBox combo)
            //{

            //    combo.SelectedIndexChanged -= new EventHandler(Combo_SelectedIndexChange);
            //    combo.SelectedIndexChanged += Combo_SelectedIndexChange;
            //}

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
            CartesianVariacionRealDeseada.Series.Clear();
            btnInicializarRed.Enabled = true;
            dgvTopologiaRed.Enabled = true;
            nudNumeroCapas.Enabled = true;
            redEntrenada = false;
            redInicializada = false;
            TopologiaCargada = false;
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
            if (d.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(d.FileName);

                string line = reader.ReadLine();
                char separador = ';';
                separador = SeparadorCSV(line, separador);
                string[] headers = line.Split(separador);
                int entradas, salidas;
                ContarEntradasSalidas(headers, out entradas, out salidas);
                if (entradas == 0)
                {
                    MessageBox.Show("El archivo de patrones debe contener una secuncia" +
                        " de entradas(x) y salidas(y), el presente archivo no sigue estas reglas" +
                        " intente cargar otro nuevamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    RemoverColumnasDataDrid(dgvPatrones);
                    List<string> datos = ExtraerListaPatrones(reader, ref line);
                    InicializarMatricez(datos, headers, entradas, salidas);
                    LimpiarDataGrid(dgvPatrones);
                    LlenarMatricesPatrones(datos, separador, entradas, salidas);
                    txtLog.Text += "Patrones cargados con exito\n";
                    txtLog.Text += "_____________________\n";
                    LlenarDatagridTopologia();
                }

            }

        }

        private static List<string> ExtraerListaPatrones(StreamReader reader, ref string line)
        {
            List<String> datos = new List<string>();
            while (line != null)
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    datos.Add(line);
                }
            }
            reader.Close();
            return datos;
        }

        private void LlenarMatricesPatrones(List<string> datos, char separador, int entradas, int salidas)
        {
            for (int i = 0; i < patrones; i++)
            {
                string[] linea = datos[i].Split(separador);
                int k = 0;
                dgvPatrones.Rows.Add(linea);
                for (int j = 0; j < salidas + entradas; j++)
                {
                    if (j < entradas)
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
            dgvPatrones.AutoResizeColumns();
        }

        private void BtnSimular_Click_1(object sender, EventArgs e)
        {
            string mensaje = VerificarReglasDeEntrenamiento();
            if (mensaje != "")
            {
                MessageBox.Show(mensaje,
                    "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            else
            {
                SimularPatrones();
            }
        }

        private void SimularPatrones()
        {
            double[] patronEntrada = new double[cantidadEntradas];
            
            for (int i = 0; i < DgvParametrosSimulacion.RowCount-1; i++)
            {
                for (int j = 0; j < DgvParametrosSimulacion.ColumnCount-cantidadSalidas; j++)
                {
                    patronEntrada[j] = Convert.ToDouble(DgvParametrosSimulacion[j, i].Value);
                }
                double[] patronSalida = RedNeuronal.SimularRed(patronEntrada);
                int l = 0;
                for (int k = (DgvParametrosSimulacion.ColumnCount - cantidadSalidas); k < DgvParametrosSimulacion.ColumnCount; k++)
                {
                    DgvParametrosSimulacion[k, i].Value = patronSalida[l];
                    l++;
                }
            }
        }       

        private string VerificarReglasDeEntrenamiento()
        {
            string mensaje = "";
            if (patrones == 0)
            {
                mensaje = "Debe cargar un archivo para continuar con el entreamiento";                
            }
            else if (!redInicializada)
            {
                mensaje = "Debe inicializar la red para continuar con el entrenamiento";
            }            
            return mensaje;
        }

        private void DgvParametrosSimulacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                pegar_portapapeles(DgvParametrosSimulacion);
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void BtnDetener_Click(object sender, EventArgs e)
        {
            try
            {

                Thread.CurrentThread.Abort();
            }
            catch (Exception)
            {
                GuardarTopologia();
            }
        }

        private void InicializarMatricez(List<string> datos, string[] headers, int entradas, int salidas)
        {
            dgvPatrones.ColumnCount = headers.Length;
            DgvParametrosSimulacion.ColumnCount = headers.Length; 
            for (int i = 0; i < headers.Length; i++)
            {
                DgvParametrosSimulacion.Columns[i].Name = headers[i];
                dgvPatrones.Columns[i].Name = headers[i];
            }
            this.patrones = datos.Count;
            this.cantidadSalidas = salidas;
            this.cantidadEntradas = entradas;
            this.matrizEntradas = new double[patrones, cantidadEntradas];
            this.matrizSalidas = new double[patrones, cantidadSalidas];
            lblEntradas.Text = "Entradas: " + entradas;
            lblSalidas.Text = "Salidas: " + salidas;
            lblPatrones.Text = "Patrones: " + patrones;
        }

        private static char SeparadorCSV(string line, char separador)
        {
            if (!line.Contains(separador))
            {
                separador = ',';
            }

            return separador;
        }

        private static void ContarEntradasSalidas(string[] headers, out int entradas, out int salidas)
        {
            entradas = 0;
            salidas = 0;
            for (int i = 0; i < headers.Length; i++)
            {
                if (headers[i].Contains("x"))
                {
                    entradas++;
                }
                else
                    salidas++;
            }
        }
    }
    public class ComboBoxes
    {
        public int Opcion { get; set; }
        public int IndiceDatagridView { get; set; }
    }

}