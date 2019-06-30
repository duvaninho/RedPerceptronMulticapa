using System;
using System.Collections.Generic;

namespace Utilidades
{
    public class RedNeuronal
    {
        public double[,] SalidasDeseadas { get; set; }
        public double[,] SalidasReales { get; set; }
        public double[,] Entradas { get; set; }

        public double[] MayoresEntradas { get; set; }
        public double[] MayoresSalidas { get; set; }
        public double RataDinamica { get; set; }
        public int AlgoritmoEntrenamiento { get; set; } //0 Regla Delta, 1 Backpropagation
        public double ErrorMaximo { get; set; }
        public double ErrorEntrenamiento { get; set; } = 5;
        public double RataAprendizaje { get; set; } = 0.0;
        public int Patrones { get; set; }
        public int IteracionesEntrenamiento { get; set; }
        public int IteracionesRequeridas { get; set; }
        public int CantidadEntradas { get; set; }
        public int CantidadSalidas { get; set; }
        public int[] FuncionActivacion { get; set; }
        public bool Entrenando { get; set; }
        public List<Capa> Capas { get; set; }
        public bool Entrenada { get; set; }
        public double[] variacionRealDeseada { get; set; }
        public double[] ErroresLinealUltimaCapa { get; set; }

        public RedNeuronal() { }
        public RedNeuronal(double[,] salidasDeseadas, double errorMaximo, int patrones,
            double rataAprendizaje, int iteracionesRequeridas, double[,] entradas,
            Random random, int[] funcionActivacion,int[] neuronasPorCapa, double rataDinamica = 0,
            int BackPropagation=0)
        {
            if (ErrorEntrenamiento > errorMaximo)
            {
                Entrenando = true;
            }
            this.Patrones = patrones;
            CantidadEntradas = entradas.GetLength(1);
            CantidadSalidas = salidasDeseadas.GetLength(1);
            MapEntradas(entradas);
            MapSalidasDeseadas(salidasDeseadas);            
            this.ErrorMaximo = errorMaximo;
            this.RataAprendizaje = rataAprendizaje;
            this.IteracionesRequeridas = iteracionesRequeridas;
            this.FuncionActivacion = funcionActivacion;
            CreaCapas(this.Entradas.GetLength(1), neuronasPorCapa, random);
            ErroresLinealUltimaCapa = new double[CantidadSalidas];
            this.RataDinamica = rataDinamica;
            MayoresEntradas = new double[Entradas.GetLength(1)];
            MayoresSalidas = new double[SalidasDeseadas.GetLength(1)];
            NormalizarPatrones();
            AlgoritmoEntrenamiento = BackPropagation;
            variacionRealDeseada = new double[CantidadSalidas * 2];
        }
        private void MapSalidasDeseadas(double[,] salidasDeseadas)
        {
            this.SalidasDeseadas = salidasDeseadas;
            SalidasReales = new double[salidasDeseadas.GetLength(0), salidasDeseadas.GetLength(1)];
        }
        private void MapEntradas(double[,] entradas)
        {
            this.Entradas = entradas;            
        }
        private void NormalizarPatrones()
        {
            BuscarMayores();
            for (int i = 0; i < Entradas.GetLength(0); i++)
            {
                for (int j = 0; j < Entradas.GetLength(1); j++)
                {
                    Entradas[i, j] /= MayoresEntradas[j];
                }
            }
            for (int i = 0; i < SalidasDeseadas.GetLength(0); i++)
            {
                for (int j = 0; j < SalidasDeseadas.GetLength(1); j++)
                {
                    SalidasDeseadas[i, j] /= MayoresSalidas[j];
                }
            }
        }
        private void BuscarMayores()
        {            
            for (int i = 0; i < Entradas.GetLength(0); i++)
            {
                for (int j = 0; j < Entradas.GetLength(1); j++)
                {
                    if (Entradas[i,j] > MayoresEntradas[j])
                    {
                        MayoresEntradas[j] = Entradas[i, j];
                    } 
                }
            }
            for (int i = 0; i < SalidasDeseadas.GetLength(0); i++)
            {
                for (int j = 0; j < SalidasDeseadas.GetLength(1); j++)
                {
                    if (SalidasDeseadas[i, j] > MayoresSalidas[j])
                    {
                        MayoresSalidas[j] = SalidasDeseadas[i, j];
                    }
                }
            }
        }
        public void Entrenar()
        {
            Entrenando = true;
            IteracionesEntrenamiento += 1;
            Console.WriteLine("Iteracion: " + IteracionesEntrenamiento);
            ErrorEntrenamiento = 0;
            for (int i = 0; i < Patrones; i++)
            {
                double errorPorPatron = 0.0;                
                Console.WriteLine("============================ Capa 0 ============================ ");
                double[] patronDeEntrenamiento = ObtenerPatron(i);
                Capas[0].CalculaCapa(patronDeEntrenamiento);
                for (int j = 1; j < Capas.Count; j++)
                {
                    Console.WriteLine("============================ Capa " + (j).ToString() + " ============================ ");
                    Capas[j].CalculaCapa(Capas[j - 1].Salidas);                                        
                }
                int ultimaCapa = Capas.Count - 1;
                errorPorPatron = GetErrorPatron(Capas[ultimaCapa].Salidas, i);
                //variacionRealDeseada[i] = Capas[ultimaCapa].Salidas[i];
                errorPorPatron /= CantidadSalidas;
                Console.WriteLine("Error Por Patron: " + errorPorPatron);
                ErrorEntrenamiento += errorPorPatron;
                if (AlgoritmoEntrenamiento == 1)
                {
                    CalcularErroresNoLineales();                    
                }
                ActulizarPesosUmbrales(errorPorPatron, patronDeEntrenamiento);
            }
            ErrorEntrenamiento /= Patrones;
            RataDinamica /= IteracionesEntrenamiento;
            //for(int i = 0;i < patrones; i++)
            Console.WriteLine("Error de Entrenamiento: " + ErrorEntrenamiento);
            //Prueba con error Entrenamiento
            if (ErrorEntrenamiento < ErrorMaximo)
                Entrenando = false;
        }
        private double GetErrorPatron(double[] salidasDeCapa,int indicePatron)
        {
            double errorPatron = 0.0;
            for (int i = 0; i < salidasDeCapa.Length; i++)
            {
                ErroresLinealUltimaCapa[i] = -salidasDeCapa[i] + SalidasDeseadas[indicePatron, i];
                SalidasReales[indicePatron, i] = salidasDeCapa[i];
                Console.WriteLine("Error Lienal[" + i + "]: " + ErroresLinealUltimaCapa[i]);
                errorPatron += Math.Abs(ErroresLinealUltimaCapa[i]);
            }
            Capas[Capas.Count - 1].ErroresLineales = ErroresLinealUltimaCapa;
            return errorPatron;
        }
        private void ActulizarPesosUmbrales(double errorPatron, double[] patronDeEntrenamiento)
        {               
            if (Capas.Count == 1)
            {
                Capas[0].ModificarPesos(patronDeEntrenamiento, RataAprendizaje, errorPatron, RataDinamica,AlgoritmoEntrenamiento);
            }
            else
            {
                //Primera capa se le pasa patrones de entreamiento
                Capas[0].ModificarPesos(patronDeEntrenamiento, RataAprendizaje, errorPatron, RataDinamica,AlgoritmoEntrenamiento);
                for (int i = 1; i < Capas.Count; i++)
                {                                    
                    Capas[i].ModificarPesos(Capas[i - 1].Salidas, RataAprendizaje, errorPatron, RataDinamica,AlgoritmoEntrenamiento);                                                            
                }
            }
        }

