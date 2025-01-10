namespace Randomgeometria
{
    public abstract class GeomWriter
    {
        /// <summary>
        /// A futás paraméterei, melyeket a ProgramParameters osztály tárol
        /// </summary>
        protected ProgramParameters Parameters { get; private set; }

        /// <summary>
        /// Új példány létrehozása, ami tárolja a program paramétereit
        /// </summary>
        /// <param name="programParameters"></param>
        public GeomWriter(ProgramParameters programParameters)
        {
            Parameters = programParameters;
        }

        /// <summary>
        /// Geometriák szöveggé alakítása és listába helyezése.
        /// </summary>
        /// <param name="geometries">A feldolgozandó geometria lista</param>
        /// <returns>A geometriák szöveges reprezentációinak listája</returns>
        protected List<string> GeometriesToString(List<NetTopologySuite.Geometries.Geometry> geometries)
        {
            List<string> geomStrList = new List<string>(); // Lista, ami a geometriák szöveges reprezentációját tartalmazza

            foreach (var geometry in geometries)
            {
                geomStrList.Add(geometry.ToString());
            }

            return geomStrList;
        }

        // A geometriák különböző formátumának kiírása
        public abstract void WriteGeometries(List<NetTopologySuite.Geometries.Geometry> geometries);
    }
}
