using AstronautasCRUD.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AstronautasCRUD.Datos
{
    public class AstronautaDatos
    {
        private Conexion cn = new Conexion();


        public List<AstronautaModel> Listar()
        {
            var obj_Lista = new List<AstronautaModel>();

            using (var sql = new SqlConnection(cn.getCadenaSQL()))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", sql);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var er = cmd.ExecuteReader())
                {
                    while (er.Read())
                    {
                        obj_Lista.Add(new AstronautaModel()
                        {
                            IdAstronauta = Convert.ToInt32(er["IdAstronauta"]),
                            Foto = er["Foto"].ToString(),
                            Nombre = er["Nombre"].ToString(),
                            Nacionalidad = er["Nacionalidad"].ToString(),
                            Descripcion = er["Descripcion"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(er["FechaNacimiento"]),
                            //FechaFallecimiento = Convert.ToDateTime(er["FechaFallecimiento"]),
                            FechaFallecimiento = (er["FechaFallecimiento"] as DateTime?)?.Date,
                            Edad = Convert.ToInt32(er["Edad"]),
                            RedesSociales = er["RedesSociales"].ToString(),
                            DetallesMisiones = er["DetallesMisiones"].ToString(),
                            Activo = Convert.ToBoolean(er["Activo"])
                        });
                    }
                }
            }
            return obj_Lista;
        }



        //----------------------Metodos para los filtros---------------------------//
        public List<AstronautaModel> ObtenerFiltrado_Nacionalidad(string nacionalidad)
        {
            var obj_Lista = new List<AstronautaModel>();

            using (var sql = new SqlConnection(cn.getCadenaSQL()))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand($"select * from Astronautas where Nacionalidad like '{nacionalidad}%'", sql);
                cmd.CommandType = CommandType.Text;

                using (var er = cmd.ExecuteReader())
                {
                    while (er.Read())
                    {
                        obj_Lista.Add(new AstronautaModel()
                        {
                            IdAstronauta = Convert.ToInt32(er["IdAstronauta"]),
                            Foto = er["Foto"].ToString(),
                            Nombre = er["Nombre"].ToString(),
                            Nacionalidad = er["Nacionalidad"].ToString(),
                            Descripcion = er["Descripcion"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(er["FechaNacimiento"]),
                            Edad = Convert.ToInt32(er["Edad"]),
                            RedesSociales = er["RedesSociales"].ToString(),
                            DetallesMisiones = er["DetallesMisiones"].ToString(),
                            Activo = Convert.ToBoolean(er["Activo"])
                        });
                    }
                }
            }
            return obj_Lista;
        }




        public List<AstronautaModel> ObtenerFiltrado_Nacionalidad_Activo(string nacionalidad, string activo)
        {
            int estado;

            if (activo == "activo")
                estado = 1;

            else
                estado = 0;


            var obj_Lista = new List<AstronautaModel>();

            using (var sql = new SqlConnection(cn.getCadenaSQL()))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand($"select * from Astronautas where Nacionalidad like '{nacionalidad}%' and Activo = {estado}", sql);
                cmd.CommandType = CommandType.Text;

                using (var er = cmd.ExecuteReader())
                {
                    while (er.Read())
                    {
                        obj_Lista.Add(new AstronautaModel()
                        {
                            IdAstronauta = Convert.ToInt32(er["IdAstronauta"]),
                            Foto = er["Foto"].ToString(),
                            Nombre = er["Nombre"].ToString(),
                            Nacionalidad = er["Nacionalidad"].ToString(),
                            Descripcion = er["Descripcion"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(er["FechaNacimiento"]),
                            Edad = Convert.ToInt32(er["Edad"]),
                            RedesSociales = er["RedesSociales"].ToString(),
                            DetallesMisiones = er["DetallesMisiones"].ToString(),
                            Activo = Convert.ToBoolean(er["Activo"])
                        });
                    }
                }
            }
            return obj_Lista;
        }




        public List<AstronautaModel> ObtenerFiltrado_Activo(string activo)
        {
            int estado;

            if (activo == "activo")
                estado = 1;
            else
                estado = 0;


            var obj_Lista = new List<AstronautaModel>();

            using (var sql = new SqlConnection(cn.getCadenaSQL()))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand($"select * from Astronautas where Activo = {estado}", sql);
                cmd.CommandType = CommandType.Text;

                using (var er = cmd.ExecuteReader())
                {
                    while (er.Read())
                    {
                        obj_Lista.Add(new AstronautaModel()
                        {
                            IdAstronauta = Convert.ToInt32(er["IdAstronauta"]),
                            Foto = er["Foto"].ToString(),
                            Nombre = er["Nombre"].ToString(),
                            Nacionalidad = er["Nacionalidad"].ToString(),
                            Descripcion = er["Descripcion"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(er["FechaNacimiento"]),
                            Edad = Convert.ToInt32(er["Edad"]),
                            RedesSociales = er["RedesSociales"].ToString(),
                            DetallesMisiones = er["DetallesMisiones"].ToString(),
                            Activo = Convert.ToBoolean(er["Activo"])
                        });
                    }
                }
            }
            return obj_Lista;
        }

        //----------------------------------------------------------------------------------//



        //---------Metodo para Buscar por Id-------------//
        public AstronautaModel Obtener(int IdAstronauta)
        {
            var obj_Obtener = new AstronautaModel();

            using (var sql = new SqlConnection(cn.getCadenaSQL()))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", sql);

                cmd.Parameters.AddWithValue("IdAstronauta", IdAstronauta);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var er = cmd.ExecuteReader())
                {
                    while (er.Read())
                    {
                        obj_Obtener.IdAstronauta = Convert.ToInt32(er["IdAstronauta"]);
                        obj_Obtener.Foto = er["Foto"].ToString();
                        obj_Obtener.Nombre = er["Nombre"].ToString();
                        obj_Obtener.Nacionalidad = er["Nacionalidad"].ToString();
                        obj_Obtener.Descripcion = er["Descripcion"].ToString();
                        obj_Obtener.FechaNacimiento = Convert.ToDateTime(er["FechaNacimiento"]);
                        obj_Obtener.Edad = Convert.ToInt32(er["Edad"]);
                        obj_Obtener.RedesSociales = er["RedesSociales"].ToString();
                        obj_Obtener.DetallesMisiones = er["DetallesMisiones"].ToString();
                        obj_Obtener.Activo = Convert.ToBoolean(er["Activo"]);
                    }
                }
            }
            //Aqui devolvemos la lista completa
            return obj_Obtener;
        }




        //---------Metodo para Crear un Astronauta------------//
        public bool Crear(AstronautaModel obj_Astronauta)
        {
            bool respuesta;
            byte[] bytes;
            try
            {
                using (Stream fs = obj_Astronauta.File.OpenReadStream())
                {
                    using (BinaryReader br = new(fs))
                    {
                        bytes = br.ReadBytes((int)fs.Length);
                        obj_Astronauta.Foto = Convert.ToBase64String(bytes, 0, bytes.Length);

                        using (var sql = new SqlConnection(cn.getCadenaSQL()))
                        {
                            sql.Open();
                            SqlCommand cmd = new SqlCommand("sp_Guardar", sql);
                            cmd.Parameters.AddWithValue("Foto", obj_Astronauta.Foto);
                            cmd.Parameters.AddWithValue("Nombre", obj_Astronauta.Nombre);
                            cmd.Parameters.AddWithValue("Nacionalidad", obj_Astronauta.Nacionalidad);
                            cmd.Parameters.AddWithValue("Descripcion", obj_Astronauta.Descripcion);
                            cmd.Parameters.AddWithValue("FechaNacimiento", obj_Astronauta.FechaNacimiento);

                            if (obj_Astronauta.FechaFallecimiento == null)
                                cmd.Parameters.AddWithValue("FechaFallecimiento", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("FechaFallecimiento", obj_Astronauta.FechaFallecimiento);

                            cmd.Parameters.AddWithValue("Edad", Edad(obj_Astronauta.FechaNacimiento, obj_Astronauta.FechaFallecimiento));
                            if (string.IsNullOrEmpty(obj_Astronauta.RedesSociales))
                                cmd.Parameters.AddWithValue("RedesSociales", "Nada para Mostrar");
                            else
                                cmd.Parameters.AddWithValue("RedesSociales", obj_Astronauta.RedesSociales);

                            cmd.Parameters.AddWithValue("DetallesMisiones", obj_Astronauta.DetallesMisiones);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.ExecuteNonQuery();
                            sql.Close();
                        }
                        respuesta = true;

                    }
                }
            }

            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }



        //---------Metodo para Editar un Astronauta------------//

        public bool Editar(AstronautaModel obj_Astronauta)
        {
            bool respuesta;
            byte[] bytes;
            try
            {
                using (Stream fs = obj_Astronauta.File.OpenReadStream())
                {
                    using (BinaryReader br = new(fs))
                    {
                        bytes = br.ReadBytes((int)fs.Length);
                        obj_Astronauta.Foto = Convert.ToBase64String(bytes, 0, bytes.Length);

                        using (var sql = new SqlConnection(cn.getCadenaSQL()))
                        {
                            sql.Open();
                            SqlCommand cmd = new SqlCommand("sp_Editar", sql);
                            cmd.Parameters.AddWithValue("IdAstronauta", obj_Astronauta.IdAstronauta);
                            cmd.Parameters.AddWithValue("Foto", obj_Astronauta.Foto);
                            cmd.Parameters.AddWithValue("Nombre", obj_Astronauta.Nombre);
                            cmd.Parameters.AddWithValue("Nacionalidad", obj_Astronauta.Nacionalidad);
                            cmd.Parameters.AddWithValue("Descripcion", obj_Astronauta.Descripcion);
                            cmd.Parameters.AddWithValue("FechaNacimiento", obj_Astronauta.FechaNacimiento);

                            if (obj_Astronauta.FechaFallecimiento == null)
                                cmd.Parameters.AddWithValue("FechaFallecimiento", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("FechaFallecimiento", obj_Astronauta.FechaFallecimiento);

                            cmd.Parameters.AddWithValue("Edad", Edad(obj_Astronauta.FechaNacimiento, obj_Astronauta.FechaFallecimiento));
                            if (string.IsNullOrEmpty(obj_Astronauta.RedesSociales))
                                cmd.Parameters.AddWithValue("RedesSociales", "Nada para Mostrar");
                            else
                                cmd.Parameters.AddWithValue("RedesSociales", obj_Astronauta.RedesSociales);

                            cmd.Parameters.AddWithValue("DetallesMisiones", obj_Astronauta.DetallesMisiones);
                            cmd.Parameters.AddWithValue("Activo", obj_Astronauta.Activo);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.ExecuteNonQuery();
                            sql.Close();
                        }
                        respuesta = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }



        //---------Metodo para Eliminar un Astronauta------------//
        public bool Eliminar(int IdAstronauta)
        {
            bool respuesta;
            try
            {
                using (var sql = new SqlConnection(cn.getCadenaSQL()))
                {
                    sql.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", sql);

                    cmd.Parameters.AddWithValue("IdAstronauta", IdAstronauta);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }


        //---------Metodo para calcular la edad si esta vivo en la actualidad o no------------//
        public int Edad(DateTime? fechaNacimiento, DateTime? fechaFallecimiento)
        {
            if (fechaFallecimiento == null)
            {
                // La persona está viva, por lo que la edad es la diferencia entre la fecha actual y la fecha de nacimiento
                return Convert.ToInt32((DateTime.Now - fechaNacimiento)?.Days / 365.25);
            }
            else
            {
                // La persona ha fallecido, por lo que la edad es la diferencia entre la fecha de fallecimiento y la fecha de nacimiento
                return Convert.ToInt32((fechaFallecimiento - fechaNacimiento)?.Days / 365.25);
            }
        }
    }
}
