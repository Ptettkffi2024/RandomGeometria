﻿﻿namespace Randomgeometria
{
    class Program
    {
        static void Main(string[] args)
        {
            // Geometria típusának bekérése
            Console.WriteLine("Enter geometry type (point, line, polygon):");
            string? geometryType = Console.ReadLine();

            // Ellenőrzöm, hogy a bemenet nem üres vagy hibás 
            if (string.IsNullOrEmpty(geometryType))
            {
                Console.WriteLine("Invalid type. Exiting...");
                return;
            }

            // Geometriák számának bekérése
            Console.WriteLine("Enter number of geometries:");
            string? input = Console.ReadLine();

            // Ellenőrzöm, hogy a bemenet nem üres és tényleg számot adott meg a felhasználó
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int count) || count <= 0)
            {
                Console.WriteLine("Invalid number. Exiting...");
                return;
            }

            // Elérési út bekérése
            Console.WriteLine("Enter output file path:");
            string? outputPath = Console.ReadLine();

            // Ellenőrzöm, hogy az elérési út helyes-e
            if (string.IsNullOrEmpty(outputPath))
            {
                Console.WriteLine("Invalid outputpath. Exiting...");
                return;
            }
        }
    }
}
