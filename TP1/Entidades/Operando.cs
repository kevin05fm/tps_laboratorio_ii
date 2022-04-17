using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        public Operando()
        {
            Numero = "0";
        }

        public Operando(double numero) : this()
        {
            Numero = numero.ToString();
        }

        public Operando(string strNumero) : this()
        {
            Numero = strNumero;
        }

        /// <summary>
        /// valida que lo ingresado por argumento sea un numero
        /// </summary>
        /// <param name="stringNumero"></param>
        /// <returns></returns>

        private double ValidarOperando(string stringNumero)
        {
            double aux;
            double resultadoDouble = 0;
            if (double.TryParse(stringNumero, out aux))
            {
                resultadoDouble = aux;
            }

            return resultadoDouble;

        }

        /// <summary>
        /// recorre string de argumento y valida si es binario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>

        private static bool EsBinario(string binario)
        {
            bool aux = true;
            int i;

            for (i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    aux = false;
                }
            }
            return aux;
        }

        /// <summary>
        /// Modifica el numero ingresado de binario a decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public static string BinarioDecimal(string binario)
        {

            int acumulador = 0;
            string retorno = "Valor invalido";
            int i;

            if (EsBinario(binario) == true)
            {
                char[] array = binario.ToCharArray();
                Array.Reverse(array);

                for (i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        acumulador += (int)Math.Pow(2, i);
                    }
                }

                retorno = acumulador.ToString();
            }
            
            return retorno;
        }

        /// <summary>
        /// Modifica el numero ingresado double de decimal a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            string retorno = "Valor invalido ";

            if (numero >= 0)
            {
                string cadena = "";

                do
                {
                    if (numero % 2 == 0)
                    {
                        cadena = "0" + cadena;
                    }
                    else
                    {
                        cadena = "1" + cadena;
                    }
                    numero = (int)(numero / 2); // para que no quede un bucle infinito

                } while (numero > 0);

                retorno = cadena;
            }

            return retorno;
        }

        /// <summary>
        /// Modifica el numero ingresado string de decimal a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(string numero)
        {
            double aux;
            string retorno = "Valor invalido ";
            if( numero != null)
            {
                if (double.TryParse(numero, out aux))
                {
                    retorno = DecimalBinario(aux);

                }
            }

            return retorno;
        }

        /// <summary>
        /// Resta dos atributos numero de la clase Operando
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Operando n1, Operando n2)
        {
            double resta;
            resta = n1.numero - n2.numero;
            return resta;
        }

        /// <summary>
        /// Suma dos atributos numero de la clase Operando
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Operando n1, Operando n2)
        {
            double suma;
            suma = n1.numero + n2.numero;
            return suma;
        }

        /// <summary>
        /// Multiplica dos atributos numero de la clase Operando
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Operando n1, Operando n2)
        {
            double multiplo;
            multiplo = n1.numero * n2.numero;
            return multiplo;
        }
        /// <summary>
        /// Divide dos atributos numero de la clase Operando y si el segundo numero es 0 se le asiga valor MinValue
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Operando n1, Operando n2)
        {
            double division;
            if (n2.numero == 0)
            {
                division = double.MinValue;
            }
            else
            {
                division = n1.numero / n2.numero;
            }

            return division;
        }
    }
}
