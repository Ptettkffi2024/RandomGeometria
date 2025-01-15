﻿using NetTopologySuite.Geometries;

namespace Randomgeometria
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

            // Program paraméterek példányosítása
            var parameters = new ProgramParameters(outputPath);

            var creator = new RandomGeometriaGenerator(); // Random geometria generátor példányosítása
            var geometries = new List<NetTopologySuite.Geometries.Geometry>(); // Egy lista, mely geometriai objektumokat fog tárolni, NetTopologySuite meghívása

            // Geometriák generálása
            for (int i = 0; i < count; i++)
            {
                geometries.Add(creator.GenerateGeometry(geometryType));
            }

            // FileWriter példányosítása 
            var fileWriter = new FileWriter(parameters);

            // Geometriák fájlba írása
            fileWriter.WriteGeometries(geometries);

            // Sikeres üzenet
            Console.WriteLine("Geometries successfully written to the file.");
        
            // Várakozik a felhasználói inputra, hogy látható legyen a kimenetet
            Console.ReadLine();
        }
    }
}
