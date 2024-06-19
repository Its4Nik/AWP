using System;

namespace christmasTree
{
    class christmasTree
    {
        public static void Main()
        {
            string again = "n";
            do
            {
                int height = 0;
                string variante = "";
                again = "n";
                // Console.Clear();

                Console.WriteLine("-- Weihnachtsbaum --");
                Console.Write("Welche Variante soll gezeichnet werden? <1-4>: ");
                variante = Console.ReadLine();

                switch (variante)
                {
                    case "1":
                        Console.Write("Hoehe des Baumes eingeben <5-40>: ");
                        height = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        variante1(height); break;
                    case "2":
                        Console.Write("Hoehe des Baumes eingeben <5-40>: ");
                        height = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        variante2(height); break;
                    case "3":
                        Console.Write("Hoehe des Baumes eingeben <5-40>: ");
                        height = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        variante3(height); break;
                    case "4":
                        Console.Write("Hoehe des Baumes eingeben <5-40>: ");
                        height = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        variante4(height); break;
                    default:
                        Console.WriteLine("Variante existiert nicht!");
                        break;
                }

                Console.Write("\nNoch ein Baum? <j/n>: ");
                again = Console.ReadLine();
            }while(again == "j" || again == "J");
        }

        public static void variante1(int height)
        {
            for(int i = 0;i < height; i++)
            {
                Console.WriteLine("X");
            }
        }

        public static void variante2(int height)
        {
            for(int i = 0; i < height;i++)
            {
                for(int y = 0; y <  i + 1; y++)
                {
                    Console.Write("X ");
                }
                Console.WriteLine();
            }
        }

        public static void variante3(int height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height - i; j++)
                {
                    Console.Write("  ");
                }

                for (int k = 0; k < 2 * i + 1; k++)
                {
                    Console.Write("X ");
                }

                Console.WriteLine();
            }
        }

        public static void variante4(int height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height - i; j++)
                {
                    Console.Write("  ");
                }

                for (int k = 0; k < 2 * i + 1; k++)
                {
                    Console.Write("X ");
                }

                Console.WriteLine();
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine("H");
            }
        }
    }
}
