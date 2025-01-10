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
    }
}