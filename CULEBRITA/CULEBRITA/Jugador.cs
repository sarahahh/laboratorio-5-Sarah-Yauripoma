using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CULEBRITA
{
    public class Jugador
    {
        // Propiedad para almacenar el puntaje, nombre y fecha del jugador
        public int puntaje { get; set; }
        public String nombre { get; set; }
        public DateTime fecha { get; set; }

        // Constructor de la clase Jugador que inicializa sus propiedades
        public Jugador(String nombre, DateTime fecha, int puntaje)
        {
            this.nombre = nombre;
            this.fecha = fecha;
            this.puntaje = puntaje;
        }
    }
}
