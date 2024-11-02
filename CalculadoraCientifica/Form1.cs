using System.Diagnostics.Eventing.Reader;
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
            txtBoxContenedor.Text += "0";
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            txtBoxContenedor.Text += "1";
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            txtBoxContenedor.Text += "2";
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            txtBoxContenedor.Text += "3";
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            txtBoxContenedor.Text += "4";
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            txtBoxContenedor.Text += "5";
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            txtBoxContenedor.Text += "6";
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            txtBoxContenedor.Text += "7";
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            txtBoxContenedor.Text += "8";
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            txtBoxContenedor.Text += "9";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBoxContenedor.Text.Length > 0)
            {
                // Eliminar espacios en blanco solo en los extremos
                txtBoxContenedor.Text = txtBoxContenedor.Text.Trim();

                char lastChar = txtBoxContenedor.Text[txtBoxContenedor.Text.Length - 1];
                // Verificar si el �ltimo car�cter es +, - o *
                if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/')
                {
                    // Reemplazar el �ltimo car�cter con "*"
                    txtBoxContenedor.Text = txtBoxContenedor.Text.Substring(0, txtBoxContenedor.Text.Length - 1) + "+ ";
                }
                else
                {
                    txtBoxContenedor.Text += " + ";
                }
            }
            else
            {
                // Si est� vac�o, agregar "/"
                txtBoxContenedor.Text += " + ";
            }
        }

        private void btnSubtraction_Click(object sender, EventArgs e)
        {
            if (txtBoxContenedor.Text.Length > 0)
            {
                // Eliminar espacios en blanco solo en los extremos
                txtBoxContenedor.Text = txtBoxContenedor.Text.Trim();

                char lastChar = txtBoxContenedor.Text[txtBoxContenedor.Text.Length - 1];
                // Verificar si el �ltimo car�cter es +, - o *
                if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/')
                {
                    // Reemplazar el �ltimo car�cter con "-"
                    txtBoxContenedor.Text = txtBoxContenedor.Text.Substring(0, txtBoxContenedor.Text.Length - 1) + "- ";
                }
                else
                {
                    txtBoxContenedor.Text += " - ";
                }
            }
            else
            {
                // Si est� vac�o, agregar "/"
                txtBoxContenedor.Text += "0 - ";

            }
        }

        private void btnMultiplications_Click(object sender, EventArgs e)
        {
            if (txtBoxContenedor.Text.Length > 0)
            {
                // Eliminar espacios en blanco solo en los extremos
                txtBoxContenedor.Text = txtBoxContenedor.Text.Trim();

                char lastChar = txtBoxContenedor.Text[txtBoxContenedor.Text.Length - 1];
                // Verificar si el �ltimo car�cter es +, - o *
                if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/')
                {
                    // Reemplazar el �ltimo car�cter con "*"
                    txtBoxContenedor.Text = txtBoxContenedor.Text.Substring(0, txtBoxContenedor.Text.Length - 1) + "* ";
                }
                else
                {
                    txtBoxContenedor.Text += " * ";
                }
            }
        }

        private void btnDivisions_Click(object sender, EventArgs e)
        {
            if (txtBoxContenedor.Text.Length > 0)
            {
                // Eliminar espacios en blanco solo en los extremos
                txtBoxContenedor.Text = txtBoxContenedor.Text.Trim();

                char lastChar = txtBoxContenedor.Text[txtBoxContenedor.Text.Length - 1];

                // Verificar si el �ltimo car�cter es +, - o *
                if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/')
                {
                    // Reemplazar el �ltimo car�cter con "/"
                    txtBoxContenedor.Text = txtBoxContenedor.Text.Substring(0, txtBoxContenedor.Text.Length - 1) + "/ ";
                }
                else
                {
                    // Si el �ltimo car�cter no es +, - o *, simplemente agregar "/"
                    txtBoxContenedor.Text += " / ";
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string operacion = txtBoxContenedor.Text;

                // Aseg�rate de que la cadena no est� vac�a antes de realizar el bucle
                if (!string.IsNullOrEmpty(operacion))
                {
                    for (int i = operacion.Length - 1; i >= 0; i--)
                    {
                        if (char.IsDigit(operacion[i]))
                        {
                            // Si encontramos un d�gito, no hacemos nada y salimos del bucle
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

                txtBoxContenedor.Text = operacion;  // Actualizamos txtBoxContenedor antes de llamar al m�todo
                btnPar�ntesisCierre_Click(sender, e);

                txtFormula.Text = txtBoxContenedor.Text + " = ";

                operacion = operacion.Replace(" ", "");

                operacion = Calculadora.BuscarParentesis(operacion);
                operacion = Calculadora.CalcularFactorial(operacion);
                operacion = Calculadora.Elevaci�nDeUnaPotencia(operacion);
                operacion = Calculadora.CalculateExponente(operacion);

                // Una vez resueltos los par�ntesis, calcula el resultado final
                decimal resultadoFinal = Calculadora.ResolverOperacion(operacion);
                txtBoxContenedor.Text = resultadoFinal.ToString();
            }
            catch (Exception ex)
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
            else if (!string.IsNullOrEmpty(txtBoxContenedor.Text))
            {
                txtBoxContenedor.Text = txtBoxContenedor.Text.Substring(0, txtBoxContenedor.Text.Length - 1);
            }
        }

        private void btnPar�ntesisCierre_Click(object sender, EventArgs e)
        {
            if (txtBoxContenedor.Text.Length > 0 &&
                txtBoxContenedor.Text[txtBoxContenedor.Text.Length - 2] != '-' &&
                txtBoxContenedor.Text[txtBoxContenedor.Text.Length - 2] != '+' &&
                txtBoxContenedor.Text[txtBoxContenedor.Text.Length - 2] != '*' &&
                txtBoxContenedor.Text[txtBoxContenedor.Text.Length - 2] != '/')
            {
                int openParenthesesCount = 0;
                int closeParenthesesNeeded = 0;

                for (int i = 0; i < txtBoxContenedor.Text.Length; i++)
                {
                    if (txtBoxContenedor.Text[i] == '(')
                    {
                        openParenthesesCount++;
                    }
                    else if (txtBoxContenedor.Text[i] == ')')
                    {
                        openParenthesesCount--;
                    }
                }

                // Si openParenthesesCount es positivo, significa que hay par�ntesis de apertura sin cerrar
                closeParenthesesNeeded = openParenthesesCount;

                for (int i = 0; i < closeParenthesesNeeded; i++)
                {
                    txtBoxContenedor.Text += ")";
                }
            }

        }

        private void btnPar�ntesisApertura_Click(object sender, EventArgs e)
        {
            // Verificar si el texto est� vac�o
            if (string.IsNullOrEmpty(txtBoxContenedor.Text))
            {
                txtBoxContenedor.Text += "("; // Agregar solo el par�ntesis de apertura si est� vac�o
            }
            else if (char.IsDigit(txtBoxContenedor.Text[txtBoxContenedor.Text.Length - 1]))
            {
                txtBoxContenedor.Text += " * ("; // Agregar "* (" si el �ltimo car�cter es un d�gito
            }
            else
            {
                txtBoxContenedor.Text += "("; // Agregar "(" en cualquier otro caso
            }
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxContenedor.Text))
            {
                if (char.IsDigit(txtBoxContenedor.Text[txtBoxContenedor.Text.Length - 1]))
                {
                    txtBoxContenedor.Text += ",";
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxContenedor.Text))
            {
                if (char.IsDigit(txtBoxContenedor.Text[txtBoxContenedor.Text.Length - 1]))
                {
                    txtBoxContenedor.Text += "!";
                }
            }
        }

        private void btnInversoMultiplicativo_Click(object sender, EventArgs e)
        {
            txtBoxContenedor.Text += "(1/";
        }

        private void btnXsobreY_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxContenedor.Text))
            {
                if (char.IsDigit(txtBoxContenedor.Text[txtBoxContenedor.Text.Length - 1]))
                {
                    txtBoxContenedor.Text += "^";
                }
            }
        }

        private void btnXsobre2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxContenedor.Text))
            {
                if (char.IsDigit(txtBoxContenedor.Text[txtBoxContenedor.Text.Length - 1]))
                {
                    txtBoxContenedor.Text += "^2";
                }
            }
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxContenedor.Text))
            {
                if (char.IsDigit(txtBoxContenedor.Text[txtBoxContenedor.Text.Length - 1]))
                {
                    txtBoxContenedor.Text += ",e+";
                }
            }
        }
    }
}
