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
            txtDisplay.Text += "1";
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
                string operacion = txtDisplay.Text;

                // Asegúrate de que la cadena no esté vacía antes de realizar el bucle
                if (!string.IsNullOrEmpty(operacion))
                {
                    for (int i = operacion.Length - 1; i >= 0; i--)
                    {
                        if (char.IsDigit(operacion[i]))
                        {
                            // Si encontramos un dígito, no hacemos nada y salimos del bucle
                            break;
                        }
                        else if (operacion[i] == '+' || operacion[i] == '-' || operacion[i] == '*' || operacion[i] == '/')
                        {
                            // Si encontramos un operador, agregamos un '0' al final de la cadena y salimos del bucle
                            operacion += '0';
                            break;
                        }
                    }
                }

                txtDisplay.Text = operacion;  // Actualizamos txtBoxContenedor antes de llamar al método
                btnParéntesisCierre_Click(sender, e);

                txtFormula.Text = txtDisplay.Text + " = ";

                operacion = operacion.Replace(" ", "");

                // (4 + 3) = 7
                operacion = Calculadora.BuscarParentesis(operacion);
                // Ejemplo: Si operacion es "4 + 3", el resultado será "7".

                // 3.14e2 = 314
                operacion = Calculadora.ExpandirNotacionExponencial(operacion);
                // Ejemplo: Si operacion es "3.14e2", el resultado será "314" (3.14 * 10^2).

                // 2^3 = 8
                operacion = Calculadora.ElevaciónDeUnaPotencia(operacion);
                // Ejemplo: Si operacion es "2^3", el resultado será "8" (2 elevado a 3).

                // 5 % 2 = 1
                operacion = Calculadora.CalcularRestoMod(operacion);
                // Ejemplo: Si operacion es "5 % 2", el resultado será "1".

                // 5! = 120
                operacion = Calculadora.CalcularFactorial(operacion);
                // Ejemplo: Si operacion es "5", el resultado será "120" (porque 5! = 5 * 4 * 3 * 2 * 1).


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
            if (txtDisplay.Text.Length > 0 &&
                txtDisplay.Text[txtDisplay.Text.Length - 2] != '-' &&
                txtDisplay.Text[txtDisplay.Text.Length - 2] != '+' &&
                txtDisplay.Text[txtDisplay.Text.Length - 2] != '*' &&
                txtDisplay.Text[txtDisplay.Text.Length - 2] != '/' &&
                txtDisplay.Text[txtDisplay.Text.Length - 2] != 'd')
            {
                int openParenthesesCount = 0;
                int closeParenthesesNeeded = 0;

                for (int i = 0; i < txtDisplay.Text.Length; i++)
                {
                    if (txtDisplay.Text[i] == '(')
                    {
                        openParenthesesCount++;
                    }
                    else if (txtDisplay.Text[i] == ')')
                    {
                        openParenthesesCount--;
                    }
                }

                // Si openParenthesesCount es positivo, significa que hay paréntesis de apertura sin cerrar
                closeParenthesesNeeded = openParenthesesCount;

                for (int i = 0; i < closeParenthesesNeeded; i++)
                {
                    txtDisplay.Text += ")";
                }
            }

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
            if (!string.IsNullOrEmpty(txtDisplay.Text) || txtDisplay.Text[txtDisplay.Text.Length - 1] == ')')
            {
                if (char.IsDigit(txtDisplay.Text[txtDisplay.Text.Length - 1]))
                {
                    txtDisplay.Text += "^";
                }
            }
        }

        private void btnXsobre2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                if (char.IsDigit(txtDisplay.Text[txtDisplay.Text.Length - 1]) || txtDisplay.Text[txtDisplay.Text.Length - 1] == ')')
                {
                    txtDisplay.Text += "^2";
                }
            }
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
                // Verificar si el último carácter es +, - o *
                if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/')
                {
                    // Reemplazar el último carácter con "*"
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

        }

        private void button35_Click(object sender, EventArgs e)
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
                    txtDisplay.Text = expresion.Substring(0, inicioValor) + $"log({valor})";
                }
            }
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

                    // Reemplazar el último número con "(valor)abs"
                    txtDisplay.Text = expresion.Substring(0, inicioValor) + $"In({valor})";
                }
            }
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

                    // Reemplazar el último número con "(valor)abs"
                    txtDisplay.Text = expresion.Substring(0, inicioValor) + $"10^({valor})";
                }
            }
        }

        private void btn2nd_Click(object sender, EventArgs e)
        {

        }
    }
}
