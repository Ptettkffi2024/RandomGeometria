using NetTopologySuite.Geometries;

namespace Randomgeometria
{
    public class PointGenerator
    {
        // Geometria objektumok létrehozásához használt osztály
        private readonly GeometryFactory geometryFactory;

        // Vélteltenszerű számgenerátor
        private readonly Random random;

        // Konstruktor, amely inicializálja a GeometryFactory-t és a véletlenszerű számgenerátort
        public PointGenerator(Random random)
        {
            geometryFactory = new GeometryFactory();
            this.random = new Random();
        }

        // Itt hozom létre a Point objektumot véletlenszerű koordinátákból
        public Point CreatePoint()
        {
            return geometryFactory.CreatePoint(CreateCoordinate());  // A pontot a GeometryFactory segítségével hozom létre, a CreateCoordinate metódussal generált koordinátával
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
