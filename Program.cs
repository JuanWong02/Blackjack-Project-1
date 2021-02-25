using System;

namespace Blackjack
{
    class Blackjack
    {
        /// <summary>
        /// Crea las variables globales
        /// </summary>

        //1- declarar variables globales
        static string[] cartasjugador = new string[12]; //crea string de las cartas del jugador el 12 no se incluye por lo cual tiene 11
        static string pedirOpasar = ""; // crea una variable string para preguntar si pone o pasa
        static int total = 0, count = 1, totalCasa = 0; //crea tres variables tipo entero : total para el total de valores, count para conteo y totalcasa  
        static Random cartaAleatoria = new Random(); //para tener valores random de las cartas


        /// <summary>
        /// Crea un metodo para repartir cartas aleatorias al jugador
        /// </summary>
        /// <returns>carta = una carta aleatoria entre las opciones y suma un numero al total del jugador</returns>

        //2- Crear parte para repartir cartas
        static string Repartidor()
        {
            string carta = "";  //lo que se va a regresar al jugador
            int cartas = cartaAleatoria.Next(1, 14); //numero aleatorio entre 1 y 14 , despues se hace switch dependiendo del resultado, agrega valor a carta y tambien a total
            switch (cartas)
            {
                case 1:
                    carta = "Dos"; total += 2;
                    break;

                case 2:
                    carta = "Tres"; total += 3;
                    break;

                case 3:
                    carta = "Cuatro"; total += 4;
                    break;

                case 4:
                    carta = "Cinco"; total += 5;
                    break;

                case 5:
                    carta = "Seis"; total += 6;
                    break;

                case 6:
                    carta = "Siete"; total += 7;
                    break;

                case 7:
                    carta = "Ocho"; total += 8;
                    break;

                case 8:
                    carta = "Nueve"; total += 9;
                    break;

                case 9:
                    carta = "Diez"; total += 10;
                    break;

                case 10:
                    carta = "Jack"; total += 10;
                    break;

                case 11:
                    carta = "Queen"; total += 10;
                    break;

                case 12:
                    carta = "King"; total += 10;
                    break;

                case 13:
                    carta = "As"; total += 11;
                    break;

                default:
                    carta = "2"; total += 2;
                    break;
            }
            return carta;
        }



        //  3- crear inicio del juego
        /// <summary>
        /// Crea metodo para empezar el juego, pregunta si el jugador quiere pedir o pasar, ademas de asignarle valor a la casa
        /// </summary>

        static void Empezar()
        {
            totalCasa = cartaAleatoria.Next(17, 27);// numero aleatorio entre 1 y 26 para el numero de la casa
            do
            {
                Console.WriteLine("Bienvenido a BlackJack! Tus Cartas son " + ".\nTe gustaria pedir o pasar?"); //pregunta si quiere pedir o pasar
                pedirOpasar = Console.ReadLine().ToLower();
            } while (!pedirOpasar.Equals("pedir") && !pedirOpasar.Equals("pasar")); // le dice al usuario que numeros le tocaron, despues se le pregunta si quiere poner o pasar. Hace esto hasta que entrega un valor correcto.

        }


        /// <summary>
        /// crea el metodo pedir, si el usuario elige tomar una carta
        /// </summary>

        static void Pedir()
        {
            count += 1; // añade uno al conteo, count es donde obtenemos el numero para indexar las cartas del jugador
            cartasjugador[count] = Repartidor(); // repartir una carta nueva al jugador


            Console.WriteLine("\nTe han dado " + cartasjugador[count] + ".\nTu nuevo total es " + total + "."); // le dice al jugador que le tocó
            if (total.Equals(21)) // si el total es 21
            {
                Console.WriteLine("\nFelicidades! Has Ganado! El total de la Casa era " + totalCasa + ".\nTe gustaria jugar de nuevo? s/n");
                JugardeNuevo();
            }
            else if (total > 21 && totalCasa <= 21) // si el total es mayor a 21
            {
                Console.WriteLine("\nLo siento, Has perdido  El total de la casa era " + totalCasa + ".\nTe gustaria jugar de nuevo? s/n");
                JugardeNuevo();
            }

            else if (total > 21 && totalCasa > 21)
            {
                Empate();
            }
            else// si toco menor a 21
            {
                do
                {
                    Console.WriteLine("\nTe gustaria pedir o pasar?");
                    pedirOpasar = Console.ReadLine().ToLower();
                } while (!pedirOpasar.Equals("pedir") && !pedirOpasar.Equals("pasar")); // pregunt si quiere pedir o pasar, hasta que de una respuesta valida
                Juego(); //llama al metodo de juego
            }

        }

