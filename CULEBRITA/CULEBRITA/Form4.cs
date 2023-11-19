using Microsoft.VisualBasic;
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
    // Form que pide informacion del jugador
    public partial class Form4 : Form
    {
        // Definir instancias
        public int puntaje;
        public int label1;
        
        int cantidadJugadores;
        Juego juego;

        public Form4()
        {
            InitializeComponent();

            // Obtiene la instancia del juego
            this.puntaje = label1;
            cantidadJugadores = 0;
            this.juego = Juego.obtenerInstancia();
            
        }

        // Boton jugar, llama al form 2 e inicia el juego del snake
        public void button1_Click(object sender, EventArgs e)
        {
            // Obtener el nombre del jugador, fecha y puntaje
            String nombre = textBox1.Text;
            DateTime fecha = DateTime.Now;
            int puntaje = label1;
            juego.agregarJugador(nombre, puntaje, fecha);

            // Cerrar este formulario
            Close();

            // Abrir el formulario Form2 para jugar
            Form2 form2 = new Form2();
            form2.ShowDialog();
        } 
    }
}

