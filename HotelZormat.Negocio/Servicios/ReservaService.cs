using HotelZormat.Negocio.Modelo;
using System;
using System.Collections.Generic;


namespace HotelZormat.Negocio.Servicios
{
    public class ReservaService
    {
        public List<Habitacion> ObtenerHabitaciones()
        {
            return new List<Habitacion>
            {
                new Habitacion { Numero = 301, Piso = 3, Tipo = "Simple",  Estado = "Disponible" },
                new Habitacion { Numero = 302, Piso = 3, Tipo = "Doble",   Estado = "Ocupada" },
                new Habitacion { Numero = 303, Piso = 3, Tipo = "Suite",   Estado = "Reservada" },
                new Habitacion { Numero = 201, Piso = 2, Tipo = "Simple",  Estado = "Disponible" },
                new Habitacion { Numero = 401, Piso = 4, Tipo = "Doble",   Estado = "Mantenimiento" },
            };
        }

        public Habitacion BuscarHabitacion(int numero)
        {
            var todas = ObtenerHabitaciones();
            foreach (var hab in todas)
            {
                if (hab.Numero == numero)
                    return hab;
            }
            return null;
        }

        public void GuardarHabitacion(Habitacion hab)
        {
            if (hab.Estado == "Ocupada")
                throw new HabitacionOcupadaException(hab.Numero);
        }

        public decimal ObtenerTarifa(string tipo)
        {
            switch (tipo)
            {
                case "Simple": return 1500m;
                case "Doble": return 2500m;
                case "Suite": return 5000m;
                default:
                    throw new ArgumentException($"Tipo desconocido: {tipo}");
            }
        }
    }
}