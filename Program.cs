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

        static void Main(string[] args)
        {





            //TODO: Metodo de empate, donde se pongan los casos para considerar empate



            //TODO: Metodo pedir , cuando el jugador decida pedir cartas, que le de una y verficar si con esa carta gano, perdio o empato, o si quiere seguir pidiendo


            //TODO: metodo para jugar de nuevo, aqui se resetean todos los valores y tambien se puede cerrar el juego



        }
    }
}