using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Data
{
    public class CustomerDat
    {
        Persistence objPer = new Persistence();

        // procedimiento para mostar clientes
        public DataSet showCustomer()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objdata = new DataSet();

            MySqlCommand objSeletCmd = new MySqlCommand();
            objSeletCmd.Connection = objPer.openConection();
            objSeletCmd.CommandText = "spSeleccion_Cliente";
            objSeletCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSeletCmd;
            objAdapter.Fill(objdata);
            objPer.closeConection();
            return objdata;
        }

        // procedimiento para guardar clientes
        public bool saveCustomer(int _identification, string _name, string _lastname, string _phone)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spAgregar_Cliente";
            objSelectCmd.CommandType = CommandType.StoredProcedure; //nombre del procedimiento almacenado
            objSelectCmd.Parameters.Add("identificacion", MySqlDbType.Int32).Value = _identification;
            objSelectCmd.Parameters.Add("nombre", MySqlDbType.VarString).Value = _name;
            objSelectCmd.Parameters.Add("apellido", MySqlDbType.VarString).Value = _lastname;
            objSelectCmd.Parameters.Add("telefono", MySqlDbType.VarString).Value = _phone;

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

        // procedimiento para actualizar clientes
        public bool updateCustomer(int _idCustomer, int _identification, string _name, string _lastname, string _phone)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spActualizar_Cliente"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("idCliente", MySqlDbType.Int32).Value = _idCustomer;
            objSelectCmd.Parameters.Add("identificacion", MySqlDbType.Int32).Value = _identification;
            objSelectCmd.Parameters.Add("nombre", MySqlDbType.VarString).Value = _name;
            objSelectCmd.Parameters.Add("apellido", MySqlDbType.VarString).Value = _lastname;
            objSelectCmd.Parameters.Add("telefono", MySqlDbType.VarString).Value = _phone;

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
        public bool deleteCustomer(int _idCustomer)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spEliminar_Cliente"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("IdCliente", MySqlDbType.Int32).Value = _idCustomer;

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
        //Metodo para mostrar unicamente el id y la descripcion de los clientes en el DropDownList
        public DataSet showCustomerDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spSeleccion_ClienteDDL";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConection();
            return objData;
        }
    }
}