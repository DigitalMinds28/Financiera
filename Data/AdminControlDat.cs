using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Data
{
    public class AdminControlDat
    {
        Persistence objPer = new Persistence();
        // procedimiento para mostar
        public DataSet showAdminControl()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objdata = new DataSet();
            MySqlCommand objSeletCmd = new MySqlCommand();
            objSeletCmd.Connection = objPer.openConection();
            objSeletCmd.CommandText = "spSeleccion_Control_Administrador";
            objSeletCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSeletCmd;
            objAdapter.Fill(objdata);
            objPer.closeConection();
            return objdata;
        }
        // procedimiento para guardar
        public bool saveAdminControl(string _post, int _idAccount, int _idManager)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spAgregar_Control_Administrador";
            objSelectCmd.CommandType = CommandType.StoredProcedure; //nombre del procedimiento almacenado
            objSelectCmd.Parameters.Add("cargo", MySqlDbType.VarString).Value = _post;
            objSelectCmd.Parameters.Add("idCuenta", MySqlDbType.Int32).Value = _idAccount;
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
        // procedimiento para actualizar
        public bool updateAdminControl(int _idControlAdmin, string _post, int _idAccount, int _idManager)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spActualizar_Control_Administrador"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("idControlAdministrador", MySqlDbType.Int32).Value = _idControlAdmin;
            objSelectCmd.Parameters.Add("cargo", MySqlDbType.VarString).Value = _post;
            objSelectCmd.Parameters.Add("idCuenta", MySqlDbType.Int32).Value = _idAccount;
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
        // procedimiento para eliminar
        public bool deleteAdminControl(int _idControlAdmin)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spEliminar_Control_Administrador"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("idControlAdministrador", MySqlDbType.Int32).Value = _idControlAdmin;
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