using DSOO_clubdeportivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSOO_clubdeportivo
{
	internal class ClubDeportivo
	{
		private List<Socio> socios;
		private List<Actividad> actividades;
		private int maxInsPorSocio = 3;

		// Constructor
        public ClubDeportivo()
		{
			this.socios = new List<Socio>();
			this.actividades = new List<Actividad>();
		}

        // Buscar un socio por su dni
        public Socio BuscarSocioDni(string dni)
        {
            return socios.FirstOrDefault(socio => socio.dni.Equals(dni, StringComparison.OrdinalIgnoreCase));
        }

        // Mostrar un socio por idSocio
        public Socio BuscarSocio(int idSocio)
        {
            return socios.FirstOrDefault(socio => socio.idSocio == idSocio);
        }

        // Registrar un nuevo socio
        public string altaSocio(string nombre, string apellido, string dni, string tel, string email)
		{
			// Verificar si el socio ya existe
			if (BuscarSocioDni(dni) != null)
			{
				return "SOCIO YA EXISTE";
			}

			List<Actividad> actividadesInscriptas = new List<Actividad>();

			Socio nuevoSocio = new Socio(nombre, apellido, dni, tel, email, actividadesInscriptas);
			socios.Add(nuevoSocio);

			return "SOCIO REGISTRADO EXITOSAMENTE";
		}

		// Buscar una actividad por nombre
		public Actividad BuscarActividadPorNombre(string nombreActividad)
		{
			return actividades.FirstOrDefault(actividad => actividad.nombreActividad.Equals(nombreActividad, StringComparison.OrdinalIgnoreCase));
		}

		// Agregar una actividad al club
		public string AgregarActividad(int idActividad, string nombreActividad, TimeSpan horarioActividad, List<DayOfWeek> diasActividad, int duracionMinutos, int maxParticipantes)
		{
			// Verificar si ya existe una actividad con el mismo ID
			if (BuscarActividadPorNombre(nombreActividad) != null)
			{
				return "ACTIVIDAD YA EXISTE";
			}

			Actividad nuevaActividad = new Actividad(idActividad, nombreActividad, horarioActividad, diasActividad, duracionMinutos, maxParticipantes);
			actividades.Add(nuevaActividad);
			return "ACTIVIDAD REGISTRADA EXITOSAMENTE";
		}

		// Inscribir a un socio en una actividad
		public string InscribirEnActividad(string nombreActividad, int idSocio)
		{
			Socio socio = BuscarSocio(idSocio);
			if (socio == null)
			{
				return "SOCIO INEXISTENTE";
			}

			if (socio.actividadesInscriptas.Count >= maxInsPorSocio)
			{
				return "TOPE DE ACTIVIDADES ALCANZADO";
			}

			Actividad actividad = BuscarActividadPorNombre(nombreActividad);
			if (actividad == null)
			{
				return "ACTIVIDAD INEXISTENTE";
			}

			if (!actividad.VerificarDisponibilidad())
			{
				return "NO HAY CUPOS DISPONIBLES";
			}

			// Inscribir al socio en la actividad
			actividad.RegistrarInscripcionSocio(socio);
			socio.actividadesInscriptas.Add(actividad);

			return "INSCRIPCIÓN EXITOSA";
		}

        // Listar todos los socios
        public List<string> ListarSocios()
        {
            List<string> detallesSocios = new List<string>();
            foreach (var socio in socios)
            {
                detallesSocios.Add(socio.ToString());
            }
            return detallesSocios;
        }

        // Listar todas las actividades
        public List<string> ListarActividades()
        {
            List<string> detallesActividades = new List<string>();
            foreach (var actividad in actividades)
            {
                detallesActividades.Add(actividad.ToString());
            }
            return detallesActividades;
        }

		// Listar socios inscriptos en una determinada actividad
        public List<string> ListarSociosInscriptosEnActividad(string nombreActividad)
        {
            Actividad actividad = BuscarActividadPorNombre(nombreActividad);
            List<string> detallesSociosInscriptos = new List<string>();

            if (actividad == null)
            {
                return new List<string> { "ACTIVIDAD NO ENCONTRADA" };
            }
			         
            foreach (var socio in socios)
            {
                if (socio.actividadesInscriptas.Contains(actividad))
                {
                    detallesSociosInscriptos.Add($"ID: {socio.idSocio}, Nombre: {socio.nombre} {socio.apellido}");
                }
            }

            if (detallesSociosInscriptos.Count == 0)
            {
                detallesSociosInscriptos.Add("* ¡NO HAY SOCIOS INSCRIPTOS EN ESTA ACTIVIDAD! *");
            }

            return detallesSociosInscriptos;
        }


    }
}

