using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CULEBRITA
{
    public partial class Form3 : Form
    {
        // Instancia de la clase Juego
        Juego juego;

        // Form historial de jugadores
        public Form3()
        {
            InitializeComponent();

            // Obtiene la instancia del juego
            this.juego = Juego.obtenerInstancia();

            // Llama al método para mostrar la información de los jugadores
            mostrarNombre();
        }

        // Muestra el nombre, la fecha y el puntaje de los jugadores
        public void mostrarNombre()
        {
            if (juego.jugador[0] != null)
            {
                nombre1.Text = juego.jugador[0].nombre;
                fecha1.Text = juego.jugador[0].fecha.ToString();
                puntaje1.Text = juego.jugador[0].puntaje.ToString();
            }
            if (juego.jugador[1] != null)
            {
                nombre2.Text = juego.jugador[1].nombre;
                fecha2.Text = juego.jugador[1].fecha.ToString();
                puntaje2.Text = juego.jugador[1].puntaje.ToString();
            }
            if (juego.jugador[2] != null)
            {
                nombre3.Text = juego.jugador[2].nombre;
                fecha3.Text = juego.jugador[2].fecha.ToString();
                puntaje3.Text = juego.jugador[2].puntaje.ToString();
            }
            if (juego.jugador[3] != null)
            {
                nombre4.Text = juego.jugador[3].nombre;
                fecha4.Text = juego.jugador[3].fecha.ToString();
                puntaje4.Text = juego.jugador[3].puntaje.ToString();
            }
            if (juego.jugador[4] != null)
            {
                nombre5.Text = juego.jugador[4].nombre;
                fecha5.Text = juego.jugador[4].fecha.ToString();
                puntaje5.Text = juego.jugador[4].puntaje.ToString();
            }
        }

    }
}
