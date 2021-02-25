using System;

namespace Blackjack
{
    class Blackjack
    {
         /// <summary>
          /// Crea las variables globales
          /// </summary>
          /// <returns>cartasjugador se le asigna valor de 11, pediropasar vacio, total = 0, count = 1, totalcasa = 0, cartaAleatoria = random </returns>
        //1- declarar variables globales
        static string[] cartasjugador = new string[12]; //crea string de las cartas del jugador el 12 no se incluye por lo cual tiene 11
        static string pedirOpasar = ""; // crea una variable string para preguntar si pone o pasa
        static int total = 0, count = 1, totalCasa = 0; //crea tres variables tipo entero : total para el total de valores, count para conteo y totalcasa  
        static Random cartaAleatoria = new Random(); //para tener valores random de las cartas

        static void Main(string[] args)
        {
            //TODO: Crear metodo que genere las cartas aleatoriamente para el jugador








            //TODO: Crear metodo que inicie el juego y pregunte al jugador si quiere pedir o pasar






            //TODO: Metodo del juego en si, donde estara opciones de pedir o pasar y aqui si gana, pierde o empata




            //TODO: Metodo de empate, donde se pongan los casos para considerar empate



            //TODO: Metodo pedir , cuando el jugador decida pedir cartas, que le de una y verficar si con esa carta gano, perdio o empato, o si quiere seguir pidiendo


            //TODO: metodo para jugar de nuevo, aqui se resetean todos los valores y tambien se puede cerrar el juego



        }
    }
}
