using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace S4_Compra
{
    public static class CalculadoraCompra
    {
        public const decimal TasaIva = 0.15m;   // 15 %

        // Devuelve (subtotal, descuento, iva, total)
        public static (decimal Subtotal, decimal Descuento, decimal Iva, decimal Total)
            Calcular(decimal precio, int cantidad)
        {
            decimal subtotal = precio * cantidad;

            // 10 % de descuento si el subtotal es 100 o más
            decimal descuento = 0m;
            if (subtotal >= 100m)
                descuento = Math.Round(subtotal * 0.10m, 2, MidpointRounding.AwayFromZero);

            // El IVA se calcula sobre (subtotal - descuento)
            decimal iva = Math.Round((subtotal - descuento) * TasaIva, 2, MidpointRounding.AwayFromZero);

            decimal total = subtotal - descuento + iva;
            return (subtotal, descuento, iva, total);
        }

        public static string Dinero(decimal valor)
        {
            return "$" + valor.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
