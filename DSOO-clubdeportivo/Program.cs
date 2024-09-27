using DSOO_clubdeportivo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace ClubDeportivoApp
{
    // Programa principal para pruebas
    class Program
    {
        static void Main(string[] args)
        {
            ClubDeportivo registroClub = new ClubDeportivo();

            // Precarga de actividades
            registroClub.AgregarActividad(1, "FUTBOL", new TimeSpan(18, 0, 0), new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Wednesday }, 90, 20);
            registroClub.AgregarActividad(2, "NATACION", new TimeSpan(17, 0, 0), new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Thursday }, 45, 10);
            registroClub.AgregarActividad(3, "TENIS", new TimeSpan(19, 0, 0), new List<DayOfWeek> { DayOfWeek.Friday }, 45, 8);
            registroClub.AgregarActividad(4, "KARATE", new TimeSpan(9, 30, 0), new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Thursday }, 60, 12);
            
            // Precarga de socios
            registroClub.altaSocio("Juan", "Pérez", "12345678", 123456789, "juanperez@gmail.com");
            registroClub.altaSocio("Ana", "Gómez", "87654321", 987654321, "anagomez@gmail.com");
            registroClub.altaSocio("Julieta", "López", "26478541", 223469854, "julietalopez@gmail.com");
            registroClub.altaSocio("Facundo", "Martínez", "33697458", 115258525, "facundomartinez@gmail.com");
           

            // Menú de consola
            bool continuar = true;

            Console.WriteLine("*-------------------------------------*");
            Console.WriteLine("|       *    Club Deportivo     *     |");
            Console.WriteLine("|_____________________________________|");
            Console.WriteLine("|         Sistema de Registro         |");
            Console.WriteLine("*-------------------------------------*");

            while (continuar)
            {
                Console.WriteLine("\n   ---------------------------");
                Console.WriteLine("   #  SELECCIONE UNA OPCIÓN  #");
                Console.WriteLine("   ___________________________\n");
                Console.WriteLine("1. Registrar un socio");
                Console.WriteLine("2. Inscribir socio en actividad");
                Console.WriteLine("3. Listar todas los socios");
                Console.WriteLine("4. Listar todas las actividades");
                Console.WriteLine("5. Actividades registradas por socio");
                Console.WriteLine("6. Listar socios inscritos en una actividad");
                Console.WriteLine("7. Salir\n");
                Console.Write("Opción --> ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarSocio(registroClub);
                        break;
                    case "2":
                        InscribirSocioEnActividad(registroClub);
                        break;
                    case "3":
                        MostrarSocios(registroClub);
                        break;
                    case "4":
                        MostrarActividades(registroClub);
                        break;
                    case "5":
                        ListarActividadesPorSocio(registroClub);
                        break;
                    case "6":
                        ListarSociosInscriptosEnActividad(registroClub);
                        break;
                    case "7":
                        continuar = false;
                        Console.WriteLine("\n*-------------------------------------*");
                        Console.WriteLine("|       Saliendo del sistema...       |");
                        Console.WriteLine("*-------------------------------------*\n");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            }
        }

        // Solicitar datos y dar de alta al socio
        static void RegistrarSocio(ClubDeportivo socio)
        {
            Console.WriteLine("\n*-------------------------------------*");
            Console.WriteLine("|      Ingrese los datos del socio    |");
            Console.WriteLine("*-------------------------------------*\n");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();
            Console.Write("DNI: ");
            string dni = Console.ReadLine();
            Console.Write("Teléfono: ");
            int telefono = int.Parse(Console.ReadLine());
            Console.Write("Email: ");
            string email = Console.ReadLine();
     
            string resultadoAlta = socio.altaSocio(nombre, apellido, dni, telefono, email);
            Console.WriteLine(resultadoAlta); 
        }

        // Inscribir a un socio por idSocio en una actividad 
        static void InscribirSocioEnActividad(ClubDeportivo registro)
        {
            Console.WriteLine("\n*-------------------------------------*");
            Console.WriteLine("|       Inscripción a actividad       |");
            Console.WriteLine("*-------------------------------------*\n");
            Console.Write("Nombre de la actividad: ");
            string nombreActividad = Console.ReadLine().ToUpper();
            Console.Write("Número de identificación del socio: ");
            int idSocio = int.Parse(Console.ReadLine());

            string resultadoInscripcion = registro.InscribirEnActividad(nombreActividad, idSocio);
            Console.WriteLine(resultadoInscripcion); 
        }

        // Mostrar listado de socios registrados en el club
        static void MostrarSocios(ClubDeportivo registro)
        {
            Console.WriteLine("\n*-------------------------------------*");
            Console.WriteLine("|           Socios Registrados        |");
            Console.WriteLine("*-------------------------------------*\n");
            List<string> sociosRegistrados = registro.ListarSocios();
            foreach (var detalle in sociosRegistrados)
            {
                Console.WriteLine(detalle);
            }
        }

        // Mostrar listado de actividades disponibles
        static void MostrarActividades(ClubDeportivo registro)
        {
            Console.WriteLine("\n*-------------------------------------*");
            Console.WriteLine("|       Actividades disponibles       |");
            Console.WriteLine("*-------------------------------------*\n");
            List<string> actividadesDisponibles = registro.ListarActividades();
            foreach (var detalle in actividadesDisponibles)
            {
                Console.WriteLine(detalle);
            }
        }

    
        // Mostrar listado de actividades en las que está inscrito un socio
        static void ListarActividadesPorSocio(ClubDeportivo registro)
        {
            Console.WriteLine("\n*-------------------------------------*");
            Console.WriteLine("|       Actividades Inscriptas        |");
            Console.WriteLine("*-------------------------------------*\n");
            Console.Write("Ingrese el ID del socio: ");
            int idSocio = Convert.ToInt32(Console.ReadLine());

            Socio socio = registro.BuscarSocio(idSocio);

            if (socio != null)
            {
                List<string> actividades = socio.ListarActividadesInscriptas();

                int cantActividades = actividades.Count;

                Console.WriteLine($"\n  El socio {socio.nombre} {socio.apellido} esta inscripto en {cantActividades} actividades.");

                if (cantActividades > 0)
                {
                    Console.WriteLine($"\nListado de Actividades\n");
                    int cont = 0;
                    foreach (var actividad in actividades)
                    {
                        cont++;
                        Console.WriteLine($"  {cont}. {actividad}");
                    }
                }
                else
                {
                    Console.WriteLine("\n * ¡Este socio no registra inscripciones en actividades! *");
                }
            }
            else
            {
                Console.WriteLine("\n * ¡No se encontró un socio con ese ID! *");
            }
        }


        // Mostrar listado de socios inscritos en una actividad
        static void ListarSociosInscriptosEnActividad(ClubDeportivo registro)
        {
            Console.WriteLine("\n*-------------------------------------*");
            Console.WriteLine("|       Listado de participantes      |");
            Console.WriteLine("*-------------------------------------*\n");
            Console.Write("Ingrese el nombre de la actividad: ");
            string nombreActividad = Console.ReadLine();

            List<string> sociosInscriptos = registro.ListarSociosInscriptosEnActividad(nombreActividad);
            int cantInscriptos = sociosInscriptos.Count;

            Console.WriteLine($"\n  Cantidad de Socios inscritos en {nombreActividad}: {cantInscriptos}\n");
            Console.WriteLine($"\n * Listado de Socios *\n");

            foreach (var detalle in sociosInscriptos)
            {
                Console.WriteLine($"  {detalle}");
            }
        }


    }
    
}
