using HotelZormat.Negocio.Modelo;
using HotelZormat.Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelZormat
{
    public partial class frmGestionHabitaciones : Form
    {
        ReservaService reservaService = new ReservaService();

        public frmGestionHabitaciones()
        {
            InitializeComponent();
        }


        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
                string tipo = cboTipo.SelectedItem?.ToString() ?? "";
            switch (tipo)
            {
                case "Simple": lblIcono.Text = "🛏️";  break;
                case "Doble":  lblIcono.Text = "🛏🛏"; break;
                case "Suite":  lblIcono.Text = "👑";   break;
                default:       lblIcono.Text = "🏨";   break;
            }

        }

        private void cboAccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmGestionHabitaciones_Load(object sender, EventArgs e)
        {
            var tipos = new System.Collections.Generic.List<string> { "Simple", "Doble", "Suite" };
            foreach (string tipo in tipos)
                cboTipo.Items.Add(tipo);

            CargarHabitacionesPiso3();
        }

        private void CargarHabitacionesPiso3()
        {
            lstHabitaciones.Items.Clear();
            var habitaciones = reservaService.ObtenerHabitaciones();
            foreach (var hab in habitaciones)
            {
                if (hab.Piso == 3)
                    lstHabitaciones.Items.Add($"{hab.Numero} — {hab.Tipo}");
            }
        }

        private void lblEstado_Click(object sender, EventArgs e)
        {
         
        }
        private void AplicarColorEstado(string estado)
        {
            switch (estado)
            {
                case "Disponible": lblEstado.ForeColor = System.Drawing.Color.Green; break;
                case "Ocupada": lblEstado.ForeColor = System.Drawing.Color.Red; break;
                case "Mantenimiento": lblEstado.ForeColor = System.Drawing.Color.Orange; break;
                case "Reservada": lblEstado.ForeColor = System.Drawing.Color.Blue; break;
                default: lblEstado.ForeColor = System.Drawing.Color.Gray; break;
            }
        }
        private void HabilitarBotonSegunEstado(string estado)
        {
            btnCheckIn.Enabled  = false;
            btnCheckOut.Enabled = false;
            btnReservar.Enabled = false;
            btnLimpiar.Enabled  = false;

            switch (estado)
            {
                case "Disponible": btnCheckIn.Enabled  = true; break;
                case "Ocupada": btnCheckOut.Enabled = true; break;
                case "Reservada": btnCheckIn.Enabled  = true; break;
                case "Mantenimiento": btnLimpiar.Enabled  = true; break;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string accion = cboAccion.SelectedItem?.ToString() ?? "";
            string mensaje;

            switch (accion)
            {
                case "Check-In": mensaje = "¿Confirma el ingreso del huésped?"; break;
                case "Check-Out": mensaje = "¿Confirma la salida? Se generará factura."; break;
                case "Reservar": mensaje = "¿Desea reservar esta habitación?"; break;
                case "Limpiar": mensaje = "¿Marcar la habitación en mantenimiento?"; break;
                default: mensaje = "¿Confirma esta acción?"; break;
            }

            MessageBox.Show(mensaje, "Confirmar acción",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            try
            {
                var hab = new Habitacion
                {
                    Numero = int.Parse(txtBuscar.Text),
                    Tipo   = cboTipo.SelectedItem?.ToString() ?? "",
                    Estado = lblEstado.Text,
                    Piso   = 3
                };

                reservaService.GuardarHabitacion(hab);
                MessageBox.Show("Habitación guardada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (HabitacionOcupadaException ex)
            {
                MessageBox.Show($"La habitación {ex.NumeroHabitacion} está ocupada.",
                    "Habitación ocupada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void btnReservar_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {

        }

        private void lstHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

