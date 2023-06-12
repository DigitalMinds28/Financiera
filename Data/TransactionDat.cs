using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Data
{
    public class TransactionDat
    {
        Persistence objPer = new Persistence();

        // procedimiento para mostar transaction
        public DataSet showTransaction()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objdata = new DataSet();

            MySqlCommand objSeletCmd = new MySqlCommand();
            objSeletCmd.Connection = objPer.openConection();
            objSeletCmd.CommandText = "spSeleccion_Transaccion";
            objSeletCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSeletCmd;
            objAdapter.Fill(objdata);
            objPer.closeConection();
            return objdata;
        }

        // procedimiento para guardar transaction
        public bool saveTransaction(string _dateTime, string _type, double _monto, int _idDestinationAccount,
            int _accountOrigin, int _idLocation)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spAgregar_Transaccion"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("fecha_y_Hora", MySqlDbType.VarString).Value = _dateTime;
            objSelectCmd.Parameters.Add("tipo", MySqlDbType.VarString).Value = _type;
            objSelectCmd.Parameters.Add("monto", MySqlDbType.Double).Value = _monto;
            objSelectCmd.Parameters.Add("idCuentaDestino", MySqlDbType.Int32).Value = _idDestinationAccount;
            objSelectCmd.Parameters.Add("idCuentaOrigen", MySqlDbType.Int32).Value = _accountOrigin;
            objSelectCmd.Parameters.Add("idUbicacion", MySqlDbType.Int32).Value = _idLocation;

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
        public bool deleteTransaction(int _idTransaction)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spEliminar_Transaccion"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("idTransaccion", MySqlDbType.Int32).Value = _idTransaction;

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