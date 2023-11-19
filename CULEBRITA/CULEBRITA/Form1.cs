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
    // Form de menu para iniciar juego
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Boton para iniciar juego, llama al form 4 que recibe nombre de jugador
        private void button1_Click(object sender, EventArgs e)
        {
            // Crea una instancia del Form4 y lo muestra como un cuadro de diálogo
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        // Boton para ver historial de mejores puntajes de jugadores
        private void button2_Click(object sender, EventArgs e)
        {
            // Crea una instancia del Form3 y lo muestra como un cuadro de diálogo
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
