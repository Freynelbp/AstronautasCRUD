namespace AstronautasCRUD.Datos
{
    public class Conexion
    {
        private readonly string cadenaSQL=String.Empty;
        //Con estos Metodos obtengo la Cadena de Conexion del ConnectionStrings
        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaConexion").Value;
        }


        public string getCadenaSQL()
        {
            return cadenaSQL;
        }

    }
}
