using System;
using System.Collections.Generic;

namespace Utilidades
{
    public class Perceptron
    {
        public double[,] SalidasDeseadas { get; set; }
        public double[,] Entradas { get; set; }
        public double errorMaximo = 0.0,
            errorEntrenamiento = 5, rataAprendizaje = 0.0;
        public int patrones = 0, iteracionesEntrenamiento = 0,
            iteracionesRequeridas, cantidadEntradas, cantidadSalidas;
        public int[] funcionActivacion;
        public List<Capa> capas;        
        public bool entrenando, entrenada;
        public double[] MayoresEntradas { get; set; }
        public double[] MayoresSalidas { get; set; }
        private readonly double[] erroresLinealUltimaCapa;
        public double RataDinamica { get; set; }
        public int AlgoritmoEntrenamiento { get; set; } //0 Regla Delta, 1 Backpropagation
        public Perceptron() { }
        public Perceptron(double[,] salidasDeseadas, double errorMaximo, int patrones,
            double rataAprendizaje, int iteracionesRequeridas, double[,] entradas,
            Random random, int[] funcionActivacion,int[] neuronasPorCapa, double rataDinamica = 0,
            int BackPropagation=0)
        {
            if (errorEntrenamiento > errorMaximo)
            {
                entrenando = true;
            }
            this.patrones = patrones;
            cantidadEntradas = entradas.GetLength(1);
            cantidadSalidas = salidasDeseadas.GetLength(1);
            MapEntradas(entradas);
            MapSalidasDeseadas(salidasDeseadas);
            this.errorMaximo = errorMaximo;
            this.rataAprendizaje = rataAprendizaje;
            this.iteracionesRequeridas = iteracionesRequeridas;
            this.funcionActivacion = funcionActivacion;
            creaCapas(this.Entradas.GetLength(1), neuronasPorCapa, random);
            erroresLinealUltimaCapa = new double[cantidadSalidas];
            this.RataDinamica = rataDinamica;
            MayoresEntradas = new double[Entradas.GetLength(1)];
            MayoresSalidas = new double[SalidasDeseadas.GetLength(1)];
            NormalizarPatrones();
            AlgoritmoEntrenamiento = BackPropagation;
        }
        private void MapSalidasDeseadas(double[,] salidasDeseadas)
        {
            this.SalidasDeseadas = salidasDeseadas;            
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
            entrenando = true;
            iteracionesEntrenamiento += 1;
            Console.WriteLine("Iteracion: " + iteracionesEntrenamiento);
            errorEntrenamiento = 0;
            for (int i = 0; i < patrones; i++)
            {
                double errorPorPatron = 0.0;                
                Console.WriteLine("============================ Capa 0 ============================ ");
                double[] patronDeEntrenamiento = ObtenerPatron(i);
                capas[0].CalculaCapa(patronDeEntrenamiento);
                for (int j = 1; j < capas.Count; j++)
                {
                    Console.WriteLine("============================ Capa " + (j).ToString() + " ============================ ");
                    capas[j].CalculaCapa(capas[j - 1].Salidas);                                        
                }
                int ultimaCapa = capas.Count - 1;
                errorPorPatron = GetErrorPatron(capas[ultimaCapa].Salidas, i);
                errorPorPatron /= cantidadSalidas;
                Console.WriteLine("Error Por Patron: " + errorPorPatron);
                errorEntrenamiento += errorPorPatron;
                if (AlgoritmoEntrenamiento == 1)
                {
                    CalcularErroresNoLineales();                    
                }
                ActulizarPesosUmbrales(errorPorPatron, patronDeEntrenamiento);
            }
            errorEntrenamiento /= patrones;
            RataDinamica /= iteracionesEntrenamiento;
            //for(int i = 0;i < patrones; i++)
            Console.WriteLine("Error de Entrenamiento: " + errorEntrenamiento);
            //Prueba con error Entrenamiento
            if (errorEntrenamiento < errorMaximo)
                entrenando = false;
        }
        private double GetErrorPatron(double[] salidasDeCapa,int indicePatron)
        {
            double errorPatron = 0.0;
            for (int i = 0; i < salidasDeCapa.Length; i++)
            {
                erroresLinealUltimaCapa[i] = -salidasDeCapa[i] + SalidasDeseadas[indicePatron, i];
                Console.WriteLine("Error Lienal[" + i + "]: " + erroresLinealUltimaCapa[i]);
                errorPatron += Math.Abs(erroresLinealUltimaCapa[i]);
            }
            capas[capas.Count - 1].ErroresLineales = erroresLinealUltimaCapa;
            return errorPatron;
        }
        private void ActulizarPesosUmbrales(double errorPatron, double[] patronDeEntrenamiento)
        {               
            if (capas.Count == 1)
            {
                capas[0].ModificarPesos(patronDeEntrenamiento, rataAprendizaje, errorPatron, RataDinamica,AlgoritmoEntrenamiento);
            }
            else
            {
                capas[0].ModificarPesos(patronDeEntrenamiento, rataAprendizaje, errorPatron, RataDinamica,AlgoritmoEntrenamiento);
                for (int i = 1; i < capas.Count; i++)
                {                                    
                    capas[i].ModificarPesos(capas[i - 1].Salidas, rataAprendizaje, errorPatron, RataDinamica,AlgoritmoEntrenamiento);                                                            
                }
            }
        }

        public double[] ObtenerPatron(int indice)
        {
            double[] vector = new double[cantidadEntradas];
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
        public void creaCapas(int totalEntradasExternas, int[] NeuronasPorCapa, Random azar)
        {
            capas = new List<Capa>();            
            for (int i = 0; i < NeuronasPorCapa.Length; i++)      
                if(i == 0 && i == (NeuronasPorCapa.Length - 1))
                    capas.Add(new Capa(NeuronasPorCapa[i], Entradas.GetLength(1),
                        azar,2,funcionActivacion[i]));
                else if(i==0)
                    capas.Add(new Capa(NeuronasPorCapa[i], Entradas.GetLength(1),
                        azar, 1, funcionActivacion[i]));
                else if(i == (NeuronasPorCapa.Length-1))
                    capas.Add(new Capa(NeuronasPorCapa[i], NeuronasPorCapa[i - 1],
                        azar, 2, funcionActivacion[i]));
                else
                    capas.Add(new Capa(NeuronasPorCapa[i], NeuronasPorCapa[i - 1],
                        azar,1, funcionActivacion[i]));
        }

        /////Metodos y funciones para la BackPropagation
        private void CalcularErroresNoLineales()
        {
            
                      
            capas[capas.Count - 2].CalcularErroresNoLineales(capas[capas.Count-1].MatrizPesos,
                capas[capas.Count - 1].ErroresLineales);
            for (int i = capas.Count -3; i >= 0; i--)
            {
                capas[i].CalcularErroresNoLineales(capas[i + 1].MatrizPesos, capas[i + 1].ErroresNoLineales);
            }
        }
    }

}
