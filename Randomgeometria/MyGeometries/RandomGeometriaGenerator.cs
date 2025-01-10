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
        
    }
}
