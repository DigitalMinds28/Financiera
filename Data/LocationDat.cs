using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Data
{
    public class LocationDat
    {
        Persistence objPer = new Persistence();

        // procedimiento para mostar
        public DataSet showlocation()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objdata = new DataSet();

            MySqlCommand objSeletCmd = new MySqlCommand();
            objSeletCmd.Connection = objPer.openConection();
            objSeletCmd.CommandText = "spSeleccion_Ubicacion";
            objSeletCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSeletCmd;
            objAdapter.Fill(objdata);
            objPer.closeConection();
            return objdata;
        }
        public DataSet showlocationDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objdata = new DataSet();

            MySqlCommand objSeletCmd = new MySqlCommand();
            objSeletCmd.Connection = objPer.openConection();
            objSeletCmd.CommandText = "spSeleccion_UbicacionDDL";
            objSeletCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSeletCmd;
            objAdapter.Fill(objdata);
            objPer.closeConection();
            return objdata;
        }
        // procedimiento para guardar
        public bool savelocation(string _placeName)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spAgregar_Ubicacion";
            objSelectCmd.CommandType = CommandType.StoredProcedure; //nombre del procedimiento almacenado
            objSelectCmd.Parameters.Add("nombreUbicacion", MySqlDbType.VarString).Value = _placeName;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.ToString());
            }
            objPer.closeConection();
            return executed;
        }

        // procedimiento para actualizar
        public bool updatelocation(int _idLocation, string _placename)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spActualizar_Ubicacion"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("idUbicacion", MySqlDbType.Int32).Value = _idLocation;
            objSelectCmd.Parameters.Add("nombreUbicacion", MySqlDbType.VarString).Value = _placename;


            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.ToString());
            }
            objPer.closeConection();
            return executed;
        }

        // procedimiento para eliminar
        public bool deletelocation(int _idlocation)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spEliminar_Ubicacion"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("idUbicacion", MySqlDbType.Int32).Value = _idlocation;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.ToString());
            }
            objPer.closeConection();
            return executed;
        }
    }
}