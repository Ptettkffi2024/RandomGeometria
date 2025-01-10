using NetTopologySuite.Geometries;

namespace Randomgeometria
{
    public class PolygonGenerator
    {
        // Vélteltenszerű számgenerátor
        private readonly Random random;

         // Konstruktor, amely inicializálja a véletlenszerű számgenerátort
        public PolygonGenerator(Random random)
        {
            this.random = random;
        }
    }
}
