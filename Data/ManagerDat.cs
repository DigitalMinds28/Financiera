using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Data
{
    public class ManagerDat
    {
        Persistence objPer = new Persistence();
        // procedimiento para mostar Manager
        public DataSet showManager()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objdata = new DataSet();

            MySqlCommand objSeletCmd = new MySqlCommand();
            objSeletCmd.Connection = objPer.openConection();
            objSeletCmd.CommandText = "spSeleccion_Administrador";
            objSeletCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSeletCmd;
            objAdapter.Fill(objdata);
            objPer.closeConection();
            return objdata;
        }
        public DataSet showManagerDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objdata = new DataSet();

            MySqlCommand objSeletCmd = new MySqlCommand();
            objSeletCmd.Connection = objPer.openConection();
            objSeletCmd.CommandText = "spSeleccion_AdministradorDDL";
            objSeletCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSeletCmd;
            objAdapter.Fill(objdata);
            objPer.closeConection();
            return objdata;
        }

        // procedimiento para guardar Manager
        public bool saveManager(string _admName, string _admLastname)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spAgregar_Administrador";
            objSelectCmd.CommandType = CommandType.StoredProcedure; //nombre del procedimiento almacenado
            objSelectCmd.Parameters.Add("nombre", MySqlDbType.VarString).Value = _admName;
            objSelectCmd.Parameters.Add("apellido", MySqlDbType.VarString).Value = _admLastname;

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

        // procedimiento para actualizar Manager
        public bool updateManager(int _idManager, string _admName, string _admLastname)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spActualizar_Administrador"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("idAdministrador", MySqlDbType.Int32).Value = _idManager;
            objSelectCmd.Parameters.Add("nombre", MySqlDbType.VarString).Value = _admName;
            objSelectCmd.Parameters.Add("apellido", MySqlDbType.VarString).Value = _admLastname;

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
        public bool deleteManager(int _idManager)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spEliminar_Administrador"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("idAdministrador", MySqlDbType.Int32).Value = _idManager;

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