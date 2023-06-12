using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Data
{
    public class AccountDat
    {
        Persistence objPer = new Persistence();
        // procedimiento para mostar
        public DataSet showAccount()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objdata = new DataSet();
            MySqlCommand objSeletCmd = new MySqlCommand();
            objSeletCmd.Connection = objPer.openConection();
            objSeletCmd.CommandText = "spSeleccion_Cuenta";
            objSeletCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSeletCmd;
            objAdapter.Fill(objdata);
            objPer.closeConection();
            return objdata;
        }
        // procedimiento para guardar
        public bool saveAccount(int _accountNumber, double _cash, int _idCustomer)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spAgregar_Cuenta";
            objSelectCmd.CommandType = CommandType.StoredProcedure; //nombre del procedimiento almacenado
            objSelectCmd.Parameters.Add("numeroCuenta", MySqlDbType.Int32).Value = _accountNumber;
            objSelectCmd.Parameters.Add("saldo", MySqlDbType.Double).Value = _cash;
            objSelectCmd.Parameters.Add("idCliente", MySqlDbType.Int32).Value = _idCustomer;

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
        public bool updateAccount(int _idAccount, int _accountNumber, double _cash, int _idCustomer)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spActualizar_Cuenta"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("idCuenta", MySqlDbType.Int32).Value = _idAccount;
            objSelectCmd.Parameters.Add("numeroCuenta", MySqlDbType.Int32).Value = _accountNumber;
            objSelectCmd.Parameters.Add("saldo", MySqlDbType.Double).Value = _cash;
            objSelectCmd.Parameters.Add("idCliente", MySqlDbType.Int32).Value = _idCustomer;

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
        public bool deleteAccount(int _idAccount)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spEliminar_Cuenta"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("idCuenta", MySqlDbType.Int32).Value = _idAccount;
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
        // procedimiento para mostrar ciertos atributos
        public DataSet showAccountDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spSeleccion_CuentaDDL"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConection();
            return objData;
        }
    }
}