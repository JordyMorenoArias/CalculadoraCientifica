using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MathNet.Numerics;
using MathNet.Numerics.Distributions;

namespace CalculadoraCientifica
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
            List<decimal> numeros = expresiones.Select(exp => decimal.Parse(exp, System.Globalization.CultureInfo.InvariantCulture)).ToList();

            if (operadores.Count == expresiones.Count)
            {
                if (operadores[0] == '-')
                {
                    // Si el primer operador es '-', asumimos que el primer número es negativo
                    numeros[0] = -numeros[0];
                    operadores.RemoveAt(0); // Eliminar el operador inicial '-'
                }
            }

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
                catch (Exception ex)
                {
                    return -total;
                }

            }

            return total;
        }


        public static List<string> ObtenerExpresiones(string entrada)
        {
            entrada = entrada.Replace(',', '.');
            List<string> expresiones = new List<string>();
            string numero = "";
            bool decimalEncontrado = false;

            foreach (char c in entrada)
            {
                if (char.IsDigit(c) || (c == '.' && !decimalEncontrado))
                {
                    numero += c; // Agregar dígitos consecutivos para formar el número
                    if (c == '.')
                        decimalEncontrado = true; // Marcar que se encontró un punto decimal
                }
                else
                {
                    if (numero != "")
                    {
                        expresiones.Add(numero); // Agregar el número completo a la lista
                        numero = ""; // Reiniciar para el siguiente número
                        decimalEncontrado = false; // Reiniciar la bandera para el próximo número
                    }
                }

            }

            // Agregar el último número si existe
            if (numero != "")
            {
                expresiones.Add(numero);
            }

            return expresiones;
        }

        public static List<char> ObtenerOperadores(string entrada)
        {
            List<char> operadores = new List<char>();

            foreach (char c in entrada)
            {
                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    operadores.Add(c); // Agregar el operador a la lista
                }
            }
            return operadores;
        }

        // Agrega paréntesis de cierre si falta alguno al final
        internal static string BuscarParentesis(string operacion)
        {
            int balance = 0;
            for (int i = 0; i < operacion.Length; i++)
            {
                if (operacion[i] == '(') balance++;
                else if (operacion[i] == ')') balance--;
            }
            if (balance > 0)
            {
                operacion += new string(')', balance); // Añadir los paréntesis de cierre que faltan
            }

            // Método para resolver operaciones con paréntesis desde los más internos
            while (operacion.Contains('('))
            {
                int start = operacion.LastIndexOf('('); // Encuentra el último paréntesis de apertura
                int end = operacion.IndexOf(')', start); // Encuentra el primer paréntesis de cierre después del último '('

                if (end > start)
                {
                    // Extrae la operación dentro del paréntesis
                    string operacionDentroParentesis = operacion.Substring(start + 1, end - start - 1);

                    operacionDentroParentesis = Calculadora.CalcularFactorial(operacionDentroParentesis);

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
            operacion = operacion.Replace(',', '.');

            for (int i = 0; i < operacion.Length; i++)
            {
                if (operacion[i] == '!')
                {
                    string valorCalcular = "";
                    int j = i - 1;

                    // Recorre hacia atrás para encontrar el número anterior al '!'
                    while (j >= 0 && (char.IsDigit(operacion[j]) || operacion[j] == '.'))
                    {
                        valorCalcular = operacion[j] + valorCalcular;
                        j--;
                    }

                    // Calcula el factorial del número extraído
                    decimal resultado = FactorialRecursivo(decimal.Parse(valorCalcular, System.Globalization.CultureInfo.InvariantCulture));
                    operacion = operacion.Substring(0, j + 1) + resultado.ToString() + operacion.Substring(i + 1);

                    // Reinicia el índice para evitar saltar partes de la cadena modificada
                    i = -1;
                }
            }

            return operacion;
        }

        internal static decimal FactorialRecursivo(decimal number)
        {
            if (number < 0)
            {
                MessageBox.Show("Los números negativos no tienen factorial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (number % 1 == 0) // Verifica si el número es entero
            {
                if (number == 0) return 1;
                else return number * FactorialRecursivo(number - 1);
            }
            else // Si el número no es entero
            {
                return (decimal)SpecialFunctions.Gamma((double)number + 1);
            }
        }

    }
}