        public double[] ObtenerPatron(int indice)
        {
            double[] vector = new double[CantidadEntradas];
            for (int i = 0; i < Entradas.GetLength(1); i++)
            {
                vector[i] = Entradas[indice,i];
            }
            return vector;
        }

        //public double[] SimularRed(double[] patron)
        //{
        //    double[] salidaSimulada = new double[this.cantidadSalidas];
        //    int i = 0;
        //    foreach (var neurona in )
        //    {
        //        neurona.CalcularSalida(patron, 1,
        //                this.rataAprendizaje, this.entrenando, this.funcionActivacion);
        //        salidaSimulada[i] = neurona.salidaNeurona;
        //        i++;
        //    }
        //    return salidaSimulada;
        //}
        public void CreaCapas(int totalEntradasExternas, int[] NeuronasPorCapa, Random azar)
        {
            Capas = new List<Capa>();            
            for (int i = 0; i < NeuronasPorCapa.Length; i++)      
                if(i == 0 && i == (NeuronasPorCapa.Length - 1))
                    Capas.Add(new Capa(NeuronasPorCapa[i], Entradas.GetLength(1),
                        azar,2,FuncionActivacion[i]));
                else if(i==0)
                    Capas.Add(new Capa(NeuronasPorCapa[i], Entradas.GetLength(1),
                        azar, 1, FuncionActivacion[i]));
                else if(i == (NeuronasPorCapa.Length-1))
                    Capas.Add(new Capa(NeuronasPorCapa[i], NeuronasPorCapa[i - 1],
                        azar, 2, FuncionActivacion[i]));
                else
                    Capas.Add(new Capa(NeuronasPorCapa[i], NeuronasPorCapa[i - 1],
                        azar,1, FuncionActivacion[i]));
        }

        /////Metodos y funciones para la BackPropagation
        private void CalcularErroresNoLineales()
        {                                  
            Capas[Capas.Count - 2].CalcularErroresNoLineales(Capas[Capas.Count-1].MatrizPesos,
                Capas[Capas.Count - 1].ErroresLineales);
            for (int i = Capas.Count -3; i >= 0; i--)
            {
                Capas[i].CalcularErroresNoLineales(Capas[i + 1].MatrizPesos, Capas[i + 1].ErroresNoLineales);
            }
        }
    }

}
