using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DSOO_clubdeportivo
{
    internal class Actividad
    {
        public int idActividad { get; private set; }
        public string nombreActividad { get; private set; }
        public TimeSpan horarioActividad { get; private set; }
        public List<DayOfWeek> diasActividad { get; private set; }
        public int duracionMinutos { get; private set; }
        public int maxParticipantes { get; private set; }
        public int cantInscriptos { get; private set; }
        public int cuposLibres { get; private set; }
        public List<Socio> sociosInscriptos { get; private set; }

        // Constructor
        public Actividad(int idActividad, string nombreActividad, TimeSpan horarioActividad, List<DayOfWeek> diasActividad, int duracionMinutos, int maxParticipantes)
        {
            this.idActividad = idActividad;
            this.nombreActividad = nombreActividad;
            this.horarioActividad = horarioActividad;
            this.diasActividad = diasActividad;
            this.duracionMinutos = duracionMinutos;
            this.maxParticipantes = maxParticipantes;
            this.cantInscriptos = 0;
            this.cuposLibres = maxParticipantes;
            this.sociosInscriptos = new List<Socio>();
        }

        // Verificar disponibilidad
        public bool VerificarDisponibilidad()
        {
            return cuposLibres > 0;
        }

        // Inscribir a un socio en una actividad
        public void RegistrarInscripcionSocio(Socio socio)
        {
            if (VerificarDisponibilidad())
            {
                sociosInscriptos.Add(socio);
                cantInscriptos++;
                cuposLibres--;
            }
        }

        //// ToString
        //public override string ToString()
        //{
        //    return $" IdActividad: {idActividad}\n  " +
        //            $"Actividad: {nombreActividad}\n  " +
        //            $"Horario: {horarioActividad}\n  " +
        //            $"Días: {string.Join(", ", diasActividad)}\n  " +
        //            $"Duración: {duracionMinutos} minutos\n  " +
        //            $"Cupos Máximos: {maxParticipantes}\n  " +
        //            $"Cupos Libres: {cuposLibres}\n";
        //}


        // Convertir días del ingles al español
        private string ConvertirDiaA_Espanol(DayOfWeek dia)
        {
            switch (dia)
            {
                case DayOfWeek.Monday:
                    return "Lunes";
                case DayOfWeek.Tuesday:
                    return "Martes";
                case DayOfWeek.Wednesday:
                    return "Miércoles";
                case DayOfWeek.Thursday:
                    return "Jueves";
                case DayOfWeek.Friday:
                    return "Viernes";
                case DayOfWeek.Saturday:
                    return "Sábado";
                case DayOfWeek.Sunday:
                    return "Domingo";
                default:
                    return "Día desconocido";
            }
        }

        // ToString 
        public override string ToString()
        {
            // Traducir día al español
            var diasEnEspanol = new List<string>();
            foreach (var dia in diasActividad)
            {
                diasEnEspanol.Add(ConvertirDiaA_Espanol(dia));
            }

            return $" IdActividad: {idActividad}\n  " +
                   $"Actividad: {nombreActividad}\n  " +
                   $"Horario: {horarioActividad}\n  " +
                   $"Días: {string.Join(", ", diasEnEspanol)}\n  " +
                   $"Duración: {duracionMinutos} minutos\n  " +
                   $"Cupos Máximos: {maxParticipantes}\n  " +
                   $"Cupos Libres: {cuposLibres}\n";
        }
    }
}