        // Crear El juego en si
        /// <summary>
        /// Verifica la respuesta del jugador si pedir o pasar, ademas que revisa si gano, perdio o empato
        /// </summary>
        static void Juego()
        {
            if (pedirOpasar.Equals("pedir"))  // esto si escoge la opcion pedir
            {
                Pedir(); //Llama al metodo pedir
            }
            else if (pedirOpasar.Equals("pasar")) // si escogen pasar
            {
                if (total > totalCasa && total <= 21) // si el total es mayor que la casa y menor o igual a 21
                {
                    Console.WriteLine("\nFelicidades! Has Ganado! El total de la Casa era " + totalCasa + ".\nTe gustaria jugar de nuevo? s/n"); //le dice al usuario que gano, le dice el total de la casa y pregunta si quiere jugar de nuevo
                    JugardeNuevo(); //llama al metodo jugardenuevo
                }
                else if (total < totalCasa && totalCasa <= 21) // si el total es menor que el de la casa...
                {
                    Console.WriteLine("\nLo siento, Has perdido  El total de la casa era " + totalCasa + ".\nTe gustaria jugar de nuevo? s/n"); //le dice al usuario que perdio y le da el total de la casa, pregunta si quiere jugar de nuevo
                    JugardeNuevo(); //llama al metodo jugardenuevo
                }
                else if (totalCasa > 21 && total <= 21)
                {
                    Console.WriteLine("\nFelicidades! Has Ganado! El total de la Casa era " + totalCasa + ", Lo cual se pasa de 21" + ".\nTe gustaria jugar de nuevo? s/n");
                    JugardeNuevo();
                }
                else
                {
                    Empate();
                }
            }

        }

        /// <summary>
        /// crea metodo empate y dependiendo de la condicion que se cumpla arroja un mensaje distinto
        /// </summary>
        static void Empate()
        {
            if (total > 21 && totalCasa > 21)
            {
                Console.WriteLine("\nEs un empate!  El total de la casa es " + totalCasa + ", Ambos se pasan de 21" + ".\nTe gustaria jugar de nuevo? s/n");
                JugardeNuevo();
            }
            else if (total == totalCasa)
            {
                Console.WriteLine("\nEs un empate!  El total de la casa tambien es " + totalCasa + ", Ambos totales son iguales" + ".\nTe gustaria jugar de nuevo? s/n");
                JugardeNuevo();
            }
        }

        /// <summary>
        /// Metodo que reinicia valores o cierra el juego segun se elija
        /// </summary>
        static void JugardeNuevo()
        {
            string jugardeNuevo = ""; // crea un string para preguntar si juega de nuevo
            do
            {
                jugardeNuevo = Console.ReadLine().ToLower();
            } while (!jugardeNuevo.Equals("s") && !jugardeNuevo.Equals("n")); // se repite hasta que se ponga s o n al preguntar si juega de nuevo

            if (jugardeNuevo.Equals("s")) // si decide jugar d enuevo
            {
                Console.WriteLine("\nPresiona enter para reiniciar el juego!");
                Console.ReadLine();
                Console.Clear(); // borra la consola
                totalCasa = 0; // resetea los valores de la casa
                count = 1; // resetea el conteo
                total = 0; // resetea nuestro total
                Empezar(); // llama el metodo empezar para reiniciar el juego
            }
            else if (jugardeNuevo.Equals("n")) // si oprime que no quiere jugar de nuevo
            {
                Console.WriteLine("\nPresiona enter para cerrar el juego.");
                Console.ReadLine();
                Environment.Exit(0); //cierra la consola 
            }
        }


        static void Main(string[] args)
        {





            //TODO: Metodo de empate, donde se pongan los casos para considerar empate




            //TODO: metodo para jugar de nuevo, aqui se resetean todos los valores y tambien se puede cerrar el juego



        }
    }
}