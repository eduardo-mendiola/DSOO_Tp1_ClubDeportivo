using System;
using System.Collections.Generic;

namespace DSOO_clubdeportivo
{
    internal class Socio 
    {
        public int idSocio { get; private set; }
        public string nombre { get; private set; }
        public string apellido { get; private set; }
        public string dni { get; private set; }
        public int tel { get; private set; }
        public string email { get; private set; }
        public DateTime fechaRegistro { get; private set; }
        public List<Actividad> actividadesInscriptas { get; private set; }
        private static int contadorIdSocio = 0;

        // Constructor
        public Socio(string nombre, string apellido, string dni, int tel, string email, List<Actividad> actividadesInscriptas)
        {
            this.idSocio = GenerarIdUsuario(); 
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.tel = tel;
            this.email = email;
            this.fechaRegistro = fechaRegistro;
            this.actividadesInscriptas = actividadesInscriptas;
        }

        // Generar un nuevo IdUsuario
        private int GenerarIdUsuario()
        {
            return ++contadorIdSocio;
        }

        // Listar todas las actividades de un socio
        public List<string> ListarActividadesInscriptas()
        {
            List<string> detallesActividadesInscriptas = new List<string>();

            foreach (var actividad in actividadesInscriptas)
            {
                detallesActividadesInscriptas.Add(actividad.nombreActividad);
            }

            return detallesActividadesInscriptas;
        }

        // ToString
        public override string ToString()
        {
            return $" IdSocio: {idSocio}\n  " +
                    $"Nombre: {nombre}\n  " +
                    $"Apellido: {apellido}\n  " +
                    $"DNI: {dni}\n  " +
                    $"Tel: {tel}\n  " +
                    $"Email: {email}\n";
        }
    }
}
