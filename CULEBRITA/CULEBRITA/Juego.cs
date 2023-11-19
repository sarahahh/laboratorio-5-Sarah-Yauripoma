using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CULEBRITA
{
    public class Juego
    {
        // Variable estática
        private static Juego instancia;

        // Arreglo de Jugador para almacenar los jugadores, definicion variable
        public Jugador[] jugador;
        int cantJuga;

        private Juego()
        {
            // Inicializa el arreglo de jugadores en 5 
            jugador = new Jugador[5];
            cantJuga = 0;
        }

        // Método estático que devuelve la instancia única de la clase Juego
        public static Juego obtenerInstancia()
        {
            if(instancia == null)
            {
                instancia = new Juego();
            }
            return instancia;
        }


        public void agregarJugador(string nombre, int puntaje, DateTime fecha)
        {
            if (cantJuga == 4)
            {
                //Verifica si hay 5 jugadores, se eliminara al peor y se añade uno nuevo
                for (int i = 0; i < 5; i++)
                {
                    // Desplaza los jugadores con puntajes más bajos para hacer espacio para el nuevo jugador
                    if (jugador[i].puntaje < puntaje)
                    {
                        for (int j = 4; j > i; j--)
                        {
                            jugador[j] = jugador[j - 1];
                        }
                        // Agrega al nuevo jugador en la posición correspondiente
                        jugador[i] = new Jugador(nombre, fecha, puntaje);
                        i = 5;
                    }
                }
            }
            else
            {
                //Verifica si no hay 5 jugadores, se agrega uno nuevo y se reorganiza 
                jugador[cantJuga] = new Jugador(nombre, fecha, puntaje);
                int index = cantJuga;

                // Realiza una reorganización para mantener el orden descendente por puntaje
                while (index > 0 && jugador[index].puntaje > jugador[index - 1].puntaje)
                {
                    Jugador temp = jugador[index];
                    jugador[index] = jugador[index - 1];
                    jugador[index - 1] = temp;

                    index--;
                }
                cantJuga++;
            }
        }

        public void guardarPuntos(int x)
        {
            // Actualiza el puntaje del último jugador (el que acaba de jugar)
            jugador[cantJuga - 1].puntaje = x;
        }
    }
}
