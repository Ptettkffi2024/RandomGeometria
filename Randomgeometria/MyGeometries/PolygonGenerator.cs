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

         // Véletlenszerű polygon létrehozása
        public Polygon CreatePolygon()
        {
            // Geometria objektumok létrehozásához használt osztály
            var geometryFactory = new GeometryFactory();

            // Véletlenszerű pontszám generálása (minimum 3, maximum 10 ponttal)
            int pointCount = random.Next(3, 11); // Poligonhoz legalább 3 pont kell

            // Koordináták tömbje, az utolsó hely a záróponthoz
            var coordinates = new Coordinate[pointCount + 1];

            // Véletlenszerű koordináták generálása a pontokhoz
            for (int i = 0; i < pointCount; i++)
            {
                // Véletlenszerű X és Y koordináták generálása 
                double x = GenerateRandomDoubleInRange();
                double y = GenerateRandomDoubleInRange();
                coordinates[i] = new Coordinate(x, y); // Koordináta hozzáadása a tömbhöz
            }

            // Az utolsó pontnak ugyanannak kell lenni, mit az elsőnek, hogy zárt legyen a polygon
            coordinates[pointCount] = coordinates[0];

            //A GeometryFactory segítségével hozom létre a polygont a generált koordináták alapján
            var polygon = geometryFactory.CreatePolygon(coordinates);
            
            return polygon;
        }

        
        private double GenerateRandomDoubleInRange()
        {
            // Véletlenszám generátor 
            Random random = new Random();

            // Véletlen szám generálása -100 és +100 között
            return random.NextDouble() * 200 - 100;
        }
    }
}
