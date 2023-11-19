using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CULEBRITA
{
    // Form logica del juego snake
    public partial class Form2 : Form
    {
        // Declaración de una variable de tipo Juego
        Juego juego;

        // Creacion de lista, variable para controlar tamaño de la pieza y el tiempo
        List<PictureBox> Lista = new List<PictureBox>();
        int tamañoPieza = 26;
        int tiempo = 10;

        // Instancia de PictureBox para representar la comida
        PictureBox Comida = new PictureBox();

        // Definicion de variable, direccion de la culebra
        String Direccion = "right";

        public Form2()
        {
            InitializeComponent();

            // Llama al método iniciarJuego() para comenzar el juego
            iniciarJuego();

            // Inicializa la variable 'juego' obteniendo una instancia de la clase Juego
            this.juego = Juego.obtenerInstancia();
        }

        // Metodo inicializar tiempo, direccion y timer
        public void iniciarJuego()
        {
            // Reinicia el tiempo a 10, establece la dirección inicial de la culebra a la derecha e intervalo del temporizador
            tiempo = 10;
            Direccion = "right";
            timer1.Interval = 200;

            // Reinicia el valor del label1(puntaje) a "0"
            label1.Text = "0";

            // Creacion de una nueva lista de PictureBox
            Lista = new List<PictureBox>();

            // Pieza inicial del juego, llama a la funcion crearCulebra y crearComida
            for (int s = 2; 0 <= s; s--)
            {
                crearCulebra(Lista, this, (s * tamañoPieza) + 70, 80);
            }
            crearComida();
        }

        // Funcion mostrar o generar cuerpo culebra
        public void crearCulebra(List<PictureBox> listaPelota, Form formulario, int posicionX, int posicionY)
        {
            // Creacion de un nuevo PictureBox y asignaciones
            PictureBox pb = new PictureBox();
            pb.Location = new Point(posicionX, posicionY);

            // Asigna una imagen al PictureBox
            pb.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("Cuerpo");

            pb.BackColor = Color.Transparent;
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
            listaPelota.Add(pb);
            formulario.Controls.Add(pb);
        }

        // Funcion crear comida de la culebra, inicializa numero random 
        private void crearComida()
        {
            // Genera objeto y coordenadas random
            Random rnd = new Random();
            int enteroX = rnd.Next(1, this.Width - tamañoPieza - 10);
            int enteroY = rnd.Next(1, this.Height - tamañoPieza - 40);

            // Creacion de un nuevo PictureBox y asignaciones
            PictureBox pb = new PictureBox();
            pb.Location = new Point(enteroX, enteroY);

            // Asigna una imagen al PictureBox
            pb.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("Comida");

            pb.BackColor = Color.Transparent;
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
            Comida = pb;
            this.Controls.Add(pb);
        }

        // Funcion terminar juego
        public void terminarJuego()
        {
            foreach (PictureBox Culebra in Lista)
            {
                // Elimina cada PictureBox de la lista y 'Comida' del formulario
                this.Controls.Remove(Culebra);
                this.Controls.Remove(Comida);
                juego.guardarPuntos(int.Parse(label1.Text));

                // Cierra el formulario actual
                Close();
            } 
        }

        // Funcion mover pieza
        private void moverPieza(object sender, KeyEventArgs e)
        {
            // Determina la dirección de la pieza en función de la tecla presionada
            Direccion = ((e.KeyCode & Keys.Up) == Keys.Up) ? "up" : Direccion;
            Direccion = ((e.KeyCode & Keys.Down) == Keys.Down) ? "down" : Direccion;
            Direccion = ((e.KeyCode & Keys.Left) == Keys.Left) ? "left" : Direccion;
            Direccion = ((e.KeyCode & Keys.Right) == Keys.Right) ? "right" : Direccion;
        }

        // Funcion Timer
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // Cambios y movimientos de culebra
            int nx = Lista[0].Location.X;
            int ny = Lista[0].Location.Y;

            // Cabeza de la culebra
            Lista[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("Cabeza");

                for (int i = Lista.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        // Movimiento de la cabeza de la serpiente
                        if (Direccion == "right") nx = nx + tamañoPieza;
                        else if (Direccion == "left") nx = nx - tamañoPieza;
                        else if (Direccion == "up") ny = ny - tamañoPieza;
                        else if (Direccion == "down") ny = ny + tamañoPieza;

                        // Establece la imagen y posicion de la cabeza de la serpiente
                        Lista[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("Cabeza");
                        Lista[0].Location = new Point(nx, ny);
                    }
                    else
                    {
                        // Actualiza la posición de las partes del cuerpo de la serpiente
                        Lista[i].Location = new Point((Lista[i - 1].Location.X), (Lista[i].Location.Y));
                        Lista[i].Location = new Point(Lista[i].Location.X, Lista[i - 1].Location.Y);
                    }
                }


                // Tamaño de culebra, incremento de piezas y tiempo
                for (int numPiezas = 1; numPiezas < Lista.Count; numPiezas++)
                {
                    // Remueve comida e incrementa el tiempo
                    if (Lista[numPiezas].Bounds.IntersectsWith(Comida.Bounds))
                    {
                        this.Controls.Remove(Comida);
                        tiempo = Convert.ToInt32(timer1.Interval);

                        // Valida si tiempo menor entonces disminuye el tiempo
                        if (tiempo > 10)
                        {
                            timer1.Interval = tiempo - 10;
                        }
                        label1.Text = (Convert.ToInt32(label1.Text) + 1).ToString();
                        crearComida();
                        crearCulebra(Lista, this, Lista[Lista.Count - 1].Location.X * tamañoPieza, 0);
                    }
                }

                // Choques paredes
                if ((Lista[0].Location.X >= this.Width - 15) || (Lista[0].Location.Y >= this.Height - 50) || (Lista[0].Location.Y < -10) || (Lista[0].Location.X < -30))
                {
                    terminarJuego();
                }

                // Choque culebra
                for (int numPiezas = 1; numPiezas < Lista.Count; numPiezas++)
                {
                    if (Lista[0].Bounds.IntersectsWith(Lista[numPiezas].Bounds))
                    {
                        terminarJuego();
                       
                    }
                }
            }
        }
    }
