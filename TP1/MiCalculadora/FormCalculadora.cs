using Entidades;
using System;
using System.Text;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicializa el comboBox y limpia el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add(" ");
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");

            Limpiar();
        }

        /// <summary>
        /// Borra los datos utilizados
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.Text = " ";
            lblResultado.Text = "0";
        }

        /// <summary>
        /// boton que Utiliza el metodo limpiar para borrar los datos utilizados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Cierra el formulario por medio del boton con previo mensaje de confirmacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Inicializa dos objetos de tipo Operando para utilizar el metodo Operar
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando numero1Aux = new Operando(numero1);
            Operando numero2Aux = new Operando(numero2);
            char auxChar;
            double aux = 0;
            if (char.TryParse(operador, out auxChar))
            {
                aux = Calculadora.Operar(numero1Aux, numero2Aux, auxChar);

            }

            return aux;
        }
        /// <summary>
        /// Boton que utiliza el metodo operar y asigna el resultado al listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double retorno;
            retorno = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            lblResultado.Text = retorno.ToString();
            this.lstOperaciones.Items.Add(Mostrar());

        }

        /// <summary>
        /// Muestra las propiedades utilizadas
        /// </summary>
        /// <returns></returns>
        public string Mostrar()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"{this.txtNumero1.Text} {this.cmbOperador.Text} {this.txtNumero2.Text} = {this.lblResultado.Text}");
            return str.ToString();

        }

        /// <summary>
        /// Boton que convierte a Binario invocando al metodo DecimalBinario de la clase Operando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string auxRetorno = " ";
            if (lblResultado.Text != null)
            {
                auxRetorno = Operando.DecimalBinario(lblResultado.Text);
                
            }
            lblResultado.Text = auxRetorno;
        }

        /// <summary>
        /// Boton que convierte a decimal llamando al metodo BinarioDecimal de la clase Operando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string auxRetorno;
            if (lblResultado.Text != null)
            {
               auxRetorno = Operando.BinarioDecimal(lblResultado.Text);

            }else
            {
                auxRetorno = " ";
            }

            lblResultado.Text = auxRetorno;
        }

        /// <summary>
        /// Cierra el formulario por medio de la X con previo mensaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Estas seguro que queres salir ?", "Salir", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.No)
            {
                e.Cancel = true;  
                
            }
        }
    }
}
