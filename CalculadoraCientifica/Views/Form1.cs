using CalculadoraCientifica.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Resources;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CalculadoraCientifica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "0";
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.TrimEnd()[txtDisplay.Text.Length - 1] == ')')
            {
                txtDisplay.Text += "* 1";
            }
            else
            {
                txtDisplay.Text += "1";
            }
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "2";
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "3";
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "4";
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "5";
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "6";
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "7";
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "8";
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "9";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                var match = Regex.Match(txtDisplay.Text, @"Mod\s$");

                // Eliminar espacios en blanco solo en los extremos
                txtDisplay.Text = txtDisplay.Text.TrimEnd();

                char lastChar = txtDisplay.Text[txtDisplay.Text.Length - 1];
                // Verificar si el último carácter es +, - o *
                if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/')
                {
                    // Reemplazar el último carácter con "*"
                    txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1) + "+ ";
                }
                else if (match.Success)
                {
                    txtDisplay.Text = txtDisplay.Text.Substring(0, match.Index) + "+ ";
                }
                else
                {
                    txtDisplay.Text += " + ";
                }
            }
        }

        private void btnSubtraction_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                var match = Regex.Match(txtDisplay.Text, @"Mod\s$");

                // Eliminar espacios en blanco solo en los extremos
                txtDisplay.Text = txtDisplay.Text.TrimEnd();

                char lastChar = txtDisplay.Text[txtDisplay.Text.Length - 1];
                // Verificar si el último carácter es +, - o *
                if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/')
                {
                    // Reemplazar el último carácter con "-"
                    txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1) + "- ";
                }
                else if (match.Success)
                {
                    txtDisplay.Text = txtDisplay.Text.Substring(0, match.Index) + "- ";
                }
                else if (lastChar == '(')
                {
                    txtDisplay.Text += "-";
                }
                else
                {
                    txtDisplay.Text += " - ";
                }
            }
            else
            {
                txtDisplay.Text += "0 - ";
            }
        }

        private void btnMultiplications_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                var match = Regex.Match(txtDisplay.Text, @"Mod\s$");

                // Eliminar espacios en blanco solo en los extremos
                txtDisplay.Text = txtDisplay.Text.TrimEnd();

                char lastChar = txtDisplay.Text[txtDisplay.Text.Length - 1];
                // Verificar si el último carácter es +, - o *
                if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/')
                {
                    // Reemplazar el último carácter con "*"
                    txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1) + "* ";
                }
                else if (match.Success)
                {
                    txtDisplay.Text = txtDisplay.Text.Substring(0, match.Index) + "* ";
                }
                else
                {
                    txtDisplay.Text += " * ";
                }
            }
        }

        private void btnDivisions_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                var match = Regex.Match(txtDisplay.Text, @"Mod\s$");

                // Eliminar espacios en blanco solo en los extremos
                txtDisplay.Text = txtDisplay.Text.TrimEnd();

                char lastChar = txtDisplay.Text[txtDisplay.Text.Length - 1];

                // Verificar si el último carácter es +, - o *
                if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/')
                {
                    // Reemplazar el último carácter con "/"
                    txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1) + "/ ";
                }
                else if (match.Success)
                {
                    txtDisplay.Text = txtDisplay.Text.Substring(0, match.Index) + "/ ";
                }
                else
                {
                    // Si el último carácter no es +, - o *, simplemente agregar "/"
                    txtDisplay.Text += " / ";
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string operacion = txtDisplay.Text.TrimEnd();

                // Asegúrate de que la cadena no esté vacía antes de realizar el bucle
                if (!string.IsNullOrEmpty(operacion))
                {
                    // Verificar el último carácter de la cadena
                    char ultimoCaracter = operacion[operacion.Length - 1];

                    if (!char.IsDigit(ultimoCaracter))  // Si el último carácter no es un dígito
                    {
                        // Verificar si el último carácter es un operador o un paréntesis
                        if (!char.IsDigit(ultimoCaracter))
                        {
                            if(ultimoCaracter == '(')
                                operacion += '0';  // Agregar '0' al final
                            else
                                operacion += " 0";  // Agregar '0' al final 
                        }
                    }
                }

                operacion = Calculadora.CorregirParentesis(operacion);

                // Mostramos la operación completa en txtFormula con un '=' al final
                txtFormula.Text = operacion + " = ";

                operacion = operacion.Replace(" ", "");

                // log(10) ≈ 1,3010
                // Ejemplo: Si operacion es "10", el resultado será el logaritmo de 10, que es aproximadamente "1,3010".
                operacion = Calculadora.CalcularLogaritmo(operacion);

                // In(10) ≈ 2.3026
                // Ejemplo: Si operacion es "10", el resultado será el logaritmo natural de 10, que es aproximadamente "2.3026".
                operacion = Calculadora.CalcularLogaritmoNatural(operacion);

                // Calcula el valor absoluto de un número dado.
                // Ejemplo: Si operacion es "-20", el resultado será "20".
                operacion = Calculadora.calcularValorAbsoluto(operacion);

                // Calcula la raíz cuadrada de cada número en la operación.
                // Ejemplo: Si operacion es "16", el resultado será "4".
                operacion = Calculadora.CalcularRaicesCuadradas(operacion);

                // Calcula la raíz cúbica de un número.
                // Ejemplo: Si operacion es "27", el resultado será "3".
                operacion = Calculadora.CalcularRaicesCubica(operacion);

                // Busca y evalúa expresiones dentro de paréntesis.
                // Ejemplo: Si operacion es "(4 + 3)", el resultado será "7".
                operacion = Calculadora.BuscarParentesis(operacion);

                // 3.14e2 = 31400
                // Ejemplo: Si operacion es "3.14e2", el resultado será "314" (3.14 * 10^2).
                operacion = Calculadora.ExpandirNotacionExponencial(operacion);

                // 5! = 120
                // Ejemplo: Si operacion es "5", el resultado será "120" (porque 5! = 5 * 4 * 3 * 2 * 1).
                operacion = Calculadora.CalcularFactorial(operacion);

                // Calcula la función exponencial e^x.
                // Ejemplo: Si operacion es "2", el resultado será aproximadamente "7.3891" (e^2).
                operacion = Calculadora.CalcularExponencial(operacion);

                // 2^3 = 8
                // Ejemplo: Si operacion es "2^3", el resultado será "8" (2 elevado a 3).
                operacion = Calculadora.ElevaciónDeUnaPotencia(operacion);

                // Calcula la quinta raíz de un número.
                // Ejemplo: Si operacion es "32", el resultado será "2" (ya que 2^5 = 32).
                operacion = Calculadora.CalcularQuintaRaiz(operacion);

                // Calcula el logaritmo de un número en una base específica Y.
                // Ejemplo: Si operacion es "log base 2 de 8", el resultado será "3" (ya que 2^3 = 8).
                operacion = Calculadora.CalcularLogaritmoBaseY(operacion);

                // 5 % 2 = 1
                // Ejemplo: Si operacion es "5 % 2", el resultado será "1".
                operacion = Calculadora.CalcularRestoMod(operacion);

                // Una vez resueltos los paréntesis, calcula el resultado final
                decimal resultadoFinal = Calculadora.ResolverOperacion(operacion);
                txtDisplay.Text = resultadoFinal.ToString();
            }
            catch
            {
                txtFormula.Text = "Entrada no Valida";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFormula.Text))
            {
                txtFormula.Text = "";
            }
            else if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
        }

        private void btnParéntesisCierre_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = Calculadora.CorregirParentesis(txtDisplay.Text);
        }

        private void btnParéntesisApertura_Click(object sender, EventArgs e)
        {
            // Verificar si el texto está vacío
            if (string.IsNullOrEmpty(txtDisplay.Text))
            {
                txtDisplay.Text += "("; // Agregar solo el paréntesis de apertura si está vacío
            }
            else if (char.IsDigit(txtDisplay.Text[txtDisplay.Text.Length - 1]))
            {
                txtDisplay.Text += " * ("; // Agregar "* (" si el último carácter es un dígito
            }
            else
            {
                txtDisplay.Text += "("; // Agregar "(" en cualquier otro caso
            }
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                if (char.IsDigit(txtDisplay.Text[txtDisplay.Text.Length - 1]))
                {
                    txtDisplay.Text += ",";
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                if (char.IsDigit(txtDisplay.Text[txtDisplay.Text.Length - 1]) || txtDisplay.Text[txtDisplay.Text.Length - 1] == ')')
                {
                    txtDisplay.Text += "!";
                }
            }
        }

        private void btnInversoMultiplicativo_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                // Obtener el texto del display
                string expresion = txtDisplay.Text;

                // Buscar el último número en la cadena usando una expresión regular
                Match match = Regex.Match(expresion, @"(-?\d+(,\d+)?)$");

                if (match.Success)
                {
                    string valor = match.Value;
                    int inicioValor = match.Index;

                    // Reemplazar el último número con "(1/valor"
                    txtDisplay.Text = expresion.Substring(0, inicioValor) + $"(1/{valor}";
                }
                else
                {
                    txtDisplay.Text += "(1/";
                }
            }
            else
            {
                txtDisplay.Text += "(1/"; // Agregar "(" en cualquier otro caso
            }
        }

        private void btnXsobreY_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                if (txtDisplay.Text[txtDisplay.Text.Length - 1] == ')' || char.IsDigit(txtDisplay.Text[txtDisplay.Text.Length - 1]))
                {
                    string tipo = btnXsobreY.Text == "x^y" ? "^" : " yroot ";
                    txtDisplay.Text += tipo;
                }
            }

            CambiarEtiquetasAModoNormal();
        }

        private void btnXsobre2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                // Verifica si el último carácter es un dígito o un paréntesis de cierre
                char ultimoCaracter = txtDisplay.Text[txtDisplay.Text.Length - 1];
                if (char.IsDigit(ultimoCaracter) || ultimoCaracter == ')')
                {
                    // Añade "^2" o "^3" dependiendo del texto del botón
                    string exponente = btnXsobre2.Text == "x^2" ? "^2" : "^3";
                    txtDisplay.Text += exponente;
                }
            }

            CambiarEtiquetasAModoNormal();
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                if (char.IsDigit(txtDisplay.Text[txtDisplay.Text.Length - 1]))
                {
                    txtDisplay.Text += "e+";
                }
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                string expression = txtDisplay.Text;
                int operadorIndex = -1;

                // Recorre la expresión desde el final para encontrar el último número completo (incluyendo punto decimal y signo negativo)
                for (int i = expression.Length - 1; i >= 0; i--)
                {
                    if (char.IsDigit(expression[i]) || expression[i] == ',' || (expression[i] == '-' && i == operadorIndex - 1))
                    {
                        operadorIndex = i;
                    }
                    else
                    {
                        break;
                    }
                }

                if (operadorIndex != -1)
                {
                    // Extrae el último número de la expresión
                    string lastNumber = expression.Substring(operadorIndex);

                    // Cambia el signo del último número
                    if (lastNumber.StartsWith("-"))
                    {
                        lastNumber = lastNumber.Substring(1); // Elimina el signo negativo
                    }
                    else
                    {
                        lastNumber = "-" + lastNumber; // Agrega el signo negativo
                    }

                    // Reconstruye la expresión reemplazando el último número
                    expression = expression.Substring(0, operadorIndex) + lastNumber;

                    // Actualiza el TextBox con la nueva expresión
                    txtDisplay.Text = expression;
                }
            }
        }

        private void btnValorAbsoluto_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                // Obtener el texto del display
                string expresion = txtDisplay.Text;

                // Buscar el último número en la cadena usando la expresión regular
                Match match = Regex.Match(expresion, @"-?\d+(,\d+)?$");

                if (match.Success)
                {
                    string valor = match.Value; // Valor del número encontrado
                    int inicioValor = match.Index; // Índice donde comienza el número

                    // Reemplazar el último número con "(valor)abs"
                    txtDisplay.Text = expresion.Substring(0, inicioValor) + $"({valor})abs";
                }
            }
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDisplay.Text))
            {
                txtDisplay.Text += Math.PI.ToString();
            }
            else
            {
                string expresion = txtDisplay.Text;

                if (!char.IsDigit(expresion[expresion.Length - 1]))
                {
                    txtDisplay.Text += Math.PI.ToString();
                }
            }
        }
        private void btnBaseLogaritmos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDisplay.Text))
            {
                txtDisplay.Text += Math.E.ToString();
            }
            else
            {
                string expresion = txtDisplay.Text;

                if (!char.IsDigit(expresion[expresion.Length - 1]))
                {
                    txtDisplay.Text += Math.E.ToString();
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {

                // Eliminar espacios en blanco solo en los extremos
                txtDisplay.Text = txtDisplay.Text.TrimEnd();
                char lastChar = txtDisplay.Text[txtDisplay.Text.Length - 1];

                // Verificar si la expresión contiene "Mod" al final
                if (Regex.IsMatch(txtDisplay.Text, @"logBase$"))
                {
                    // Reemplazar "Mod" por "logBase" al final de la expresión
                    txtDisplay.Text = Regex.Replace(txtDisplay.Text, @"logBase$", "Mod ");
                }
                // Verificar si el último carácter es +, -, *, o /
                else if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/')
                {
                    // Reemplazar el último carácter con "logBase"
                    txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1) + "Mod ";
                }
                else
                {
                    txtDisplay.Text += " Mod ";
                }
            }
        }

        private void btnRaízCuadrada_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                string expresion = txtDisplay.Text;

                Match match = Regex.Match(expresion, @"-?\d+(,\d+)?$");

                if (match.Success)
                {
                    string valor = match.Value; // Valor del número encontrado
                    int inicioValor = match.Index; // Índice donde comienza el número

                    if (btnRaízCuadrada.Text == "2√x")
                    {
                        txtDisplay.Text = expresion.Substring(0, inicioValor) + $"√({valor})";
                    }
                    else
                    {
                        txtDisplay.Text = expresion.Substring(0, inicioValor) + $"cuberoot({valor})";
                    }
                }
            }

            CambiarEtiquetasAModoNormal();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                if (btnLog.Text == "Log")
                {
                    // Obtener el texto del display
                    string expresion = txtDisplay.Text;

                    // Buscar el último número en la cadena usando la expresión regular
                    Match match = Regex.Match(expresion, @"-?\d+(,\d+)?$");

                    if (match.Success)
                    {
                        string valor = match.Value; // Valor del número encontrado
                        int inicioValor = match.Index; // Índice donde comienza el número

                        txtDisplay.Text = expresion.Substring(0, inicioValor) + $"log({valor})";
                    }
                }
                else
                {
                    // Eliminar espacios en blanco solo en los extremos
                    txtDisplay.Text = txtDisplay.Text.TrimEnd();

                    char lastChar = txtDisplay.Text[txtDisplay.Text.Length - 1];

                    // Verificar si la expresión contiene "Mod" al final
                    if (Regex.IsMatch(txtDisplay.Text, @"Mod$"))
                    {
                        // Reemplazar "Mod" por "logBase" al final de la expresión
                        txtDisplay.Text = Regex.Replace(txtDisplay.Text, @"Mod$", "logBase ");
                    }
                    // Verificar si el último carácter es +, -, *, o /
                    else if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/')
                    {
                        // Reemplazar el último carácter con "logBase"
                        txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1) + "logBase ";
                    }
                    else
                    {
                        // Agregar "logBase" al final de la expresión
                        txtDisplay.Text += " logBase ";
                    }

                }
            }

            CambiarEtiquetasAModoNormal();
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                // Obtener el texto del display
                string expresion = txtDisplay.Text;

                var match1 = Regex.Match(txtDisplay.Text, @"\(?(-?\d+(,\d+)?)\)?$|\s[+\-/*]\s$");

                if (match1.Success)
                {
                    int inicioValor = match1.Index; // Índice donde comienza el número

                    // Reemplazar el último número con "(valor)abs"
                    txtDisplay.Text = expresion.Substring(0, inicioValor);
                }
            }

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                // Obtener el texto del display
                string expresion = txtDisplay.Text;

                // Buscar el último número en la cadena usando la expresión regular
                Match match = Regex.Match(expresion, @"-?\d+(,\d+)?$");

                if (match.Success)
                {
                    string valor = match.Value; // Valor del número encontrado
                    int inicioValor = match.Index; // Índice donde comienza el número

                    if (btnIn.Text == "In")
                    {
                        txtDisplay.Text = expresion.Substring(0, inicioValor) + $"In({valor})";
                    }
                    else
                    {
                        txtDisplay.Text = expresion.Substring(0, inicioValor) + $"e^({valor})";
                    }
                }
            }

            CambiarEtiquetasAModoNormal();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                // Obtener el texto del display
                string expresion = txtDisplay.Text;

                // Buscar el último número en la cadena usando la expresión regular
                Match match = Regex.Match(expresion, @"-?\d+(,\d+)?$");

                if (match.Success)
                {
                    string valor = match.Value; // Valor del número encontrado
                    int inicioValor = match.Index; // Índice donde comienza el número

                    if (btnPotencia10.Text == "10^x")
                    {
                        txtDisplay.Text = expresion.Substring(0, inicioValor) + $"10^({valor})";
                    }
                    else
                    {
                        txtDisplay.Text = expresion.Substring(0, inicioValor) + $"2^({valor})";
                    }

                }
            }

            CambiarEtiquetasAModoNormal();
        }

        private void btn2nd_Click(object sender, EventArgs e)
        {
            if (btnXsobre2.Text == "x^2")
            {
                CambiarEtiquetasAModoAlternativo();
            }
            else
            {
                CambiarEtiquetasAModoNormal();
            }
        }

        private void CambiarEtiquetasAModoAlternativo()
        {
            btnXsobre2.Text = "x^3";
            btnRaízCuadrada.Text = "3√x";
            btnXsobreY.Text = "y√x";
            btnPotencia10.Text = "2^x";
            btnLog.Text = "logyX";
            btnIn.Text = "e^x";
        }

        private void CambiarEtiquetasAModoNormal()
        {
            btnXsobre2.Text = "x^2";
            btnRaízCuadrada.Text = "2√x";
            btnXsobreY.Text = "x^y";
            btnPotencia10.Text = "10^x";
            btnLog.Text = "log";
            btnIn.Text = "in";
        }
    }
}
