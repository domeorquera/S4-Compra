using System.Globalization;

namespace S4_Compra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal precio = decimal.Parse(txtPrecio.Text, CultureInfo.InvariantCulture);
            int cantidad = (int)nudCantidad.Value;

            var r = CalculadoraCompra.Calcular(precio, cantidad);

            txtSubtotal.Text = CalculadoraCompra.Dinero(r.Subtotal);
            txtDescuento.Text = CalculadoraCompra.Dinero(r.Descuento);
            txtIva.Text = CalculadoraCompra.Dinero(r.Iva);
            txtTotal.Text = CalculadoraCompra.Dinero(r.Total);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPrecio.Clear();
            nudCantidad.Value = 1;
            txtSubtotal.Text = "Subtotal:";
            txtDescuento.Text = "Descuento:";
            txtIva.Text = "IVA 15%:";
            txtTotal.Text = "TOTAL A PAGAR:";
            txtPrecio.Focus();
        }
    }
}
