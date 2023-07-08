using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerExamen
{
    public interface ILibro
    {
        void MostrarInformacion();
        
    }

    public class Libro : ILibro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacion { get; set; }
        public int Precio { get; set; }
        public Boolean DisponibLe { get; set; }

   
        public void MostrarInformacion()
        {
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Año de publicación: {AnoPublicacion}");
            Console.WriteLine($"Precio: {Precio}");
            Console.WriteLine($"Disponible: {DisponibLe}");
        }
    }


    public class Biblioteca
    {
        public List<ILibro> libros;

        public Biblioteca()
        {
            libros = new List<ILibro>();
            libros.Add(new Libro() { Titulo = "El principito", Autor = "Antoine de sait", AnoPublicacion = 1999, Precio = 5000, DisponibLe = true });
            libros.Add(new Libro() { Titulo = "El Ruido y la Furia", Autor = "William Faulkner", AnoPublicacion = 1990, Precio = 10000, DisponibLe = true });
            libros.Add(new Libro() { Titulo = "El Hamlet", Autor = "William Shakespeare", AnoPublicacion = 2000, Precio = 15000, DisponibLe = false });
        }

        public void AgregarLibro(ILibro libro)
        {
            libros.Add(libro);
            Console.WriteLine("Libro agregado exitosamente.");
        }

        public void EliminarLibro(ILibro libro)
        {
            libros.Remove(libro);
            Console.WriteLine("Libro eliminado exitosamente.");
        }

        public void ModificarLibro(ILibro libro, string nuevoTitulo, string nuevoAutor, int nuevoAno, int nuevoPrecio, Boolean nuevoDisponible)
        {
            if (libros.Contains(libro))
            {

                var libroModificado = (Libro)libro;
                libroModificado.Titulo = nuevoTitulo;
                libroModificado.Autor = nuevoAutor;
                libroModificado.AnoPublicacion = nuevoAno;
                libroModificado.Precio = nuevoPrecio;
                libroModificado.DisponibLe = nuevoDisponible;

                Console.WriteLine("Libro modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("El libro no existe en la biblioteca.");
            }
        }

        public void MostrarLibros()
        {
            if (libros.Count > 0)
            {
                Console.WriteLine("Lista de libros en la biblioteca:");
                foreach (var libro in libros)
                {
                    libro.MostrarInformacion();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("La biblioteca está vacía.");
            }
        }
       
        class Program
        {
            static void Main(string[] args)
            {
                Biblioteca biblioteca = new Biblioteca();

                while (true)
                {
                    Console.WriteLine("----- MENÚ -----");
                    Console.WriteLine("1. Agregar libro");
                    Console.WriteLine("2. Eliminar libro");
                    Console.WriteLine("3. Modificar libro");
                    Console.WriteLine("4. Mostrar libros");
                    Console.WriteLine(". Salir");
                    Console.Write("Elija una opción: ");
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            Console.Write("Ingrese el título del libro: ");
                            string titulo = Console.ReadLine();
                            Console.Write("Ingrese el autor del libro: ");
                            string autor = Console.ReadLine();
                            Console.Write("Ingrese el año de publicación del libro: ");
                            int ano = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese el Precio del libro: ");
                            int Precio = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese si esta disponible el libro: ");
                            Boolean Disponible = Boolean.Parse(Console.ReadLine());





                            Libro nuevoLibro = new Libro
                            {
                                Titulo = titulo,
                                Autor = autor,
                                AnoPublicacion = ano,
                                Precio = Precio,
                                DisponibLe = Disponible
                            };

                            biblioteca.AgregarLibro(nuevoLibro);
                            Console.WriteLine();
                            break;

                        case "2":
                            biblioteca.MostrarLibros();
                            Console.Write("Ingrese el número del libro que desea eliminar: ");
                            int indiceEliminar = int.Parse(Console.ReadLine());

                            if (indiceEliminar >= 0 && indiceEliminar < biblioteca.libros.Count)
                            {
                                biblioteca.EliminarLibro(biblioteca.libros[indiceEliminar]);
                            }
                            else
                            {
                                Console.WriteLine("El número de libro no es válido.");
                            }

                            Console.WriteLine();
                            break;

                        case "3":
                            biblioteca.MostrarLibros();
                            Console.Write("Ingrese el número del libro que desea modificar: ");
                            int indiceModificar = int.Parse(Console.ReadLine());

                            if (indiceModificar >= 0 && indiceModificar < biblioteca.libros.Count)
                            {
                                Console.Write("Ingrese el nuevo título del libro: ");
                                string nuevoTitulo = Console.ReadLine();
                                Console.Write("Ingrese el nuevo autor del libro: ");
                                string nuevoAutor = Console.ReadLine();
                                Console.Write("Ingrese el nuevo año de publicación del libro: ");
                                int nuevoAno = int.Parse(Console.ReadLine());
                                Console.Write("Ingrese el Nuevo Precio del libro: ");
                                int nuevoPrecio = int.Parse(Console.ReadLine());
                                Console.Write("Ingrese si el libro esta disponible: ");
                                Boolean nuevoDisponible = Boolean.Parse(Console.ReadLine());


                                biblioteca.ModificarLibro(biblioteca.libros[indiceModificar], nuevoTitulo, nuevoAutor, nuevoAno, nuevoPrecio, nuevoDisponible);
                            }
                            else
                            {
                                Console.WriteLine("El número de libro no es válido.");
                            }

                            Console.WriteLine();
                            break;

                        case "4":
                            biblioteca.MostrarLibros();
                            Console.WriteLine();
                            break;

                        case "5":
                            Console.WriteLine("¡Nos vemos!");
                            return;

                        default:
                            Console.WriteLine("Opción inválida,Ingrese otra opcion");
                            Console.WriteLine();
                            break;
                    }
                }
            }
        }
    }
}