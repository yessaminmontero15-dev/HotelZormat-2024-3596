using HotelZormat.Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelZormat.Negocio.Servicios;
namespace HotelZormat
{
    public partial class FormGestionHabitaciones : Form
    {
        private readonly HabitacionService _habitacionService;
            private Habitacion _habitacionActual;

        public FormGestionHabitaciones()
        {
            InitializeComponent();
            _habitacionService = new HabitacionService();
        }



    }
}
