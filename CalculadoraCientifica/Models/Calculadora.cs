﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MathNet.Numerics;
using MathNet.Numerics.Distributions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CalculadoraCientifica.Models
{
    internal class Calculadora
    {
        // Método para resolver una operación simple (dos números y un operador)
        internal static decimal ResolverOperacion(string operacion)
        {

            if (operacion[operacion.Length - 1] == '+' || operacion[operacion.Length - 1] == '-' || operacion[operacion.Length - 1] == '*' || operacion[operacion.Length - 1] == '/')
            {
                operacion = operacion + '0';
            }

            List<string> expresiones = ObtenerExpresiones(operacion);
            List<char> operadores = ObtenerOperadores(operacion);

            // Calcular el resultado si existen expresiones y operadores
            return Calcular(expresiones, operadores);
        }

        public static decimal Calcular(List<string> expresiones, List<char> operadores)
        {
            // Convertir todas las expresiones a números decimales
            List<decimal> numeros = expresiones.Select(exp => decimal.Parse(exp)).ToList();

            // Primer paso: manejar multiplicaciones y divisiones
            for (int i = 0; i < operadores.Count; i++)
            {
                if (operadores[i] == '*' || operadores[i] == '/')
                {
                    decimal resultado;

                    if (operadores[i] == '*')
                        resultado = numeros[i] * numeros[i + 1];
                    else
                    {
                        if (numeros[i + 1] == 0)
                            MessageBox.Show("No se puede hacer una división por cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        resultado = numeros[i] / numeros[i + 1];
                    }

                    // Almacenar el resultado y eliminar el siguiente número
                    numeros[i] = resultado;
                    numeros.RemoveAt(i + 1);
                    operadores.RemoveAt(i);
                    i--; // Ajustar índice después de la eliminación

                }
            }

            // Segundo paso: manejar sumas y restas
            decimal total = numeros[0];
            for (int i = 0; i < operadores.Count; i++)
            {
                try
                {
                    if (operadores[i] == '+')
                        total += numeros[i + 1];
                    else if (operadores[i] == '-')
                        total -= numeros[i + 1];
                    else
                        MessageBox.Show($"Operador no válido: {operadores[i]}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    return -total;
                }

            }
            return total;
        }

        internal static List<string> ObtenerExpresiones(string expresion)
        {
            MatchCollection matches = Regex.Matches(expresion, @"(?<!\d)(-?\d+(,\d+)?)");
            List<string> expresiones = new List<string>();

            foreach (Match match in matches)
            {
                expresiones.Add(match.Value);
            }

            return expresiones;
        }

        internal static List<char> ObtenerOperadores(string entrada)
        {
            List<char> operadores = new List<char>();

            for (int i = 0; i < entrada.Length; i++)
            {
                // Revisamos si el carácter actual es un operador
                if (entrada[i] == '+' ||
                    entrada[i] == '*' ||
                    entrada[i] == '/' ||
                    entrada[i] == '-' && i != 0 && char.IsDigit(entrada[i - 1]))
                {
                    operadores.Add(entrada[i]); // Agregar el operador a la lista
                }
            }
            return operadores;
        }
        internal static string CorregirParentesis(string expresion)
        {
            // Elimina los espacios al final de la expresión
            expresion = expresion.TrimEnd();

            // Verifica si el último carácter es un dígito
            if (expresion.Length > 0 && char.IsDigit(expresion[expresion.Length - 1]))
            {
                // Cuenta los paréntesis abiertos y cerrados en la expresión
                MatchCollection openParentheses = Regex.Matches(expresion, @"\(");
                MatchCollection closeParentheses = Regex.Matches(expresion, @"\)");

                // Calcula la cantidad de paréntesis de cierre que faltan
                int closeParenthesesRequired = openParentheses.Count - closeParentheses.Count;

                // Si faltan paréntesis de cierre, los agrega al final
                if (closeParenthesesRequired > 0)
                {
                    for (int i = 0; i < closeParenthesesRequired; i++)
                    {
                        expresion += ")";
                    }
                }
            }

            // Retorna la expresión corregida
            return expresion;
        }

        // Agrega paréntesis de cierre si falta alguno al final
        internal static string BuscarParentesis(string operacion)
        {

            // Método para resolver operaciones con paréntesis desde los más internos
            while (operacion.Contains('('))
            {
                int start = operacion.LastIndexOf('('); // Encuentra el último paréntesis de apertura
                int end = operacion.IndexOf(')', start); // Encuentra el primer paréntesis de cierre después del último '('

                if (end > start)
                {
                    // Extrae la operación dentro del paréntesis
                    string operacionDentroParentesis = operacion.Substring(start + 1, end - start - 1);

                    // 5! = 120
                    operacionDentroParentesis = CalcularFactorial(operacionDentroParentesis);
                    // Ejemplo: Si operacion es "5", el resultado será "120" (porque 5! = 5 * 4 * 3 * 2 * 1).

                    // 3.14e2 = 31400
                    operacionDentroParentesis = ExpandirNotacionExponencial(operacionDentroParentesis);
                    // Ejemplo: Si operacion es "3.14e2", el resultado será "314" (3.14 * 10^2).

                    // 2^3 = 8
                    operacionDentroParentesis = ElevaciónDeUnaPotencia(operacionDentroParentesis);
                    // Ejemplo: Si operacion es "2^3", el resultado será "8" (2 elevado a 3).

                    // 5 % 2 = 1
                    operacionDentroParentesis = CalcularRestoMod(operacionDentroParentesis);
                    // Ejemplo: Si operacion es "5 % 2", el resultado será "1".

                    // Calcula el resultado de la operación dentro del paréntesis
                    decimal resultadoParentesis = ResolverOperacion(operacionDentroParentesis);

                    // Reemplaza la operación dentro del paréntesis con el resultado
                    operacion = operacion.Substring(0, start) + resultadoParentesis.ToString() + operacion.Substring(end + 1);
                }
            }

            return operacion;

        }

        internal static string CalcularFactorial(string operacion)
        {
            MatchCollection matches = Regex.Matches(operacion, @"(-?\d+([,]\d+)?)!");

            foreach (Match match in matches)
            {
                string resultado = Factorial(decimal.Parse(match.Groups[1].Value));

                operacion = operacion.Replace($"{match.Groups[1].Value}!", resultado);
            }

            return operacion;
        }

        internal static string Factorial(decimal number)
        {
            if (number < 0)
            {
                MessageBox.Show("Los números negativos no tienen factorial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return BigInteger.Zero.ToString();
            }

            if (number % 1 != 0) // Verifica si el número es entero
            {
                return SpecialFunctions.Gamma((double)number + 1).ToString();
            }

            BigInteger resultado = BigInteger.One;

            for (int i = 2; i <= (int)number; i++)
            {
                resultado *= i;
            }

            return resultado.ToString();
        }

        internal static string ElevaciónDeUnaPotencia(string operacion)
        {

            MatchCollection matches = Regex.Matches(operacion, @"(-?\d+(,\d+)?)\^(\d)");

            foreach (Match match in matches)
            {
                double a = double.Parse(match.Groups[1].Value);
                double n = double.Parse(match.Groups[3].Value);

                double resultado = Math.Pow(a, n);

                operacion = operacion.Replace(match.Value, resultado.ToString());
            }

            return operacion;
        }

        internal static string ExpandirNotacionExponencial(string operacion)
        {
            // Expresión regular para detectar patrones de notación científica del tipo 1,23e+4
            MatchCollection matches = Regex.Matches(operacion, @"(-?\d+(,\d+)?)[e][+](\d+)");

            foreach (Match match in matches)
            {
                string numberBase = match.Groups[1].Value;
                int exponent = int.Parse(match.Groups[3].Value);

                // Convertimos la base a un número decimal y aplicamos el exponente
                double baseValue = double.Parse(numberBase);
                double resultValue = baseValue * Math.Pow(10, exponent);

                // Reemplazar la notación científica en la cadena con el resultado
                operacion = operacion.Replace(match.Value, resultValue.ToString("G"));
            }
            return operacion;
        }

        internal static string calcularValorAbsoluto(string expresion)
        {
            MatchCollection matches = Regex.Matches(expresion, @"\(-?(\d+(,\d+)?)\)abs|-?(\d+(,\d+)?)abs");

            foreach (Match match in matches)
            {
                decimal valor = Math.Abs(decimal.Parse(match.Groups[1].Value));

                expresion = expresion.Replace(match.Value, valor.ToString());
            }
            return expresion;
        }

        internal static string CalcularLogaritmo(string expresion)
        {
            MatchCollection matches = Regex.Matches(expresion, @"log\((\d+(,\d+)?)\)|log(-?\d+(,\d+)?)");

            foreach (Match match in matches)
            {
                double number = double.Parse(match.Groups[1].Value);
                double resultado = Math.Log10(number);

                expresion = expresion.Replace(match.Value, resultado.ToString());
            }
            return expresion;
        }

        internal static string CalcularLogaritmoNatural(string expresion)
        {
            MatchCollection matches = Regex.Matches(expresion, @"In\((-?\d+(,\d+)?)\)|In(-?\d+(,\d+)?)");

            foreach (Match match in matches)
            {
                double number = double.Parse(match.Groups[1].Value);
                double resultado = Math.Log(number);

                expresion = expresion.Replace(match.Value, resultado.ToString());
            }
            return expresion;
        }

        internal static string CalcularLogaritmoBaseY(string expresion)
        {
            MatchCollection matches = Regex.Matches(expresion, @"(-?\d+(,\d+)?)logBase(-?\d+(,\d+)?)");

            foreach (Match match in matches)
            {
                double x = double.Parse(match.Groups[1].Value);
                double y = double.Parse(match.Groups[3].Value);

                double resultado = Math.Log(x) / Math.Log(y);

                expresion = expresion.Replace(match.Value, resultado.ToString());
            }

            return expresion;
        }

        internal static string CalcularRestoMod(string expresion)
        {
            MatchCollection matches = Regex.Matches(expresion, @"(-?\d+(,\d+)?)Mod(-?\d+(,\d+)?)");

            foreach (Match match in matches)
            {
                decimal dividendo = decimal.Parse(match.Groups[1].Value);
                decimal divisor = decimal.Parse(match.Groups[3].Value);
                decimal resultado = dividendo % divisor;

                expresion = expresion.Replace(match.Value, resultado.ToString());
            }

            return expresion;
        }

        internal static string CalcularRaicesCuadradas(string expresion)
        {
            MatchCollection matches = Regex.Matches(expresion, @"√\((-?\d+(,\d+)?)\)");

            foreach (Match match in matches)
            {
                double numero = double.Parse(match.Groups[1].Value);

                double resultado = Math.Sqrt(numero);

                expresion = expresion.Replace(match.Value, resultado.ToString());
            }

            return expresion;
        }

        internal static string CalcularRaicesCubica(string expresion)
        {
            MatchCollection matches = Regex.Matches(expresion, @"cuberoot\((-?\d+(,\d+)?)\)");

            foreach (Match match in matches)
            {
                double numero = double.Parse(match.Groups[1].Value);

                double resultado = Math.Pow(numero, 1.0 / 3.0);

                expresion = expresion.Replace(match.Value, resultado.ToString());
            }

            return expresion;
        }

        internal static string CalcularQuintaRaiz(string expresion)
        {
            MatchCollection matches = Regex.Matches(expresion, @"(-?\d+(,\d+)?)yroot(-?\d+(,\d+)?)");

            foreach (Match match in matches)
            {
                double numero1 = double.Parse(match.Groups[1].Value);
                double numero2 = double.Parse(match.Groups[3].Value);

                double result = Math.Pow(numero1, 1.0 / numero2);

                expresion = expresion.Replace(match.Value, result.ToString());
            }

            return expresion;
        }

        internal static string CalcularExponencial(string expresion)
        {
            MatchCollection matches = Regex.Matches(expresion, @"e^\((-?\d+(,\d+)?)\)");

            foreach (Match match in matches)
            {
                double numero = double.Parse(match.Groups[1].Value);
                double resultado = Math.Exp(numero);

                expresion = expresion.Replace(match.Value, resultado.ToString());
            }

            return expresion;
        }
    }
}
