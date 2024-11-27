namespace CalculadoraCientifica
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn2nd = new Button();
            btnPi = new Button();
            btnBaseLogaritmos = new Button();
            btnCE = new Button();
            btnExp = new Button();
            btnValorAbsoluto = new Button();
            btnInversoMultiplicativo = new Button();
            btnXsobre2 = new Button();
            btnDivisions = new Button();
            button12 = new Button();
            btnParéntesisApertura = new Button();
            btnParéntesisCierre = new Button();
            btnRaízCuadrada = new Button();
            btnNine = new Button();
            btnEight = new Button();
            btnSeven = new Button();
            btnXsobreY = new Button();
            btnSix = new Button();
            btnFive = new Button();
            btnFour = new Button();
            btnPotencia10 = new Button();
            btnThree = new Button();
            btnTwo = new Button();
            btnOne = new Button();
            btnLog = new Button();
            btnComa = new Button();
            btnZero = new Button();
            btnCambiarSigno = new Button();
            btnIn = new Button();
            btnDelete = new FontAwesome.Sharp.IconButton();
            btnIgual = new FontAwesome.Sharp.IconButton();
            btnMultiplications = new Button();
            btnSubtraction = new Button();
            btnAdd = new Button();
            txtDisplay = new TextBox();
            btnMod = new Button();
            txtFormula = new TextBox();
            SuspendLayout();
            // 
            // btn2nd
            // 
            btn2nd.Font = new Font("Century Gothic", 10.2F);
            btn2nd.Location = new Point(21, 154);
            btn2nd.Name = "btn2nd";
            btn2nd.Size = new Size(87, 46);
            btn2nd.TabIndex = 0;
            btn2nd.Text = "2^nd";
            btn2nd.UseVisualStyleBackColor = true;
            btn2nd.Click += btn2nd_Click;
            // 
            // btnPi
            // 
            btnPi.Font = new Font("Century Gothic", 10.2F);
            btnPi.Location = new Point(114, 155);
            btnPi.Name = "btnPi";
            btnPi.Size = new Size(87, 46);
            btnPi.TabIndex = 1;
            btnPi.Text = "π";
            btnPi.UseVisualStyleBackColor = true;
            btnPi.Click += btnRaiz_Click;
            // 
            // btnBaseLogaritmos
            // 
            btnBaseLogaritmos.Font = new Font("Century Gothic", 10.2F);
            btnBaseLogaritmos.Location = new Point(207, 155);
            btnBaseLogaritmos.Name = "btnBaseLogaritmos";
            btnBaseLogaritmos.Size = new Size(87, 46);
            btnBaseLogaritmos.TabIndex = 2;
            btnBaseLogaritmos.Text = "e";
            btnBaseLogaritmos.UseVisualStyleBackColor = true;
            btnBaseLogaritmos.Click += btnBaseLogaritmos_Click;
            // 
            // btnCE
            // 
            btnCE.Font = new Font("Century Gothic", 10.2F);
            btnCE.Location = new Point(300, 155);
            btnCE.Name = "btnCE";
            btnCE.Size = new Size(87, 46);
            btnCE.TabIndex = 3;
            btnCE.Text = "CE";
            btnCE.UseVisualStyleBackColor = true;
            btnCE.Click += btnCE_Click;
            // 
            // btnExp
            // 
            btnExp.Font = new Font("Century Gothic", 10.2F);
            btnExp.Location = new Point(300, 207);
            btnExp.Name = "btnExp";
            btnExp.Size = new Size(87, 46);
            btnExp.TabIndex = 8;
            btnExp.Text = "exp";
            btnExp.UseVisualStyleBackColor = true;
            btnExp.Click += btnExp_Click;
            // 
            // btnValorAbsoluto
            // 
            btnValorAbsoluto.Font = new Font("Century Gothic", 10.2F);
            btnValorAbsoluto.Location = new Point(207, 207);
            btnValorAbsoluto.Name = "btnValorAbsoluto";
            btnValorAbsoluto.Size = new Size(87, 46);
            btnValorAbsoluto.TabIndex = 7;
            btnValorAbsoluto.Text = "|x|";
            btnValorAbsoluto.UseVisualStyleBackColor = true;
            btnValorAbsoluto.Click += btnValorAbsoluto_Click;
            // 
            // btnInversoMultiplicativo
            // 
            btnInversoMultiplicativo.Font = new Font("Century Gothic", 10.2F);
            btnInversoMultiplicativo.Location = new Point(114, 207);
            btnInversoMultiplicativo.Name = "btnInversoMultiplicativo";
            btnInversoMultiplicativo.Size = new Size(87, 46);
            btnInversoMultiplicativo.TabIndex = 6;
            btnInversoMultiplicativo.Text = "1/x";
            btnInversoMultiplicativo.UseVisualStyleBackColor = true;
            btnInversoMultiplicativo.Click += btnInversoMultiplicativo_Click;
            // 
            // btnXsobre2
            // 
            btnXsobre2.Font = new Font("Century Gothic", 10.2F);
            btnXsobre2.Location = new Point(21, 206);
            btnXsobre2.Name = "btnXsobre2";
            btnXsobre2.Size = new Size(87, 46);
            btnXsobre2.TabIndex = 5;
            btnXsobre2.Text = "x^2";
            btnXsobre2.UseVisualStyleBackColor = true;
            btnXsobre2.Click += btnXsobre2_Click;
            // 
            // btnDivisions
            // 
            btnDivisions.Font = new Font("Century Gothic", 10.2F);
            btnDivisions.Location = new Point(393, 263);
            btnDivisions.Name = "btnDivisions";
            btnDivisions.Size = new Size(87, 46);
            btnDivisions.TabIndex = 14;
            btnDivisions.Text = "/";
            btnDivisions.UseVisualStyleBackColor = true;
            btnDivisions.Click += btnDivisions_Click;
            // 
            // button12
            // 
            button12.Font = new Font("Century Gothic", 10.2F);
            button12.Location = new Point(300, 263);
            button12.Name = "button12";
            button12.Size = new Size(87, 46);
            button12.TabIndex = 13;
            button12.Text = "n!";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // btnParéntesisApertura
            // 
            btnParéntesisApertura.Font = new Font("Century Gothic", 10.2F);
            btnParéntesisApertura.Location = new Point(114, 263);
            btnParéntesisApertura.Name = "btnParéntesisApertura";
            btnParéntesisApertura.Size = new Size(87, 46);
            btnParéntesisApertura.TabIndex = 12;
            btnParéntesisApertura.Text = "(";
            btnParéntesisApertura.UseVisualStyleBackColor = true;
            btnParéntesisApertura.Click += btnParéntesisApertura_Click;
            // 
            // btnParéntesisCierre
            // 
            btnParéntesisCierre.Font = new Font("Century Gothic", 10.2F);
            btnParéntesisCierre.Location = new Point(207, 263);
            btnParéntesisCierre.Name = "btnParéntesisCierre";
            btnParéntesisCierre.Size = new Size(87, 46);
            btnParéntesisCierre.TabIndex = 11;
            btnParéntesisCierre.Text = ")";
            btnParéntesisCierre.UseVisualStyleBackColor = true;
            btnParéntesisCierre.Click += btnParéntesisCierre_Click;
            // 
            // btnRaízCuadrada
            // 
            btnRaízCuadrada.Font = new Font("Century Gothic", 10.2F);
            btnRaízCuadrada.Location = new Point(21, 262);
            btnRaízCuadrada.Name = "btnRaízCuadrada";
            btnRaízCuadrada.Size = new Size(87, 46);
            btnRaízCuadrada.TabIndex = 10;
            btnRaízCuadrada.Text = "2√x";
            btnRaízCuadrada.UseVisualStyleBackColor = true;
            btnRaízCuadrada.Click += btnRaízCuadrada_Click;
            // 
            // btnNine
            // 
            btnNine.Font = new Font("Century Gothic", 10.2F);
            btnNine.Location = new Point(300, 315);
            btnNine.Name = "btnNine";
            btnNine.Size = new Size(87, 46);
            btnNine.TabIndex = 23;
            btnNine.Text = "9";
            btnNine.UseVisualStyleBackColor = true;
            btnNine.Click += btnNine_Click;
            // 
            // btnEight
            // 
            btnEight.Font = new Font("Century Gothic", 10.2F);
            btnEight.Location = new Point(207, 315);
            btnEight.Name = "btnEight";
            btnEight.Size = new Size(87, 46);
            btnEight.TabIndex = 22;
            btnEight.Text = "8";
            btnEight.UseVisualStyleBackColor = true;
            btnEight.Click += btnEight_Click;
            // 
            // btnSeven
            // 
            btnSeven.Font = new Font("Century Gothic", 10.2F);
            btnSeven.Location = new Point(114, 315);
            btnSeven.Name = "btnSeven";
            btnSeven.Size = new Size(87, 46);
            btnSeven.TabIndex = 21;
            btnSeven.Text = "7";
            btnSeven.UseVisualStyleBackColor = true;
            btnSeven.Click += btnSeven_Click;
            // 
            // btnXsobreY
            // 
            btnXsobreY.Font = new Font("Century Gothic", 10.2F);
            btnXsobreY.Location = new Point(21, 314);
            btnXsobreY.Name = "btnXsobreY";
            btnXsobreY.Size = new Size(87, 46);
            btnXsobreY.TabIndex = 20;
            btnXsobreY.Text = "x^y";
            btnXsobreY.UseVisualStyleBackColor = true;
            btnXsobreY.Click += btnXsobreY_Click;
            // 
            // btnSix
            // 
            btnSix.Font = new Font("Century Gothic", 10.2F);
            btnSix.Location = new Point(300, 367);
            btnSix.Name = "btnSix";
            btnSix.Size = new Size(87, 46);
            btnSix.TabIndex = 28;
            btnSix.Text = "6";
            btnSix.UseVisualStyleBackColor = true;
            btnSix.Click += btnSix_Click;
            // 
            // btnFive
            // 
            btnFive.Font = new Font("Century Gothic", 10.2F);
            btnFive.Location = new Point(207, 367);
            btnFive.Name = "btnFive";
            btnFive.Size = new Size(87, 46);
            btnFive.TabIndex = 27;
            btnFive.Text = "5";
            btnFive.UseVisualStyleBackColor = true;
            btnFive.Click += btnFive_Click;
            // 
            // btnFour
            // 
            btnFour.Font = new Font("Century Gothic", 10.2F);
            btnFour.Location = new Point(114, 367);
            btnFour.Name = "btnFour";
            btnFour.Size = new Size(87, 46);
            btnFour.TabIndex = 26;
            btnFour.Text = "4";
            btnFour.UseVisualStyleBackColor = true;
            btnFour.Click += btnFour_Click;
            // 
            // btnPotencia10
            // 
            btnPotencia10.Font = new Font("Century Gothic", 10.2F);
            btnPotencia10.Location = new Point(21, 366);
            btnPotencia10.Name = "btnPotencia10";
            btnPotencia10.Size = new Size(87, 46);
            btnPotencia10.TabIndex = 25;
            btnPotencia10.Text = "10^x";
            btnPotencia10.UseVisualStyleBackColor = true;
            btnPotencia10.Click += button30_Click;
            // 
            // btnThree
            // 
            btnThree.Font = new Font("Century Gothic", 10.2F);
            btnThree.Location = new Point(300, 419);
            btnThree.Name = "btnThree";
            btnThree.Size = new Size(87, 46);
            btnThree.TabIndex = 33;
            btnThree.Text = "3";
            btnThree.UseVisualStyleBackColor = true;
            btnThree.Click += btnThree_Click;
            // 
            // btnTwo
            // 
            btnTwo.Font = new Font("Century Gothic", 10.2F);
            btnTwo.Location = new Point(207, 419);
            btnTwo.Name = "btnTwo";
            btnTwo.Size = new Size(87, 46);
            btnTwo.TabIndex = 32;
            btnTwo.Text = "2";
            btnTwo.UseVisualStyleBackColor = true;
            btnTwo.Click += btnTwo_Click;
            // 
            // btnOne
            // 
            btnOne.Font = new Font("Century Gothic", 10.2F);
            btnOne.Location = new Point(114, 419);
            btnOne.Name = "btnOne";
            btnOne.Size = new Size(87, 46);
            btnOne.TabIndex = 31;
            btnOne.Text = "1";
            btnOne.UseVisualStyleBackColor = true;
            btnOne.Click += btnOne_Click;
            // 
            // btnLog
            // 
            btnLog.Font = new Font("Century Gothic", 10.2F);
            btnLog.Location = new Point(21, 418);
            btnLog.Name = "btnLog";
            btnLog.Size = new Size(87, 46);
            btnLog.TabIndex = 30;
            btnLog.Text = "log";
            btnLog.UseVisualStyleBackColor = true;
            btnLog.Click += button35_Click;
            // 
            // btnComa
            // 
            btnComa.Font = new Font("Century Gothic", 10.2F);
            btnComa.Location = new Point(300, 471);
            btnComa.Name = "btnComa";
            btnComa.Size = new Size(87, 46);
            btnComa.TabIndex = 38;
            btnComa.Text = ",";
            btnComa.UseVisualStyleBackColor = true;
            btnComa.Click += btnPunto_Click;
            // 
            // btnZero
            // 
            btnZero.Font = new Font("Century Gothic", 10.2F);
            btnZero.Location = new Point(207, 471);
            btnZero.Name = "btnZero";
            btnZero.Size = new Size(87, 46);
            btnZero.TabIndex = 37;
            btnZero.Text = "0";
            btnZero.UseVisualStyleBackColor = true;
            btnZero.Click += btnZero_Click;
            // 
            // btnCambiarSigno
            // 
            btnCambiarSigno.Font = new Font("Century Gothic", 10.2F);
            btnCambiarSigno.Location = new Point(114, 471);
            btnCambiarSigno.Name = "btnCambiarSigno";
            btnCambiarSigno.Size = new Size(87, 46);
            btnCambiarSigno.TabIndex = 36;
            btnCambiarSigno.Text = "+/-";
            btnCambiarSigno.UseVisualStyleBackColor = true;
            btnCambiarSigno.Click += button39_Click;
            // 
            // btnIn
            // 
            btnIn.Font = new Font("Century Gothic", 10.2F);
            btnIn.Location = new Point(21, 470);
            btnIn.Name = "btnIn";
            btnIn.Size = new Size(87, 46);
            btnIn.TabIndex = 35;
            btnIn.Text = "In";
            btnIn.UseVisualStyleBackColor = true;
            btnIn.Click += btnIn_Click;
            // 
            // btnDelete
            // 
            btnDelete.IconChar = FontAwesome.Sharp.IconChar.DeleteLeft;
            btnDelete.IconColor = Color.Black;
            btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDelete.Location = new Point(393, 155);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(87, 46);
            btnDelete.TabIndex = 40;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnIgual
            // 
            btnIgual.IconChar = FontAwesome.Sharp.IconChar.Equals;
            btnIgual.IconColor = Color.Black;
            btnIgual.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnIgual.Location = new Point(393, 471);
            btnIgual.Name = "btnIgual";
            btnIgual.Size = new Size(87, 46);
            btnIgual.TabIndex = 41;
            btnIgual.UseVisualStyleBackColor = true;
            btnIgual.Click += iconButton1_Click;
            // 
            // btnMultiplications
            // 
            btnMultiplications.Font = new Font("Century Gothic", 10.2F);
            btnMultiplications.Location = new Point(393, 315);
            btnMultiplications.Name = "btnMultiplications";
            btnMultiplications.Size = new Size(87, 46);
            btnMultiplications.TabIndex = 46;
            btnMultiplications.Text = "X";
            btnMultiplications.UseVisualStyleBackColor = true;
            btnMultiplications.Click += btnMultiplications_Click;
            // 
            // btnSubtraction
            // 
            btnSubtraction.Font = new Font("Century Gothic", 10.2F);
            btnSubtraction.Location = new Point(393, 367);
            btnSubtraction.Name = "btnSubtraction";
            btnSubtraction.Size = new Size(87, 46);
            btnSubtraction.TabIndex = 48;
            btnSubtraction.Text = "-";
            btnSubtraction.UseVisualStyleBackColor = true;
            btnSubtraction.Click += btnSubtraction_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Century Gothic", 10.2F);
            btnAdd.Location = new Point(393, 419);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(87, 46);
            btnAdd.TabIndex = 49;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtDisplay
            // 
            txtDisplay.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDisplay.Location = new Point(21, 103);
            txtDisplay.Name = "txtDisplay";
            txtDisplay.Size = new Size(459, 36);
            txtDisplay.TabIndex = 50;
            txtDisplay.TextAlign = HorizontalAlignment.Right;
            // 
            // btnMod
            // 
            btnMod.Font = new Font("Century Gothic", 10.2F);
            btnMod.Location = new Point(393, 207);
            btnMod.Name = "btnMod";
            btnMod.Size = new Size(87, 46);
            btnMod.TabIndex = 51;
            btnMod.Text = "mod";
            btnMod.UseVisualStyleBackColor = true;
            btnMod.Click += button1_Click;
            // 
            // txtFormula
            // 
            txtFormula.BackColor = SystemColors.Control;
            txtFormula.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFormula.Location = new Point(21, 61);
            txtFormula.Name = "txtFormula";
            txtFormula.ReadOnly = true;
            txtFormula.Size = new Size(459, 36);
            txtFormula.TabIndex = 52;
            txtFormula.TextAlign = HorizontalAlignment.Right;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 546);
            Controls.Add(txtFormula);
            Controls.Add(btnMod);
            Controls.Add(txtDisplay);
            Controls.Add(btnAdd);
            Controls.Add(btnSubtraction);
            Controls.Add(btnMultiplications);
            Controls.Add(btnIgual);
            Controls.Add(btnDelete);
            Controls.Add(btnComa);
            Controls.Add(btnZero);
            Controls.Add(btnCambiarSigno);
            Controls.Add(btnIn);
            Controls.Add(btnThree);
            Controls.Add(btnTwo);
            Controls.Add(btnOne);
            Controls.Add(btnLog);
            Controls.Add(btnSix);
            Controls.Add(btnFive);
            Controls.Add(btnFour);
            Controls.Add(btnPotencia10);
            Controls.Add(btnNine);
            Controls.Add(btnEight);
            Controls.Add(btnSeven);
            Controls.Add(btnXsobreY);
            Controls.Add(btnDivisions);
            Controls.Add(button12);
            Controls.Add(btnParéntesisApertura);
            Controls.Add(btnParéntesisCierre);
            Controls.Add(btnRaízCuadrada);
            Controls.Add(btnExp);
            Controls.Add(btnValorAbsoluto);
            Controls.Add(btnInversoMultiplicativo);
            Controls.Add(btnXsobre2);
            Controls.Add(btnCE);
            Controls.Add(btnBaseLogaritmos);
            Controls.Add(btnPi);
            Controls.Add(btn2nd);
            Name = "Form1";
            Text = "Calculadora Científica";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn2nd;
        private Button btnPi;
        private Button btnBaseLogaritmos;
        private Button btnCE;
        private Button button5;
        private Button button6;
        private Button btnExp;
        private Button btnValorAbsoluto;
        private Button btnInversoMultiplicativo;
        private Button btnXsobre2;
        private Button btnDivisions;
        private Button button12;
        private Button btnParéntesisApertura;
        private Button btnParéntesisCierre;
        private Button btnRaízCuadrada;
        private Button btnNine;
        private Button btnEight;
        private Button btnSeven;
        private Button btnXsobreY;
        private Button btnSix;
        private Button btnFive;
        private Button btnFour;
        private Button btnPotencia10;
        private Button btnThree;
        private Button btnTwo;
        private Button btnOne;
        private Button btnLog;
        private Button btnComa;
        private Button btnZero;
        private Button btnCambiarSigno;
        private Button btnIn;
        private FontAwesome.Sharp.IconButton btnDelete;
        private FontAwesome.Sharp.IconButton btnIgual;
        private Button btnMultiplications;
        private Button btnSubtraction;
        private Button btnAdd;
        private TextBox txtDisplay;
        private Button btnMod;
        private TextBox txtFormula;
    }
}
