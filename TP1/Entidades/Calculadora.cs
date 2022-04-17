using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida que el operador ingresado sea correcto en caso contrario se le asigna +
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static char ValidarOperador(char operador)
        {
            char aux = '+';
            if( operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                aux = operador;
            }

            return aux;
        }

        /// <summary>
        /// Realiza el calculo de dos numeros segun el operador indicado
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double retorno = 0;

            switch (ValidarOperador(operador))
            {
                case '+':
                    retorno = num1 + num2;
                    break;
                case '-':
                    retorno = num1 - num2;
                    break;
                case '*':
                    retorno = num1 * num2;
                    break;
                case '/':
                    retorno = num1 / num2;
                    break;
            }

            return retorno;
        }

    }
}
