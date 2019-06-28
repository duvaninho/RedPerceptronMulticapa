using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilidades
{
    public class Neurona
    {
        public double Umbral { get; set; }       
        public double SalidaNeurona { get; set; }

        public double[] PesosActuales { get; set; }
        public double UmbralActual { get; set; }
        public double ErrorLineal { get; set; }
        public double[] PesosAnteriores { get; set; }
        public double UmbralAnterior { get; set; }
        private readonly int x0 = 1;
        private double SalidaNeuronaDerivada { get; set; }

        public double[] Pesos { get; set; }

        public Neurona() { }
        public Neurona(Random random, int conexionesEntrada)
        {
            Pesos = new double[conexionesEntrada];
            PesosActuales = (new double[conexionesEntrada]);
            PesosAnteriores = new double[conexionesEntrada];
            for (int i = 0; i < Pesos.Length; i++)
            {
                Pesos[i] = random.NextDouble() * 2 - 1;                
                PesosAnteriores[i] = 0;
            }
            Umbral = 1;
            UmbralActual = Umbral;
            UmbralAnterior = 0;
        }
        public double CalcularSalida(double[] entradas, 
            double salidaDeseada, int funcionActivacion)
        {
            double valor = CalcularSoma(entradas);                        


            if (funcionActivacion == 0)
            {
                Escalon(valor);
            }
            else if (funcionActivacion == 1)
                Sigmoide(valor);
            else
                TangenteHipervolico(valor);
            ErrorLineal = SalidaNeurona - salidaDeseada;
            return SalidaNeurona;
        }
        public double CalcularSalida(double[] entradas, double funcionActivacion)
        {

            double valor = CalcularSoma(entradas);
            Activar(funcionActivacion, valor);
            return SalidaNeurona;
        }

        private void Activar(double funcionActivacion, double valor)
        {
            switch (funcionActivacion)
            {
                case 0: Sigmoide(valor); break;
                case 1: TangenteHipervolico(valor); break;
                case 2: Escalon(valor); break;
                case 3: BiPolar(valor); break;
                default:
                    Sigmoide(valor);
                    break;
            }
        }

        private double CalcularSoma(double[] entradas)
        {
            double valor = 0.0;            
            ImprimePesosUmbral();
            for (int i = 0; i < Pesos.Length; i++)
            {
                valor += entradas[i] * Pesos[i];
            }
            valor += Umbral;
            return valor;
        }
        private void Escalon(double valor)
        {
            SalidaNeurona = valor > 0 ? 1 : 0;
            SalidaNeuronaDerivada = 1;
        }
        private void BiPolar(double valor)
        {
            SalidaNeurona = valor > 0 ? 1 : -1;
            SalidaNeuronaDerivada = 1;
        }
        private void Sigmoide(double valor)
        {
            SalidaNeurona = 1 / (1 + Math.Exp(-valor));
            SalidaNeuronaDerivada = Math.Exp(-valor) / Math.Pow(1 + Math.Exp(-valor), 2);
        }
        private void TangenteHipervolico(double valor)
        {
            SalidaNeurona = Math.Tanh(valor);
            SalidaNeuronaDerivada = 1/Math.Pow(Math.Cosh(valor), 2);
        }
        public void ImprimePesosUmbral()
        {
            Console.WriteLine("\nPesos: ");
            for (int cont = 0; cont < Pesos.Length; cont++) Console.Write("{0:F4}; ", Pesos[cont]);
            Console.WriteLine(" Umbral: {0:F4}", Umbral);
        }
        public void ModificarPesos(double[] entradas, double rataAprendizaje,
            double error, double rataDinamica = 0, int backPropagation = 0,
            int capaSalida = 0)
        {//Error puede ser por patron lineal o noo lineal dependiendo la capay el tipo de entrenamiento
            int cancelarDelta = 1;
            if (backPropagation == 1) cancelarDelta = 0;
            if (capaSalida == 2) SalidaNeuronaDerivada = 1;
            GuardarPesosActuales();
            for (int i = 0; i < Pesos.Length; i++)
            {
                Pesos[i] = PesosActuales[i] + error * rataAprendizaje * entradas[i] * cancelarDelta
                    + rataDinamica * (PesosActuales[i] - PesosAnteriores[i]) +
                    backPropagation * 2 * rataAprendizaje * error
                    * SalidaNeuronaDerivada * entradas[i];

            }
            Umbral = UmbralActual + rataAprendizaje * error * x0 * cancelarDelta +
                rataDinamica * (UmbralActual - UmbralAnterior) +
                backPropagation * 2 * rataAprendizaje * error * SalidaNeuronaDerivada;
            GuardarPesosAnteriores();

            //Formula PesoNuevo = pesoActual + rataAprendizaje  entradas[i]
            //+rataDinamica * (PesosActuales[i] - PesosAnteriores[i])
        }

        private void GuardarPesosActuales()
        {
            for (int i = 0; i < Pesos.Length; i++)
            {
                PesosActuales[i] = Pesos[i];
            }
            UmbralActual = Umbral;
        }

        private void GuardarPesosAnteriores()
        {
            for (int i = 0; i < Pesos.Length; i++)
            {
                PesosAnteriores[i] = PesosActuales[i];
                PesosActuales[i] = Pesos[i];
            }
            UmbralAnterior = UmbralActual;
            UmbralActual = Umbral;
        }
    }
}
