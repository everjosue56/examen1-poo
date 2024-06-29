using ExamenDePOO.DataBase.Entities;
using System;
using System.Collections.Generic;

namespace ExamenDePOO.Total
{
    public class TotalDeVentas
    {
        private readonly List<Pedido> _pedidos;

        public TotalDeVentas(List<Pedido> pedidos)
        {
            _pedidos = pedidos;
        }

        public decimal CalcularTotalVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            decimal totalVentas = 0;

            foreach (var pedido in _pedidos)
            {
                
                 
            }

            return totalVentas;
        }
    }
}

