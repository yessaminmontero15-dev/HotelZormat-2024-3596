using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelZormat.Negocio.Modelo;
using HotelZormat.Negocio.Servicios;
namespace HotelZormat.Negocio.Modelo
{

    /// TODO-- Representa una habitación del hotel.

    public class Habitacion
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Tipo { get; set; }
        public int Piso { get; set; }
        public int Capacidad { get; set; }
        public decimal TarifaBase { get; set; }
        public string Estado { get; set; }

        public bool EstaDisponible()
        {
            return Estado == "Disponible";
        }
        public class HabitacionOcupadaException : Exception
        {
            public int NumeroHabitacion { get; }

            public HabitacionOcupadaException(int numero)
                : base($"La habitación {numero} está ocupada.")
            {
                NumeroHabitacion = numero;
            }
        }
    }
    
}