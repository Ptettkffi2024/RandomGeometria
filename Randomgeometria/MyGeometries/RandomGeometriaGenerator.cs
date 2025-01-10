using System;
using NetTopologySuite.Geometries;


namespace Randomgeometria
{
    public class RandomGeometriaGenerator
    {
        // Véletlenszerű számgenerátor és a különböző geometriák generálására szolgáló osztályok
        private readonly Random random;
        private readonly PointGenerator pointGenerator;
        private readonly LineGenerator lineGenerator;
        private readonly PolygonGenerator polygonGenerator;

        public RandomGeometriaGenerator()  // Konstruktor, amely inicializálja a véletlenszerű számgenerátort és a speciális geometriai generátorokat
        {
            this.random = new Random (); // Itt hozok létre egy új véletlenszerű számgenerátort
            pointGenerator = new PointGenerator(random);
            lineGenerator = new LineGenerator(random);
            polygonGenerator = new PolygonGenerator(random);
        }

         // Ez a fő metódus, amely egy véletlenszerű geometriát generál a kért típus alapján.
        public NetTopologySuite.Geometries.Geometry GenerateGeometry(string geometryType)
        {
            // Egy Dictionary-t hozok létre, amely a geometriatípusokat a generálási metódusaikhoz rendeli
            var geometryCreators = new Dictionary<string, Func<NetTopologySuite.Geometries.Geometry>>
            {
                { "point", () => pointGenerator.CreatePoint() }, // pont generálása
                { "line", () => lineGenerator.CreateLineString() }, // vonal generálása
                { "polygon", () => polygonGenerator.CreatePolygon() } //polygon generálása
            };

            // Geometria típus normalizálása
            string key = geometryType.Trim().ToLower();

            // A megfelelő generátor kiválasztása a Dictionary-ből
            if (geometryCreators.TryGetValue(key, out var createGeometry))
            {
                return createGeometry();
            }

            // Ha a kért geometriatípus nem támogatott, akkor ez az üzenet jelenik meg
            throw new NotSupportedException($"The geometry type '{geometryType}' is not supported.");
        }
    }
}
