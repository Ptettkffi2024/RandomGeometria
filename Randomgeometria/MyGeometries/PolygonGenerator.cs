using NetTopologySuite.Geometries;

namespace Randomgeometria
{
    public class PolygonGenerator
    {
        // Véletlenszerű számgenerátor
        private readonly Random random;

        // Konstruktor, amely inicializálja a véletlenszerű számgenerátort
        public PolygonGenerator(Random random)
        {
            this.random = random;
        }

        // Véletlenszerű polygon létrehozása
        public Polygon CreatePolygon()
        {
            // Geometria objektumok létrehozásához használt osztály
            var geometryFactory = new GeometryFactory();

            // Véletlenszerű pontszám generálása (minimum 3, maximum 10 ponttal)
            int pointCount = random.Next(3, 11); // Poligonhoz legalább 3 pont kell

            // Véletlenszerű koordináták generálása
            List<Coordinate> coordinates = new List<Coordinate>();
            for (int i = 0; i < pointCount; i++)
            {
                // Véletlenszerű X és Y koordináták generálása 
                double x = GenerateRandomDoubleInRange();
                double y = GenerateRandomDoubleInRange();
                coordinates.Add(new Coordinate(x, y));
            }

            // Az első és az utolsó pontnak ugyanannak kell lenni, hogy zárt polygon legyen
            coordinates.Add(coordinates[0]);

            // Konvex algoritmus használata a koordinátákból egy nem önmetsző polygon létrehozásához
            var convex = CreateConvex(coordinates);

            // A konvex-et polygonként hozom létre
            var polygon = geometryFactory.CreatePolygon(convex);

            return polygon;
        }
        
        // Véletlenszerű szám generálása -100 és +100 között.
        private double GenerateRandomDoubleInRange()
        {
            return random.NextDouble() * 200 - 100;
        }

        // Konvex algoritmus, amely biztosítja, hogy a polygon ne legyen önmetsző.
        private Coordinate[] CreateConvex(List<Coordinate> coordinates)
        {
            // Ehhez a NetTopologySuite-ban tartozik egy beépített függvény
            var geometryFactory = new GeometryFactory();
            var geometry = geometryFactory.CreateGeometryCollection(new Geometry[] { geometryFactory.CreatePolygon(coordinates.ToArray()) });
            
            var convex = geometry.ConvexHull(); // A NetTopologySuite beépített metódusa, amely létrehozza a konvexet

            return convex.Coordinates;
        }
    }
}