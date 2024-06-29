using ExamenDePOO.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamenDePOO.Total
{
    public class CalcularTotal
    {
        public double Total { get; private set; }

        public CalcularTotal()
        {
            Total = 0;
        }

        public void Calcular(List<Producto> productos)
        {
            Total = productos.Sum(p => p.Precio);
        }
    }
}
