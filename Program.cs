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
    }
}


