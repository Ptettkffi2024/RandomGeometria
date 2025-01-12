using NetTopologySuite.Geometries;

namespace Randomgeometria
{
    public class LineGenerator
    {
        // Geometria objektumok létrehozásához használt osztály
        private readonly GeometryFactory geometryFactory;
        
        // Vélteltenszerű számgenerátor
        private readonly Random random;

        // Konstruktor, amely inicializálja a GeometryFactory-t és a véletlenszerű számgenerátort
        public LineGenerator(Random random)
        {
            geometryFactory = new GeometryFactory();
            this.random = new Random();
        }

         // Itt hozom létre a LineSrting objektumot véletlenszerű koordinátákból
        public LineString CreateLineString()
        {
            int numPoints = random.Next(2, 10); // Véletlenszerűen kiválasztja, hogy hány pontból álljon a vonal, 2 és 10 között
            var coordinates = new Coordinate[numPoints]; // A pontokat egy koordináta tömbben tárolja
            
            // A tömb feltöltése véletlenszerű koordinátákkal
            for (int i = 0; i < numPoints; i++)
            {
                coordinates[i] = CreateCoordinate();
            }
            return geometryFactory.CreateLineString(coordinates);
        }

        // Létrehoz egy véletlenszerű koordinátát x és y értékkel (én -100 és +100 közé tettem, hogy random ebből az intervallumból választhasson)
        private Coordinate CreateCoordinate()
        {
            double x = GenerateRandomValue(-100, 100);
            double y = GenerateRandomValue(-100, 100);
            return new Coordinate(x, y);
        }

        // Véletlenszerű számot generál a megadott min és max érték között
        private double GenerateRandomValue(double min, double max)
        {
            return min + random.NextDouble() * (max - min);
        }
    }
}