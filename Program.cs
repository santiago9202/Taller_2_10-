using System;

namespace Taller_2_10_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] tablero = new int[5, 5]; // Crear una matriz 5x5
            int posX = 0, posY = 0; // Posición inicial en [0,0]
            int puntaje = 0;

            // Inicializamos el tablero con números aleatorios entre 1 y 9
            InicializarTablero(tablero);

            // Bucle principal del juego
            while (true)
            {
                MostrarTablero(tablero, puntaje);
                var tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.Escape)
                {
                    break; // Salir del juego
                }

                (posX, posY, puntaje) = MoverJugador(tablero, posX, posY, puntaje, tecla);
            }
        }

        // Método para inicializar el tablero con números aleatorios
        static void InicializarTablero(int[,] tablero)
        {
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        tablero[i, j] = 0; // La posición inicial debe ser 0
                    }
                    else
                    {
                        tablero[i, j] = rand.Next(1, 10);
                    }
                }
            }
        }

        // Método para mostrar el tablero y el puntaje
        static void MostrarTablero(int[,] tablero, int puntaje)
        {
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(tablero[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Puntaje: " + puntaje);
            Console.WriteLine("Mover: W (Arriba), A (Izquierda), S (Abajo), D (Derecha), Esc (Salir)");
        }

        // Método para mover al jugador y actualizar el tablero y el puntaje
        static (int, int, int) MoverJugador(int[,] tablero, int posX, int posY, int puntaje, ConsoleKey tecla)
        {
            int nuevaPosX = posX, nuevaPosY = posY;

            switch (tecla)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    nuevaPosX = posX - 1;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    nuevaPosY = posY - 1;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    nuevaPosX = posX + 1;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    nuevaPosY = posY + 1;
                    break;
            }

            // Verificar si el movimiento está dentro de los límites del tablero con un switch
            bool movimientoValido = false;

            switch (tecla)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (nuevaPosX >= 0)
                    {
                        movimientoValido = true;
                    }
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (nuevaPosY >= 0)
                    {
                        movimientoValido = true;
                    }
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (nuevaPosX < 5)
                    {
                        movimientoValido = true;
                    }
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (nuevaPosY < 5)
                    {
                        movimientoValido = true;
                    }
                    break;
            }

            if (movimientoValido)
            {
                puntaje = ActualizarPuntaje(tablero, nuevaPosX, nuevaPosY, puntaje);
                // Mover el "0"
                tablero[posX, posY] = 0;
                posX = nuevaPosX;
                posY = nuevaPosY;
                tablero[posX, posY] = 0;
            }

            return (posX, posY, puntaje);
        }

        // Método para actualizar el puntaje
        static int ActualizarPuntaje(int[,] tablero, int nuevaPosX, int nuevaPosY, int puntaje)
        {
            puntaje += tablero[nuevaPosX, nuevaPosY];
            return puntaje;
        }
    }
}

