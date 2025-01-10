using System;
using System.Collections.Generic;
using System.IO;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace Randomgeometria
{
    public class FileWriter : GeomWriter
    {
        public FileWriter(ProgramParameters programParameters) : base(programParameters) { }

        // A geometriák WKT formátumba történő írása
        public override void WriteGeometries(List<Geometry> geometries)
        {
            var wktWriter = new WKTWriter(); // WKT formátumba alakítja a geometriákat
            List<string> WktGeometries = new List<string>(); // Egy lista, ami a WKT formátumú geometrákat tárolja

            foreach (var geometry in geometries)
            {
                if (geometry is Geometry validGeometry)
                {
                    WktGeometries.Add(wktWriter.Write(validGeometry)); // Konvertálás WKT formátumba
                }
                else
                {
                    Console.WriteLine("One of the items in the list is not of type Geometry."); // Ha az elem nem geometria típusú, akkor ez a hibaüzenet jöjjön ki
                }
            }

            try
            {
                // A WKT geometriákat kiíratom a megadott file-ba
                File.WriteAllLines(Parameters.Output!, WktGeometries);
                Console.WriteLine("Geometries successfully written to the file.");
            }
            catch (IOException ex)
            {
                // Ha hiba történik a file írása közben, akkor ez a hibaüzenet érkezik
                Console.WriteLine($"Error writing the file: {ex.Message}");
            }
        }
    }
}
